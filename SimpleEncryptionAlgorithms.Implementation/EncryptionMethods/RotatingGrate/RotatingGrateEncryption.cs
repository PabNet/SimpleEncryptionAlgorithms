using System;
using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RotatingGrate
{
    public abstract class RotatingGrateEncryption : IRotatingGrateEncryption
    {
        private static List<List<char>> Lattice = new();
        private protected  List<List<char>> Coordinates;
        private protected List<string> Text;

        public List<List<char>> CoordinatesProperty => Coordinates;

        static RotatingGrateEncryption()
        {
            Lattice = MatrixInitialization(Lattice, char.Parse(0.ToString()));
            FillTheLattice();
        }
        
        private protected static List<List<char>> RotateMatrix(List<List<char>> matrix)
        {
            List<List<char>> newMatrix = new();

            for (int i = 0; i < IRotatingGrateEncryption.NumberOfLines; i++)
            {
                List<char> column = new();
                for (int j = 0; j < IRotatingGrateEncryption.NumberOfColumns; j++)
                {
                    column.Add(matrix[IRotatingGrateEncryption.NumberOfColumns - j - 1][i]);
                }
                newMatrix.Add(column);
            }

            return newMatrix;
        }

        public static void PrintLattice()
        {
            for (byte i = 0; i < IRotatingGrateEncryption.NumberOfLines; i++)
            {
                for (byte j = 0; j < IRotatingGrateEncryption.NumberOfColumns; j++)
                {
                    Console.Write(Lattice[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool CheckElementInLattice(byte line, byte column, char elem)
        {
            return Lattice[line][column] == elem;
        }
        
        
        internal static List<List<char>> MatrixInitialization(List<List<char>> matrix, char symbol)
        {
            for (byte i = 0; i < IRotatingGrateEncryption.NumberOfColumns; i++)
            {
                List<char> column = new();
                for (byte j = 0; j < IRotatingGrateEncryption.NumberOfLines; j++)
                {
                    column.Add(symbol);
                }
                matrix.Add(column);
            }

            return matrix;
        }
        
        internal static List<List<char>> MatrixInitialization(List<List<char>> matrix, string substring)
        {
            byte index = 0;
            for (byte i = 0; i < IRotatingGrateEncryption.NumberOfColumns; i++)
            {
                List<char> column = new();
                for (byte j = 0; j < IRotatingGrateEncryption.NumberOfLines; j++)
                {
                    char elem;
                    if (index > substring.Length)
                    {
                        elem = IRotatingGrateEncryption.EmptySymbol;
                    }
                    else
                    {
                        elem = substring[index];
                    }
                    column.Add(elem);
                    index++;
                }
                matrix.Add(column);
            }

            return matrix;
        }
        
        

        private static void FillTheLattice()
        {

            for (int turnCount = 0; turnCount < IRotatingGrateEncryption.NumberOfLines; turnCount++)
            {    
                byte number = 1;
                for (int i = 0; i < IRotatingGrateEncryption.NumberOfLines/2; i++)
                {
                    for (int j = 0; j < IRotatingGrateEncryption.NumberOfColumns/2; j++) 
                    {
                        Lattice[i][j] = char.Parse(number.ToString());
                        number++;
                    }
                }
                Lattice = RotateMatrix(Lattice);

            }
        }

        public abstract string GetWord();

        public RotatingGrateEncryption(string text, List<List<char>> coordinates)
        {
            this.Coordinates = coordinates;
            this.Text = InputTextProcessing(text);
        }

        private List<string> InputTextProcessing(string text)
        {
            var stringList = new List<string>();
            byte border = (IRotatingGrateEncryption.NumberOfColumns * IRotatingGrateEncryption.NumberOfLines),
                startPoint = 0, endPoint = border, length;
            bool flag = true;

            do
            {
                if (text.Length < border)
                {
                    flag = false;
                    endPoint = (byte) text.Length;
                }

                string substring = text.Substring(startPoint, endPoint);
                if (substring != "")
                {
                    stringList.Add(substring);
                }


                length = (byte) text.Length;
                text = (flag) ? text.Substring(endPoint, text.Length - endPoint) : text;

            } while ((length / border) > 0);

            return stringList;
        }
        


    }
}