using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptLiblary
{
    /*****************************************************************
	 * CrossPlatform CryptLib
	 * 
	 * <p>
	 * This cross platform CryptLib uses AES 256 for encryption. This library can
	 * be used for encryptoion and de-cryption of string on iOS, Android and Windows
	 * platform.<br/>
	 * Features: <br/>
	 * 1. 256 bit AES encryption
	 * 2. Random IV generation. 
	 * 3. Provision for SHA256 hashing of key. 
	 * </p>
	 * 
	 * @since 1.0
	 * @author navneet
	 *****************************************************************/
    public class CryptLib
    {
        private UTF8Encoding _enc;
        private RijndaelManaged _rcipher;
        private byte[] _key, _pwd, _ivBytes, _iv;

        private int IvLength = 16;
        private string _keyString = "";
        private string _keyTextConfig = "LEDUCANHDEPTRAI";
        private string _ivKeyConfig = "x3yKa2HlrQLCnYiA";

        #region Singleton
        private static CryptLib _instance;
        public static CryptLib Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CryptLib();
                return _instance;
            }
        }
        #endregion

        /***
         * Encryption mode enumeration
         */
        private enum EncryptMode { ENCRYPT, DECRYPT };

        static readonly char[] CharacterMatrixForRandomIVStringGeneration = {
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
			'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
			'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
		};



        /**
         * This function generates random string of the given input length.
         * 
         * @param _plainText
         *            Plain text to be encrypted
         * @param _key
         *            Encryption Key. You'll have to use the same key for decryption
         * @return returns encrypted (cipher) text
         */
        private string GenerateRandomIV(int length)
        {
            //char[] _iv = new char[length];
            //byte[] randomBytes = new byte[length];

            //using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(randomBytes);
            //    //Fills an array of bytes with a cryptographically strong sequence of random values. 
            //}

            //for (int i = 0; i < _iv.Length; i++)
            //{
            //    int ptr = randomBytes[i] % CharacterMatrixForRandomIVStringGeneration.Length;
            //    _iv[i] = CharacterMatrixForRandomIVStringGeneration[ptr];
            //}

            //return new string(_iv);
            return _ivKeyConfig;
        }



        public CryptLib()
        {
            _enc = new UTF8Encoding();
            _rcipher = new RijndaelManaged();
            _rcipher.Mode = CipherMode.CBC;
            _rcipher.Padding = PaddingMode.PKCS7;
            _rcipher.KeySize = 256;
            _rcipher.BlockSize = 128;
            _key = new byte[32];
            _iv = new byte[_rcipher.BlockSize / 8]; //128 bit / 8 = 16 bytes
            _ivBytes = new byte[16];
            _keyString = GetHashSha256(_keyTextConfig, 32);
        }

        /**
         * 
         * @param _inputText
         *            Text to be encrypted or decrypted
         * @param _encryptionKey
         *            Encryption key to used for encryption / decryption
         * @param _mode
         *            specify the mode encryption / decryption
         * @param _initVector
         * 			  initialization vector
         * @return encrypted or decrypted string based on the mode
        */
        private String encryptDecrypt(string _inputText, string _encryptionKey, EncryptMode _mode, string _initVector)
        {

            string _out = "";// output string
            //_encryptionKey = MD5Hash (_encryptionKey);
            _pwd = Encoding.UTF8.GetBytes(_encryptionKey);
            _ivBytes = Encoding.UTF8.GetBytes(_initVector);

            int len = _pwd.Length;
            if (len > _key.Length)
            {
                len = _key.Length;
            }
            int ivLenth = _ivBytes.Length;
            if (ivLenth > _iv.Length)
            {
                ivLenth = _iv.Length;
            }

            Array.Copy(_pwd, _key, len);
            Array.Copy(_ivBytes, _iv, ivLenth);
            _rcipher.Key = _key;
            _rcipher.IV = _iv;

            if (_mode.Equals(EncryptMode.ENCRYPT))
            {
                //AesEncrypt
                byte[] plainText = _rcipher.CreateEncryptor().TransformFinalBlock(_enc.GetBytes(_inputText), 0, _inputText.Length);
                _out = Convert.ToBase64String(plainText);
            }
            if (_mode.Equals(EncryptMode.DECRYPT))
            {
                //AesDecrypt
                byte[] plainText = _rcipher.CreateDecryptor().TransformFinalBlock(Convert.FromBase64String(_inputText), 0, Convert.FromBase64String(_inputText).Length);
                _out = _enc.GetString(plainText);
            }
            _rcipher.Dispose();
            return _out;// return encrypted/decrypted string
        }

        /**
         * This function encrypts the plain text to cipher text using the key
         * provided. You'll have to use the same key for decryption
         * 
         * @param _plainText
         *            Plain text to be encrypted
         * @param _key
         *            Encryption Key. You'll have to use the same key for decryption
         * @return returns encrypted (cipher) text
         */
        public string AesEncrypt(string _plainText)
        {
            return encryptDecrypt(_plainText, _keyString, EncryptMode.ENCRYPT, GenerateRandomIV(IvLength));
        }

        /***
         * This funtion decrypts the encrypted text to plain text using the key
         * provided. You'll have to use the same key which you used during
         * encryprtion
         * 
         * @param _encryptedText
         *            Encrypted/Cipher text to be decrypted
         * @param _key
         *            Encryption key which you used during encryption
         * @return encrypted value
         */

        public string AesDecrypt(string _encryptedText)
        {
            return encryptDecrypt(_encryptedText, _keyString, EncryptMode.DECRYPT, GenerateRandomIV(IvLength));
        }

        /***
         * This function decrypts the encrypted text to plain text using the key
         * provided. You'll have to use the same key which you used during
         * encryption
         * 
         * @param _encryptedText
         *            Encrypted/Cipher text to be decrypted
         * @param _key
         *            Encryption key which you used during encryption
         */
        private string GetHashSha256(string text, int length)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x); //covert to hex string
            }
            if (length > hashString.Length)
                return hashString;
            else
                return hashString.Substring(0, length);
        }

        public string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }
    }
}
