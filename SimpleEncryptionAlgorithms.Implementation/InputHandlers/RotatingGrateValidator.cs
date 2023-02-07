using System;
using System.Collections.Generic;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RotatingGrate;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class RotatingGrateValidator : IValidator
    {
        public IEncryption CheckCreationEncryptionObject(string word)
        {
            byte line, column;
            List<List<char>> coordinates =
                RotatingGrateEncryption.MatrixInitialization(new(), IRotatingGrateEncryption.EmptySymbol);
                
            RotatingGrateEncryption.PrintLattice();
            
            for (byte i = 1; i < 5; i++)
            {
                while (true)
                {
                    Console.WriteLine("Введите координаты для числа " + i + ":");
                    while (true)
                    {
                        Console.Write("Значение строки: ");
                        if (Program.ProcessTheEnteredInformation(out line, 0, 3))
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Значение столбца: ");
                        if (Program.ProcessTheEnteredInformation(out column, 0, 3))
                        {
                            break;
                        }
                    }

                    if (RotatingGrateEncryption.CheckElementInLattice(line, column, char.Parse(i.ToString())))
                    {
                        coordinates[line][column] = IRotatingGrateEncryption.KeySymbol;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Число " + i +
                                          " не располагается по координатам [" + line + "][" + column + "]\n");
                    }
                    
                }
            }

            return new Encoder(word, coordinates);
        }
    }
}