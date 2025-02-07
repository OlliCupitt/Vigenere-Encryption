using VigenereWebApp;

public class VigenereTest
{
    [Theory]
    [InlineData("KEY", "HELLO", "RIJVS")]
    [InlineData("KEY", "WORLD", "GSPVH")]
    public void Encrypt_ShouldReturnEncryptedText(string key, string plaintext, string expectedCiphertext)
    {
        var keyGenerator = new KeyGenerator(); // Create an instance of KeyGenerator
        var cipher = new VigenereCipher(keyGenerator);    // Pass it to the constructor

        var ciphertext = cipher.Encrypt(plaintext, key);    // Act

        Assert.Equal(expectedCiphertext, ciphertext);  // Assert
    }

    [Theory]
    [InlineData("KEY", "RIJVS", "HELLO")]
    [InlineData("KEY", "GSPVH", "WORLD")]
    public void Decrypt_ShouldReturnOriginalText(string key, string ciphertext, string expectedPlaintext)
    {
        var keyGenerator = new KeyGenerator();
        var cipher = new VigenereCipher(keyGenerator);

        var plaintext = cipher.Decrypt(ciphertext, key);

        Assert.Equal(expectedPlaintext, plaintext);
    }

    [Fact]
    public void Encrypt_EmptyString_ShouldReturnEmptyString()
    {
        var keyGenerator = new KeyGenerator();
        var cipher = new VigenereCipher(keyGenerator);

        var ciphertext = cipher.Encrypt(string.Empty, "KEY");

        Assert.Empty(ciphertext);
    }

    [Fact]
    public void Decrypt_EmptyString_ShouldReturnEmptyString()
    {
        var keyGenerator = new KeyGenerator();
        var cipher = new VigenereCipher(keyGenerator);

        var plaintext = cipher.Decrypt(string.Empty, "KEY");

        Assert.Empty(plaintext);
    }
}
