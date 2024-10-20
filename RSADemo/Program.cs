using RSADemo;

// Generate RSA keys
var (publicKey, privateKey) = RSAEncryption.GenerateKeys();

Console.WriteLine("Public Key: " + publicKey.DisplayShortText());
Console.WriteLine("Private Key: " + privateKey.DisplayShortText());

// Original message
string message = "Hello, RSA encryption!";
Console.WriteLine("\nOriginal Message: " + message);

// Encrypt the message
byte[] encryptedMessage = RSAEncryption.EncryptData(message, publicKey);
Console.WriteLine("\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));

// Decrypt the message
string decryptedMessage = RSAEncryption.DecryptData(encryptedMessage, privateKey);
Console.WriteLine("\nDecrypted Message: " + decryptedMessage);

Console.ReadLine();