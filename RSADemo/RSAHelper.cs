using System.Security.Cryptography;
using System.Text;
namespace RSADemo;
public static class RSAHelper
{
    // Generate RSA Keys
    public static (string publicKey, string privateKey) GenerateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider(1024))
        {
            rsa.PersistKeyInCsp = false;
            var publicKey = rsa.ExportRSAPublicKeyPem();
            var privateKey = rsa.ExportRSAPrivateKeyPem();
            return (publicKey, privateKey);
        }
    }

    // Encrypt Data with RSA
    public static byte[] EncryptData(string plainText, string publicKey)
    {
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedData;

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.PersistKeyInCsp = false;
            rsa.ImportFromPem(publicKey.ToCharArray());

            encryptedData = rsa.Encrypt(dataToEncrypt, false); 
        }

        return encryptedData;
    }

    // Decrypt Data with RSA
    public static string DecryptData(byte[] encryptedData, string privateKey)
    {
        byte[] decryptedData;

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.PersistKeyInCsp = false;
            rsa.ImportFromPem(privateKey.ToCharArray());

            decryptedData = rsa.Decrypt(encryptedData, false);
        }

        return Encoding.UTF8.GetString(decryptedData);
    }
}