using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.KeyPhrase
{
    public class Encoder : KeyPhraseEncryption
    {
        public Encoder(string keyWord, string encryptionWord) : base(keyWord, encryptionWord) {}

        private protected override void FillInTheEncryptionMatrix()
        {
            string newWord = "";

            foreach (var substringFromPhrase in BreakTheWordIntoBlocks())
            {
                SortedDictionary<byte, string> letterBlock = new();
                byte counter = 0;
                foreach (var letter in substringFromPhrase)
                {
                    letterBlock.Add(byte.Parse(this._headerRow[counter++]), letter.ToString());
                }
                

                foreach (var pair in letterBlock)
                {
                    newWord += pair.Value;
                }
            }

            this._encryptionWord = newWord;

        }
    }
}