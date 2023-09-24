using AutoMapper;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.DataModel;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IMS.Api.Common.Extensions
{
    public static class ExtensionMethod
    {
        public static void AddRange<T>(this DataRowCollection rows, IEnumerable<T> data, Func<T, object[]> convertEntity = null)
        {
            if (convertEntity == null)
            {
                foreach (T entity in data)
                {
                    rows.Add(entity);
                }
            }
            else
            {
                foreach (object[] row in data.Select(convertEntity))
                {
                    rows.Add(row);
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public static T MapTo<T>(this object map)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap(map.GetType(), typeof(T)));
            IMapper mapper = config.CreateMapper();

            T map1 = mapper.Map<T>(map);
            return map1;
        }

        public static string ToJson(this object value)
        {
            if (value == null) return null;

            string json = JsonConvert.SerializeObject(value);
            return json;


        }
        [ExcludeFromCodeCoverage]
        public static T FromJson<T>(this string obj)
        {
            try
            {
                T cObj = JsonConvert.DeserializeObject<T>(obj);
                return cObj;
            }
            catch (Exception)
            {
                return default;
            }
        }

        [ExcludeFromCodeCoverage]
        public static string ToTitleString(this string str)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Length == 1)
            {
                return str.ToUpper();
            }

            string resultString = str[0].ToString().ToUpper();
            for (int i = 1; i < str.Length; i++)
            {
                if (IsUppercaseLetter(str[i]) && (IsLowercaseLetter(str[i - 1]) || str.Length > i + 1 && IsLowercaseLetter(str[i + 1])))
                {
                    resultString += " ";
                }
                resultString += str[i];
            }

            return resultString;
        }

        private static bool IsUppercaseLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
        private static bool IsLowercaseLetter(char c)
        {
            return c >= 'a' && c <= 'z';
        }
        [ExcludeFromCodeCoverage]
        public static object GetValueNull(this PropertyInfo pInfo, object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return pInfo.GetValue(obj);
        }

        [ExcludeFromCodeCoverage]
        public static string ByteToString(this byte[] buff)
        {
            string sbinary = "";
            try
            {
                for (int i = 0; i < buff.Length; i++)
                {
                    sbinary += buff[i].ToString("X2");
                }
                return sbinary;
            }
            catch (Exception)
            {
                return sbinary;
            }
        }

        public static string MapPath(this string s, string path)
        {

            path = path.Replace("~", "").Replace(@"/", @"\");


            return s + path;//Path.Combine(s, path);


        }
        [ExcludeFromCodeCoverage]
        public static bool Mod10Luhn(this string pan)
        {
            bool isvalid = false;
            try
            {
                if (!string.IsNullOrEmpty(pan))
                {
                    int sumOfDigits = pan.Where((e) => e >= '0' && e <= '9')
                               .Reverse()
                               .Select((e, i) => (e - 48) * (i % 2 == 0 ? 1 : 2))
                               .Sum((e) => e / 10 + e % 10);
                    isvalid = sumOfDigits % 10 == 0;
                }
                return isvalid;
            }
            catch (Exception)
            {
                return isvalid;
            }
        }

        public static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }

        public static string EncryptPassword(this string password)
        {
            StringBuilder sb = new StringBuilder(password);

            for (int i = 2; i < password.Length - 2; i++)
            {
                sb[i] = '*';
                password = sb.ToString();
            }
            return password;
        }

        public static string EncryptString(this string plainText, string key = null)
        {
            byte[] iv = new byte[16];
            byte[] array;
            byte[] key1 = new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0x00 };


            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(key) ? APIConfig.Configuration?.GetSection("Encrption")["KEY"] : key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(this string cipherText, string key = null)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(string.IsNullOrEmpty(key) ? APIConfig.Configuration?.GetSection("Encrption")["KEY"] : key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        #region Generate password
        public static string GenPassword(bool IsEncrypted = false)
        {
            string password = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            password = builder.ToString();

            if (IsEncrypted)
                return password.MD5Encrypt();
            else
                return password;
        }


        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        #endregion


        public static string MD5Encrypt(this string PlainText)
        {
            if (!string.IsNullOrEmpty(PlainText))
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] encrypt;
                UTF8Encoding encode = new UTF8Encoding();

                //encrypt the given password string into Encrypted data  
                encrypt = md5.ComputeHash(encode.GetBytes(PlainText));
                StringBuilder encryptdata = new StringBuilder();

                //Create a new string by using the encrypted data  
                for (int i = 0; i < encrypt.Length; i++)
                {
                    encryptdata.Append(encrypt[i].ToString());
                }
                return encryptdata.ToString();
            }
            else
                return string.Empty;
        }

        public static string GenerateJSONWebToken(User userView, string ExpiryMinutes)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(APIConfig.Configuration?.GetSection("JWT")["KEY"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {

                    new Claim(ClaimTypes.NameIdentifier, userView.UserId.ToString()),
                    new Claim(ClaimTypes.Email, userView.Email),
                    new Claim(ClaimTypes.GivenName, userView.FirstName+" "+userView.LastName),
                    new Claim(ClaimTypes.Sid, userView.UserId.ToString()),
                    new Claim(ClaimTypes.Role, userView.UserRoleId.ToString()),
                    new Claim(ClaimTypes.PrimaryGroupSid, userView.CompanyId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ExpiryMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string CreateEmailBody(string TemplatePath)
        {
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(TemplatePath))
            {
                body = reader.ReadToEnd();
            }
            return body;

        }

        public static int Generate5DigitOTP()
        {
            Random _random = new Random();
            return _random.Next(10000, 100000); // Generates a random number between 10000 and 99999
        }

        public static string ConvertToBase64(this Stream stream)
        {
            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return Convert.ToBase64String(bytes);
        }

     

    }
}
