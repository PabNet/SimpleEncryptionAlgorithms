namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods
{
    public interface IEncryption
    {
        const char EmptySymbol = '~';
        string GetWord();
        
    }
}