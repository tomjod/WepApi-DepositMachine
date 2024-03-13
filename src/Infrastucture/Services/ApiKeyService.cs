using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ApiKeyService : IApiKeyService
    {
        public string GenerateApiKey()
        {
            // Largo de la clave (64 bytes)
            var length = 64;

            // Inicializar generator cryptográfico 
            var rng = RandomNumberGenerator.Create();

            // Buffer para almacenar números random 
            var buff = new byte[length];

            // Llenar buffer con números aleatorios
            rng.GetBytes(buff);

            // Convertir buffer a string hexadecimal
            var str = BitConverter.ToString(buff);

            // Remover guiones 
            str = str.Replace("-", "");

            // Rellenar con ceros a izquierda si es menor a 64 chars
            if (str.Length < length)
            {
                str.PadLeft(length, '0');
            }

            return str;
        }

        public string HashApiKey(string apiKey)
        {
            // Generar salt y hash
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12); 
            string hashedKey = BCrypt.Net.BCrypt.HashPassword(apiKey, salt);

            return hashedKey;
        }
    }
}
