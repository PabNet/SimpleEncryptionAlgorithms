using System.Linq;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar
{
    public abstract class CaesarEncryption : ICaesarEncryption
    {
        private protected readonly byte _key;
        private protected string _word;

        public CaesarEncryption(byte key, string word)
        {
            this._key = key;
            this._word = word;
        }

        private protected byte GetLetterIndex(in char letter)
        {
            return AlphabetMap.Alphabet.ContainsKey(letter)
                ? AlphabetMap.Alphabet[letter]
                : AlphabetMap.Alphabet.Last().Value;
        }

        private protected char GetLetterByIndex(byte index)
        {
            char letter = '\0';
            foreach (var letterPair in AlphabetMap.Alphabet)
            {
                if (letterPair.Value == index)
                {
                    letter = letterPair.Key;
                    break;
                }
            }

            return letter;
        }

        private protected abstract char LetterConversion(char letter);


        public string GetWord()
        {
            string str = "";
            for (byte index = 0; index < this._word.Length; index++)
            {
                str += this.LetterConversion(this._word[index]);
            }
            return str;
        }

        public byte Key => this._key;
    }
}