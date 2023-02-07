using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.KeyPhrase
{
    public class Decoder : KeyPhraseEncryption
    {
        public Decoder(string keyWord, string encryptionWord) : base(keyWord, encryptionWord) {}

        private protected override void FillInTheEncryptionMatrix()
        {
            string fullWord = "";

            foreach (var substring in BreakTheWordIntoBlocks())
            {


                Dictionary<string, string> block = new();
                
                foreach (var elem in this._headerRow)
                {
                    block.Add(elem, IEncryption.EmptySymbol.ToString());
                }

                for (byte i = 0; i < substring.Length; i++)
                {
                    block[(i + 1).ToString()] = substring[i].ToString();
                }


                foreach (var letter in block)
                {
                    fullWord += letter.Value;
                }
                
                
            }
            
            this._encryptionWord = Regex.Replace(fullWord, $"{IEncryption.EmptySymbol}", "", RegexOptions.IgnoreCase);
        }
        
    }
}