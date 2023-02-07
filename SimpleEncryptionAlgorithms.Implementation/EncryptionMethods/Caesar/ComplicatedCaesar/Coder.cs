using System;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.ComplicatedCaesar
{
    public class Coder : CaesarEncryption
    {
        public Coder(byte key, string word) : base(key, word) { }
        
        public string Word { get=> this._word; set=> this._word = value; }

        private protected override char LetterConversion(char letter)
        {
            return GetLetterByIndex(Convert.ToByte((GetLetterIndex(in letter)
                                                    *  this._key)
                                                   % ICaesarEncryption.LetterNumbers));
        }
    }
}