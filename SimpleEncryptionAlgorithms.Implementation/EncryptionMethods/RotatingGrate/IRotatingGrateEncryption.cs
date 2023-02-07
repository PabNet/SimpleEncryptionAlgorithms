namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RotatingGrate
{
    public interface IRotatingGrateEncryption : IEncryption
    {
        const byte NumberOfColumns = 4, NumberOfLines = 4;

        const char KeySymbol = '1';
        
    }
}