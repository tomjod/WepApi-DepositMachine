using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedKernel
{
    public sealed class RutValidator
    {
        public RutValidator() { }

        public static bool validate(string rut)
        {
            if (Regex.IsMatch(rut, "^[0-6]"))
            {
                return false;
            }

            if (rut.Length < 9)
            {
                return false;
            }

            var constNumber = 11;

            // Extraigo los numeros que estan antes del guion.
            var rutWithoutDigitValidator = rut.Substring(0, rut.Length - 1);

            // Convierto la cadena en un array de enteros
            int[] array = rutWithoutDigitValidator.Select(c => int.Parse(c.ToString())).ToArray();

            // Reverso el array
            var arrayr = array.Reverse().ToArray();

            // Creo una serie de array de numeros constantes
             int[] serie = [2, 3, 4, 5, 6, 7];

            // Si el length de la serie y el array del rut es diferente
            // entonces agrego al final del array de serie los numeros
            // que estan en el inicio de su index empezando desde index 0
            if (arrayr.Length != serie.Length)
            {
                int i = 0;

                while (array.Length != serie.Length)
                {
                    serie = serie.Append(serie[i]).ToArray();
                    i++;
                }
            }

            // Variable para guardar la suma de la multiplicacion de los numeros  de los arrays
            var arraySum = 0;

            // Bucle para mutiplicar cada indice de los arrays con su par
            // y guardarlo en la variable arraySum
            for (int i = 0; i < arrayr.Length; i++)
            {
                arraySum += arrayr[i] * serie[i];
            }

            // Se divide el resultado de la suma con el numero constante 
            var result = (arraySum / constNumber);

            // El resultado de la division se multiplica por la constante
            result *= constNumber;

            // a la suma de la multiplicacion de los arrays se le resta el resultado de la division
            result = (arraySum - result);

            // Al numero constante se le resta el resultado anterior y da el resultado final.
            result = (constNumber - result);

            // Se convierte el resultado en string
            var resultString = result.ToString();

            // Si el resultado es 11 se convierte el resultado en 0
            if (resultString == "11")
            {
                resultString = "0";
            }

            // Si el resultado es 10 se convierte el resultado en K
            if (resultString == "10")
            {
                resultString = "K";
            }

            // Se chequea el resultado obtenido con el digito virificador que proporciono el usuario
            if (!rut.EndsWith(resultString))
            {
                return false;
            }

            return true;

        }
    }
}
