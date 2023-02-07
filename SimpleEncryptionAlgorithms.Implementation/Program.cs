using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.ComplicatedCaesar;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.SimpleCaesar;
using SimpleEncryptionAlgorithms.Implementation.InputHandlers;

namespace SimpleEncryptionAlgorithms.Implementation
{
    static class Program
    {
        private static readonly Dictionary<MethodNumbers, string> EncryptionMethods;

        private enum MethodNumbers : byte
        {
            KeyPhrase = 1,
            RailwayFence,
            RotatingGrate,
            SimpleCaesar,
            ComplicatedCaesar
        }

        static Program()
        {
            EncryptionMethods = new Dictionary<MethodNumbers, string>()
            {
                [MethodNumbers.KeyPhrase] = "Ключевая фраза",
                [MethodNumbers.RailwayFence] = "Железнодорожная изгородь",
                [MethodNumbers.RotatingGrate] = "Поварачивающееся решётка",
                [MethodNumbers.SimpleCaesar] = "Цезарь(лёгкий)",
                [MethodNumbers.ComplicatedCaesar] = "Цезарь(сложный)"
            };
        }

        public static void Main()
        {
            while (true)
            {
                Console.Write("Введите слово: ");
                var word = Console.ReadLine();
                byte choice;

                Console.WriteLine();
                while (true)
                {
                    Console.WriteLine("Выберите метод шифрования");
                    foreach (var method in EncryptionMethods)
                    {
                        Console.WriteLine((byte) method.Key + "." + method.Value);
                    }

                    Console.Write("Ваш выбор: ");
                    if (ProcessTheEnteredInformation(out choice, (byte) EncryptionMethods.First().Key,
                        (byte) EncryptionMethods.Last().Key))
                    {
                        Console.WriteLine();
                        break;
                    }
                }

                switch (choice)
                {
                    case (byte) MethodNumbers.KeyPhrase:
                    {
                        var encoder = (EncryptionMethods.KeyPhrase.Encoder)
                            new KeyPhraseValidator().CheckCreationEncryptionObject(word);
                        string encryptionWord = encoder.GetWord();
                        Console.WriteLine("Слово до шифрования: " + word + "\nКлючевая фраза: " + encoder.KeyWord
                                          + "\nСлово после шифрования: " + encryptionWord +
                                          "\nСлово после дешифрования: "
                                          + new EncryptionMethods.KeyPhrase.Decoder(encoder.KeyWord, encryptionWord)
                                              .GetWord() + '\n');
                        break;
                    }
                    case (byte) MethodNumbers.RotatingGrate:
                    {
                        var encoder = (EncryptionMethods.RotatingGrate.Encoder)
                            new RotatingGrateValidator().CheckCreationEncryptionObject(word);
                        string encryptionWord = encoder.GetWord();
                        Console.WriteLine("Слово до шифрования: " + word
                                                                  + "\nСлово после шифрования: " + encryptionWord +
                                                                  "\nСлово после дешифрования: "
                                                                  + new EncryptionMethods.RotatingGrate.Decoder(
                                                                          encryptionWord, encoder.CoordinatesProperty)
                                                                      .GetWord() + '\n');
                        break;
                    }
                    case (byte) MethodNumbers.RailwayFence:
                    {
                        var encoder = (EncryptionMethods.RailwayFence.Encoder)
                            new RailwayFenceValidator().CheckCreationEncryptionObject(word);
                        string encryptionWord = encoder.GetWord();
                        Console.WriteLine("Слово до шифрования: " + word + "\nКлюч: " + encoder.Key
                                          + "\nСлово после шифрования: " + encryptionWord +
                                          "\nСлово после дешифрования: "
                                          + new EncryptionMethods.RailwayFence.Decoder(encoder.Key, encryptionWord)
                                              .GetWord() + '\n');
                        break;
                    }
                    case (byte) MethodNumbers.ComplicatedCaesar:
                    {
                        Coder encoder, decoder;
                        while (true)
                        {
                            encoder = (Coder) new ComplicatedCaesarValidator().CheckCreationEncryptionObject(word);
                            decoder = (Coder) new ComplicatedCaesarValidator().CheckCreationEncryptionObject(word);
                            if (ComplicatedCaesarValidator.CompareKeys(encoder, decoder))
                            {
                                break;
                            }

                            Console.WriteLine(
                                "Для использования данного метода шифрования, ключи должны быть взаимно простыми числами");
                        }

                        decoder.Word = encoder.GetWord();
                        Console.WriteLine("Слово до шифрования: " + word + "\nСлово после шифрования: " + decoder.Word
                                          + "\nСлово после дешифрования: " + decoder.GetWord());
                        break;
                    }
                    case (byte) MethodNumbers.SimpleCaesar:
                    {
                        var encoder = (Encoder)
                            new SimpleCaesarValidator().CheckCreationEncryptionObject(word);
                        string encryptionWord = encoder.GetWord();
                        Console.WriteLine("Слово до шифрования: " + word + "\nСлово после шифрования: " +
                                          encryptionWord +
                                          "\nСлово после дешифрования: "
                                          + new Decoder(encoder.Key, encryptionWord).GetWord());
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Желаете продолжить?\n1.Да\n2.Нет\nВаш Выбор: ");
                    if (ProcessTheEnteredInformation(out choice, 1, 2))
                    {
                        break;
                    }
                }

                if (choice is 2)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        internal static bool ProcessTheEnteredInformation(out byte choice, byte leftBorder, byte rightBorder)
        {
            choice = 0;
            bool check = false;
            try
            {
                if (byte.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice < leftBorder || choice > rightBorder)
                    {
                        throw new Exception("Введите число в нужном диапозоне!");
                    }

                    check = true;
                }
                else
                {
                    throw new Exception("Введите число!");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Некорректный ввод! " + exception.Message + '\n');
                check = false;
            }

            return check;
        }
    }
}