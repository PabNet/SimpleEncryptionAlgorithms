using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RotatingGrate
{
    public class Decoder : RotatingGrateEncryption
    {

        public Decoder(string text, List<List<char>> coordinates) : base(text, coordinates)
        {
            
        }

        public override string GetWord()
        {
            string result = "";

            foreach (var substring in this.Text)
            {
                byte index = 0;
                var charMatrix = MatrixInitialization(new List<List<char>>(),substring);

                for (byte count = 0; count < 4; count++)
                {
                    if (index <= substring.Length)
                    {
                        for (byte i = 0; i < IRotatingGrateEncryption.NumberOfLines; i++)
                        {
                            for (byte j = 0; j < IRotatingGrateEncryption.NumberOfColumns; j++)
                            {
                                if (this.Coordinates[i][j] == IRotatingGrateEncryption.KeySymbol)
                                {
                                    if (charMatrix[i][j] != IRotatingGrateEncryption.EmptySymbol)
                                    {
                                        result += charMatrix[i][j];
                                    }
                                    index++;
                                }
                            }
                        }
                    }
                    charMatrix = RotateMatrix(charMatrix);
                }


            }

            return result;
        } 
    }
}