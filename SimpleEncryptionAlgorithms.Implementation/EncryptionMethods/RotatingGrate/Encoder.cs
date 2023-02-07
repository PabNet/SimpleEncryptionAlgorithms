using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RotatingGrate
{
    public class Encoder : RotatingGrateEncryption
    {

        public Encoder(string text, List<List<char>> coordinates) : base(text, coordinates)
        {
            
        }
        
        public override string GetWord()
        {
            string result = "";

            foreach (var substring in this.Text)
            {
                byte index = 0;
                var charMatrix = MatrixInitialization(new List<List<char>>(), IRotatingGrateEncryption.EmptySymbol);

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
                                    if (index < substring.Length)
                                    {
                                        charMatrix[i][j] = substring[index];
                                    }
                                    index++;
                                }
                            }
                        }
                    }
                    charMatrix = RotateMatrix(charMatrix);
                }
                for (byte i = 0 ; i < IRotatingGrateEncryption.NumberOfLines; i++)
                {
                    for (byte j = 0; j < IRotatingGrateEncryption.NumberOfColumns; j++)
                    {
                        result += charMatrix[i][j];
                    }
                }
                

            }

            return result;
        }
    }
}