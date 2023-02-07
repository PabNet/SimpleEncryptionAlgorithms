using System;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.SimpleCaesar
{
    public class Decoder : CaesarEncryption
    {
        public Decoder(byte key, string word) : base(key, word) { }

        private protected override char LetterConversion(char letter)
        {
            return GetLetterByIndex(Convert.ToByte((GetLetterIndex(in letter) +
                                                    (ICaesarEncryption.LetterNumbers - this._key)) 
                                                   % ICaesarEncryption.LetterNumbers ));
        }
        
    }
}