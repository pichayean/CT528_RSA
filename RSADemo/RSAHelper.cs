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


    //public static string DisplayShortText(this string input)
    //{
    //    if (string.IsNullOrEmpty(input))
    //    {
    //        return string.Empty;
    //    }

    //    // Return the first 24 characters or the entire string if it's shorter
    //    return input.Length > 32 ? input.Substring(0, 32) + "...." : input;
    //}

    //// Method to format a base64 string into PEM format
    //private static string ToPem(string header, byte[] key)
    //{
    //    var base64 = Convert.ToBase64String(key);
    //    var sb = new StringBuilder();
    //    sb.AppendLine(header);
    //    for (int i = 0; i < base64.Length; i += 64)
    //    {
    //        sb.AppendLine(base64.Substring(i, Math.Min(64, base64.Length - i)));
    //    }
    //    sb.AppendLine($"-----END {header.Substring(11)}-----");
    //    return sb.ToString();
    //}

}