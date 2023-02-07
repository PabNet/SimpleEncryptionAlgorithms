using System;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;
using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RailwayFence;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class RailwayFenceValidator : IValidator
    {
        public IEncryption CheckCreationEncryptionObject(string word)
        {
            byte key;
            
            while (true)
            {
                Console.WriteLine("Введите значения ключа: ");
                
                if (Program.ProcessTheEnteredInformation(out key, 2, byte.MaxValue))
                {
                    break;
                }
            }
            
            return new Encoder(key, word);
        }
    }
}