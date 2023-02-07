using System;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.ComplicatedCaesar;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class ComplicatedCaesarValidator : WordValidator, IValidator
    {
        private static bool flag = true;
        
        public IEncryption CheckCreationEncryptionObject(string word)
        {
            if (!CheckEnteredWord(word))
            {
                Console.WriteLine("Для шифрования данным методом нужно вводить только буквы на кириллице!\n");
                
                Program.Main();
            }

            byte key;

            while (true)
            {
                Console.WriteLine($"Введите значения ключа {((flag) ? "шифрования" : "дешифрования")}: ");

                if (Program.ProcessTheEnteredInformation(out key, 1, ICaesarEncryption.LetterNumbers))
                {
                    flag = (!flag);
                    break;
                }
            }

            return new Coder(key, word);
        }

        public static bool CompareKeys(Coder encoder, Coder decoder)
        {
            return CheckNumbersAgainstFormula(encoder.Key, decoder.Key) &&
                   CheckNumbersForCoprime(encoder.Key, decoder.Key);
        }

        private static bool CheckNumbersForCoprime(byte enKey, byte deKey)
        {
            return (enKey == deKey) 
                ? enKey == 1 
                : (enKey > deKey) 
                    ? CheckNumbersForCoprime(Convert.ToByte(enKey - deKey), deKey) 
                    : CheckNumbersForCoprime(Convert.ToByte(deKey - enKey), enKey);
        }

        private static bool CheckNumbersAgainstFormula(byte enKey, byte deKey)
        {
            return (enKey * deKey) % ICaesarEncryption.LetterNumbers == 1;
        }
    }
}