namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RailwayFence
{
    public class Decoder : RailwayFenceEncryption
    {
        public Decoder(byte key, string word) : base(key, word) {}

        private protected override void ProcessWord()
        {
            
            for (byte index = 0; index < this._word.Length; index++)
            {
                FillListOfCharacters(IRailwayFenceEncryption.TemplateSymbol);
            }

            _letterIndex = 0;
            
            for (byte counter = 0; counter < this._key; counter++)
            {
                foreach (var list in this._letterList)
                {
                    if (list[counter] is IRailwayFenceEncryption.TemplateSymbol)
                    {
                        list[counter] = this._word[_letterIndex++];
                    }
                }
            }
        }

        private protected override void PutTogetherTheWord()
        {
            foreach (var column in this._letterList)
            {
                foreach (var symbol in column)
                {
                    if (symbol is not IRailwayFenceEncryption.EmptySymbol)
                    {
                        this._word += symbol;
                        break;
                    }
                }
            }
        }
    }
}