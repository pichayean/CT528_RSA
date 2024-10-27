using RSADemo;

// Generate RSA keys
var (publicKey, privateKey) = RSAHelper.GenerateKeys();
Console.WriteLine("\n\nPublic Key: " + publicKey);
Console.WriteLine("\n\nPrivate Key: " + privateKey);

// Original message
string message = "Hello, RSA encryption!";
Console.WriteLine("\nOriginal Message: " + message);

// Encrypt the message
byte[] encryptedMessage = RSAHelper.EncryptData(message, publicKey);
Console.WriteLine("\n\nEncrypted Message: " + Convert.ToBase64String(encryptedMessage));

// Decrypt the message
string decryptedMessage = RSAHelper.DecryptData(encryptedMessage, privateKey);
Console.WriteLine("\n\nDecrypted Message: " + decryptedMessage);

Console.ReadLine();