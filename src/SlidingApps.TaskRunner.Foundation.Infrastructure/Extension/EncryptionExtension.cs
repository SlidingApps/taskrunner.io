
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace SlidingApps.TaskRunner.Foundation.Infrastructure.Extension
{
    public static class EncryptionExtension
    {
        private const int BASE58_CHECK_SUM_SIZE = 4;
        private const string BASE58_DIGITS = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static string ToSHA256(this string value)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] sha256Bytes = Encoding.Default.GetBytes(value);
            byte[] hash = sha256.ComputeHash(sha256Bytes);
            string result = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                result += hash[i].ToString("X");
            }

            return result;
        }

        // Use AesCryptoServiceProvider or TripleDESCryptoServiceProvider?
        private static SymmetricAlgorithm _cryptoService = new AesCryptoServiceProvider();

        public static string Encrypt(this string text, string key, string vector)
        {
            return Encrypt(text, key.ToBytes(), vector.ToBytes());
        }

        // vector and key have to match between encryption and decryption
        public static string Encrypt(this string text, byte[] key, byte[] vector)
        {
            return Transform(text, _cryptoService.CreateEncryptor(key, vector));
        }

        public static string Decrypt(this string text, string key, string vector)
        {
            return Decrypt(text, key.ToBytes(), vector.ToBytes());
        }

        // vector and key have to match between encryption and decryption
        public static string Decrypt(this string text, byte[] key, byte[] vector)
        {
            return Transform(text, _cryptoService.CreateDecryptor(key, vector));
        }

        private static string Transform(string text, ICryptoTransform cryptoTransform)
        {
            MemoryStream stream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write);

            byte[] input = Encoding.Default.GetBytes(text);

            cryptoStream.Write(input, 0, input.Length);
            cryptoStream.FlushFinalBlock();

            return Encoding.Default.GetString(stream.ToArray());
        }

        /// <summary>
        /// Encodes data with a 4-byte checksum
        /// </summary>
        /// <param name="data">Data to be encoded</param>
        /// <returns></returns>
        public static string ToBase58(this string data)
        {
            return ToBase58Plain(AddCheckSum(data.ToBytes()));
        }

        /// <summary>
        /// Encodes data with a 4-byte checksum
        /// </summary>
        /// <param name="data">Data to be encoded</param>
        /// <returns></returns>
        public static string ToBase58(this byte[] data)
        {
            return ToBase58Plain(AddCheckSum(data));
        }

        public static string ToBase58Plain(this string data)
        {
            return ToBase58Plain(data.ToBytes());
        }

        /// <summary>
        /// Encodes data in plain Base58, without any checksum.
        /// </summary>
        /// <param name="data">The data to be encoded</param>
        /// <returns></returns>
        public static string ToBase58Plain(this byte[] data)
        {
            // Decode byte[] to BigInteger
            var intData = data.Aggregate<byte, BigInteger>(0, (current, t) => current * 256 + t);

            // Encode BigInteger to Base58 string
            var result = string.Empty;
            while (intData > 0)
            {
                var remainder = (int)(intData % 58);
                intData /= 58;
                result = BASE58_DIGITS[remainder] + result;
            }

            // Append `1` for each leading 0 byte
            for (var i = 0; i < data.Length && data[i] == 0; i++)
            {
                result = '1' + result;
            }

            return result;
        }

        /// <summary>
        /// Decodes data in Base58Check format (with 4 byte checksum)
        /// </summary>
        /// <param name="data">Data to be decoded</param>
        /// <returns>Returns decoded data if valid; throws FormatException if invalid</returns>
        public static byte[] FromBase58(this string data)
        {
            var dataWithCheckSum = FromBase58Plain(data);
            var dataWithoutCheckSum = VerifyAndRemoveCheckSum(dataWithCheckSum);

            if (dataWithoutCheckSum == null)
            {
                throw new FormatException("Base58 checksum is invalid");
            }

            return dataWithoutCheckSum;
        }

        /// <summary>
        /// Decodes data in plain Base58, without any checksum.
        /// </summary>
        /// <param name="data">Data to be decoded</param>
        /// <returns>Returns decoded data if valid; throws FormatException if invalid</returns>
        public static byte[] FromBase58Plain(this string data)
        {
            // Decode Base58 string to BigInteger 
            BigInteger intData = 0;
            for (var i = 0; i < data.Length; i++)
            {
                var digit = BASE58_DIGITS.IndexOf(data[i]); //Slow

                if (digit < 0)
                {
                    throw new FormatException(string.Format("Invalid Base58 character `{0}` at position {1}", data[i], i));
                }

                intData = intData * 58 + digit;
            }

            // Encode BigInteger to byte[]
            // Leading zero bytes get encoded as leading `1` characters
            var leadingZeroCount = data.TakeWhile(c => c == '1').Count();
            var leadingZeros = Enumerable.Repeat((byte)0, leadingZeroCount);
            var bytesWithoutLeadingZeros =
              intData.ToByteArray()
              .Reverse()// to big endian
              .SkipWhile(b => b == 0);//strip sign byte
            var result = leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();

            return result;
        }

        private static byte[] AddCheckSum(byte[] data)
        {
            var checkSum = GetCheckSum(data);
            var dataWithCheckSum = ArrayHelpers.ConcatArrays(data, checkSum);

            return dataWithCheckSum;
        }

        //Returns null if the checksum is invalid
        private static byte[] VerifyAndRemoveCheckSum(byte[] data)
        {
            var result = ArrayHelpers.SubArray(data, 0, data.Length - BASE58_CHECK_SUM_SIZE);
            var givenCheckSum = ArrayHelpers.SubArray(data, data.Length - BASE58_CHECK_SUM_SIZE);
            var correctCheckSum = GetCheckSum(result);

            return givenCheckSum.SequenceEqual(correctCheckSum) ? result : null;
        }

        private static byte[] GetCheckSum(byte[] data)
        {
            SHA256 sha256 = new SHA256Managed();
            var hash1 = sha256.ComputeHash(data);
            var hash2 = sha256.ComputeHash(hash1);

            var result = new byte[BASE58_CHECK_SUM_SIZE];
            Buffer.BlockCopy(hash2, 0, result, 0, result.Length);

            return result;
        }
    }
}
