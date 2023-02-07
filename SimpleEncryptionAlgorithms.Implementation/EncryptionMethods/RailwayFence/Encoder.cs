namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RailwayFence
{
    public class Encoder : RailwayFenceEncryption
    {
        private protected override void PutTogetherTheWord()
        {
            for (byte counter = 0; counter < this._key; counter++)
            {
                foreach (var list in this._letterList)
                {
                    if (list[counter] is not IRailwayFenceEncryption.EmptySymbol)
                    {
                        this._word += list[counter];
                    }
                }
            }
            
        }

        private protected override void ProcessWord()
        {
            foreach (var letter in this._word)
            {
                FillListOfCharacters(letter);
            }
        }

        public Encoder(byte key, string word) : base(key, word) {}
    }
}