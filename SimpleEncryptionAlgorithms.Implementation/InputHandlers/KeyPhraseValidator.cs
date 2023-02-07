using System;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.KeyPhrase;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class KeyPhraseValidator : WordValidator, IValidator
    {
        public IEncryption CheckCreationEncryptionObject(string word)
        {
            string keyWord;
            while (true)
            {
                Console.Write("Введите ключевую фразу: ");
                keyWord = Console.ReadLine();

                try
                {
                    if (!CheckEnteredWord(keyWord))
                    {
                        throw new Exception("Вводите только буквы на кириллице!");
                    }

                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Некорректный ввод!" + exception.Message + '\n');
                }
            }
            
            return new Encoder(keyWord, word);
        }
    }
}