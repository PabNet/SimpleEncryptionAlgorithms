using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.KeyPhrase
{
    public abstract class KeyPhraseEncryption : IKeyPhraseEncryption
    {
        private protected string _keyWord, _encryptionWord, _cloneKey;
        private protected List<string> _headerRow;

        public string KeyWord => this._cloneKey;

        public KeyPhraseEncryption(string keyWord, string encryptionWord)
        {
            this._keyWord = keyWord;
            this._cloneKey = this._keyWord;
            this._encryptionWord = encryptionWord;
            this._headerRow = new();
        }
        
        private void CreatingHeaderRow()
        {
            List<byte> originalKeyWordVersion = new(),
                sortKeyWordVersion = new();
            Dictionary<string, byte> letterNumbers = new Dictionary<string, byte>();
            
            
            foreach (var letter in this._keyWord)
            {
                originalKeyWordVersion.Add(AlphabetMap.Alphabet[letter]);
                sortKeyWordVersion.Add(AlphabetMap.Alphabet[letter]);
            }
            sortKeyWordVersion.Sort();  
            
            for (byte i = 0; i < this._keyWord.Length; i++)
            {
                letterNumbers.Add((i+1).ToString(), sortKeyWordVersion[i]);
            }


            foreach (var digit in originalKeyWordVersion)
            {
                foreach (var entry in letterNumbers)
                {
                    if (entry.Value == digit)
                    {
                        this._headerRow.Add(entry.Key);
                        letterNumbers.Remove(entry.Key);
                        break;
                    }
                }
            }

        }
        
        private protected List<string> BreakTheWordIntoBlocks()
        {
            List<string> wordBlocks = new();
            
            for (byte i = 0; i < this._encryptionWord.Length; i+=(byte)this._keyWord.Length)
            {
                string substring = "";
                int length = this._keyWord.Length;
                while (true)
                {
                    try
                    {
                        substring = this._encryptionWord.Substring(i, length);
                        while (substring.Length != this._keyWord.Length)
                        {
                            substring += IEncryption.EmptySymbol;
                        }
                        break;
                    }
                    catch
                    {
                        length--;
                    }
                }
                
                
                wordBlocks.Add(substring);
            }

            return wordBlocks;

        }

        private protected abstract void FillInTheEncryptionMatrix();

        private void ConvertKeyWord()
        {
            this._keyWord = ((this._encryptionWord.Length < this._keyWord.Length) ? 
                this._keyWord.Substring(0,this._encryptionWord.Length) : this._keyWord);
        }

        public string GetWord()
        {
            ConvertKeyWord();
            CreatingHeaderRow();
            FillInTheEncryptionMatrix();
            return this._encryptionWord;
        }
    }
}