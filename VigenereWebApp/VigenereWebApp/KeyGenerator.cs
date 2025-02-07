using System;
using System.Text;

namespace VigenereWebApp
{
    public class KeyGenerator
    {
        public string GenerateKey(string text, string key)
        {
            int textLength = text.Length;
            int keyLength = key.Length;

            StringBuilder repeatedKey = new StringBuilder();
            int keyIndex = 0;

            for (int i = 0; i < textLength; i++)
            {
                repeatedKey.Append(key[keyIndex]);
                keyIndex = (keyIndex + 1) % keyLength;
            }

            return repeatedKey.ToString();
        }
    }

}
