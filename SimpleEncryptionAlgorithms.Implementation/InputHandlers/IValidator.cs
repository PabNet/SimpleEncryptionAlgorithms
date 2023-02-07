using SimpleEncryptionAlgorithms.Implementation.EncryptionMethods;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public interface IValidator
    {
        IEncryption CheckCreationEncryptionObject(string word);
        
    }
}