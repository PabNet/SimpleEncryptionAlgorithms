namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.Caesar
{
    public interface ICaesarEncryption : IEncryption
    {
        const byte LetterNumbers = 67;
        
        byte Key { get; }
    }
}