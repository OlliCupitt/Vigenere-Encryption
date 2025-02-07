using System;
using System.Text;

namespace VigenereWebApp
{
    public class VigenereCipher
    {
        private readonly KeyGenerator _keyGenerator;

        public VigenereCipher(KeyGenerator keyGenerator)
        {
            _keyGenerator = keyGenerator;
        }

        public string Encrypt(string text, string key)
        {
            string extendedKey = _keyGenerator.GenerateKey(text, key);
            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char textChar = text[i];
                char keyChar = extendedKey[i];


                if (char.IsLetter(textChar))                  // Check if both characters are letters
                {

                    textChar = char.ToUpper(textChar);                     // Ensure uppercase letters for encryption (can handle lowercase if needed)
                    keyChar = char.ToUpper(keyChar);

                    char encryptedChar = (char)((textChar + keyChar - 2 * 'A') % 26 + 'A');
                    encryptedText.Append(encryptedChar);
                }
                else
                {

                    encryptedText.Append(textChar);             // If non-letter, continue without encryption
                }
            }

            return encryptedText.ToString();
        }
        public string Decrypt(string text, string key)
        {
            string extendedKey = _keyGenerator.GenerateKey(text, key);
            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char textChar = text[i];
                char keyChar = extendedKey[i];


                if (char.IsLetter(textChar))                  // Check if both characters are letters
                {
                    textChar = char.ToUpper(textChar);
                    keyChar = char.ToUpper(keyChar);

                    char decryptedChar = (char)((textChar - keyChar + 26) % 26 + 'A');
                    decryptedText.Append(decryptedChar);
                }
                else
                {
                    decryptedText.Append(textChar);
                }
            }

            return decryptedText.ToString();
        }
    }


}
