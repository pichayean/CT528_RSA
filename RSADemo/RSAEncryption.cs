using System.Security.Cryptography;
using System.Text;
namespace RSADemo;
public static class RSAEncryption
{
    // Generate RSA Keys
    public static (string publicKey, string privateKey) GenerateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            rsa.PersistKeyInCsp = false; // Do not store the keys in a container
            var publicKey = Convert.ToBase64String(rsa.ExportCspBlob(false)); // Public key
            var privateKey = Convert.ToBase64String(rsa.ExportCspBlob(true)); // Private key
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
            rsa.ImportCspBlob(Convert.FromBase64String(publicKey)); // Import the public key

            encryptedData = rsa.Encrypt(dataToEncrypt, false); // False indicates PKCS#1 v1.5 padding
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
            rsa.ImportCspBlob(Convert.FromBase64String(privateKey)); // Import the private key

            decryptedData = rsa.Decrypt(encryptedData, false); // False indicates PKCS#1 v1.5 padding
        }

        return Encoding.UTF8.GetString(decryptedData);
    }


    public static string DisplayShortText(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        // Return the first 24 characters or the entire string if it's shorter
        return input.Length > 32 ? input.Substring(0, 32) + "...." : input;
    }

}