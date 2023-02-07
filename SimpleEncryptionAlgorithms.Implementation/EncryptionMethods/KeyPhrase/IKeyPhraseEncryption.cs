namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.KeyPhrase
{
    public interface IKeyPhraseEncryption : IEncryption
    {
        string KeyWord { get; }
    }
}