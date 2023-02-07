using System;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar.SimpleCaesar;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class SimpleCaesarValidator : WordValidator, IValidator
    {
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
                Console.WriteLine("Введите значения ключа: ");
                
                if (Program.ProcessTheEnteredInformation(out key, 1, ICaesarEncryption.LetterNumbers))
                {
                    break;
                }
            }
            
            return new Encoder(key, word);
        }
    }
}