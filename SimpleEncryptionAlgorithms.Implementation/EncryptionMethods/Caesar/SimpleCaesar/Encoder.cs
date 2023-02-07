using System;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.SimpleCaesar
{
    public class Encoder : CaesarEncryption
    {
        public Encoder(byte key, string word) : base(key, word) { }

        private protected override char LetterConversion(char letter)
        {
            return GetLetterByIndex(Convert.ToByte((GetLetterIndex(in letter)
                                                    +  this._key)
                                                   % ICaesarEncryption.LetterNumbers));
        }
    }
}