namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RailwayFence
{
    public interface IRailwayFenceEncryption : IEncryption
    {
        const char TemplateSymbol = 'X';

        static bool Flag;

        void PrintEncryptionScheme();

        byte Key { get; }
    }
}