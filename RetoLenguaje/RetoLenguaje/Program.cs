using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        Dictionary<int, double> Notascandidatos = new Dictionary<int, double>();
        Dictionary<int, double> valorporcentual = new Dictionary<int, double>();
        static void Main(string[] args)
        {
            bool repetir = true;
            Program Call = new Program();
            while (repetir)
            {
                //Menu 
                Console.WriteLine("\nEs coja el perfil de la convocatoria del empleo para ingresar los datos de la evaluación de los candidatos");
                Console.WriteLine("\n===========================================================================================================");
                Console.WriteLine("\nPresione 1 para Desarrollador Senior ");
                Console.WriteLine("\nPresione 2 para Desarrollador Junior ");
                Console.WriteLine("\nPresione 3 para Desarrollador de Proyectos");
                Console.WriteLine("\n===========================================================================================================");
                // se escoje el tipo de candidato
                int caseSwitch = Int32.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        Call.Add();
                        Console.WriteLine("\n===========================================================================================================");
                        Console.WriteLine("\nAcontinuacion se mostrara las puntuaciones de los estudiantes de Mayor a Menor\n");
                        Call.ShowOrder();
                        repetir = false;
                        break;
                    case 2:
                        Call.Add();
                        Console.WriteLine("\n===========================================================================================================");
                        Console.WriteLine("\nAcontinuacion se mostrara las puntuaciones de los estudiantes de Mayor a Menor\n");
                        Call.ShowOrder();
                        repetir = false;
                        break;
                    case 3:
                        Call.Add();
                        Console.WriteLine("\n===========================================================================================================");
                        Console.WriteLine("\nAcontinuacion se mostrara las puntuaciones de los estudiantes de Mayor a Menor\n");
                        Call.ShowOrder();
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("\nValor invalido");
                        break;
                }
             }

            Console.Write("\nPresiona cualquier tecla para terminar ... ");
            Console.ReadKey();
        }

        public void Add()
        {
            // Ingresa los porcentajes de los 7 criterios de evaluación
            Console.WriteLine("\nAcontinuación debera ingresar los valores porcentuales de cada criterio (Escribir sin %)");
            bool condicion = true;
            do
            {
                double Suma = 0;
                for (int index = 1; index <= 7; index++)
                {
                    Console.WriteLine($"\nIngrese el valor porcentual del criterio {index} ");
                    double Porcentajes = double.Parse(Console.ReadLine());
                    //Si la suma de los porcentajes es menor o mayor a 100 cambia el valor de cada key
                    if (valorporcentual.ContainsKey(index))
                    {
                        valorporcentual[index] = Porcentajes;
                    }
                    else
                    {
                        valorporcentual.Add(index, Porcentajes);
                    }
                    Suma += Porcentajes;
                }
                if (Suma == 100)
                {
                    condicion = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nLos valores ingresados no son correctos por favor ingreselos nuevamente");
                }
            }
            while (condicion);
            //Ingresa y calcula la nota de los candidatos 
            Console.WriteLine("\n===========================================================================================================");
            Console.WriteLine("\nIngrese el numero de candidatos al puesto");
            int Ncandidato = Int32.Parse(Console.ReadLine());
            for (int index = 1; index <= Ncandidato; index++)
            {
                //Adquiere el indicador de cada candidato
                Console.WriteLine($"\nPor favor ingrese el numero de cedula del candidato: {index}");
                int Ncedula = Int32.Parse(Console.ReadLine());
                double SumaNotas = 0;
                //Adquiere la nota y realiza el calculo para hallar la nota total  apartir de las notas de los 7 criterios de evaluación (siendo 1 minima y 10 maxima)
                for (int indexs = 1; indexs <= 7; indexs++)
                {
                    Console.WriteLine($"\nIngrese la nota {indexs} ");
                    int Calificacion = Int32.Parse(Console.ReadLine());
                    if (Calificacion <= 10)
                    {
                        double CalculoNotas = ((70 * valorporcentual[indexs] / 100) * Calificacion) / 10;
                        SumaNotas += CalculoNotas;
                    }
                    else
                    {
                        Console.WriteLine("\nIngrese nuevamente la calificacion");
                        indexs = indexs - 1;
                    }
                }
                Notascandidatos.Add(Ncedula, SumaNotas);
            }
        }

        public void ShowOrder()
        {
            try
            {
                //Transforma los valores del diccionario a un Arreglo
                double[] myArray = Notascandidatos.Values.ToArray();
                //Ordenamiento con Insertion
                for (int k = 1; k <= myArray.Length - 1; k++) // k=1 ya que se asume que la posición 0 está ordenada
                {
                    double temp = myArray[k];
                    int j = k - 1;
                    while (j >= 0 && temp > myArray[j])
                     {
                        myArray[j + 1] = myArray[j];
                        j = j - 1;
                     }
                    myArray[j + 1] = temp;
                }
                //Muestra el diccionario ordenado de Mayor a Menor
                for (int i = 0; i < myArray.Length; i++)
                {
                    int candidato = Notascandidatos.FirstOrDefault(x => x.Value == myArray[i]).Key;
                    Console.WriteLine("La nota del candidato {0} es {1}", candidato, myArray[i]);
                }
            }
            catch
            {
                //Ordenamiento con OrderByDescending
                Func<KeyValuePair<int, double>, double> predicated = delegate (KeyValuePair<int, double> item)
                {
                    return item.Value;
                };
                //Muestra y ordena el diccionario ordenado de Mayor a Menor
                foreach (KeyValuePair<int, double> entry in Notascandidatos.OrderByDescending(predicated))
                {
                    Console.WriteLine(entry);
                }
            }
            
        }
    }
}