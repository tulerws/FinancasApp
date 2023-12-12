using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Helpers
{
    /// <summary>
    /// Classe para criptografia padrão SHA1
    /// </summary>
    public class SHA1CryptoHelper
    {
        /// <summary>
        /// Método para receber um valor e retorna-lo criptografado em SHA1
        /// </summary>
        public static string Encrypt(string value)
        {
            using (var sha1 = SHA1.Create())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(value));

                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
