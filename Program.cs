
using Taller5;

namespace Taller5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDoblementeLigada<int> lista =
                new ListaDoblementeLigada<int>();

            int opcion;
            int dato;

            do
            {
                Console.WriteLine("\n===== LISTAS DOBLEMENTE LIGADAS =====");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atras");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar grafico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese una opcion valida.");
                    opcion = -1;
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el numero: ");

                            if (int.TryParse(Console.ReadLine(), out dato))
                            {
                                lista.Adicionar(dato);
                                Console.WriteLine("Elemento agregado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Debe ingresar un numero entero.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("\nLista hacia adelante:");
                            lista.MostrarAdelante();
                            break;

                        case 3:
                            Console.WriteLine("\nLista hacia atras:");
                            lista.MostrarAtras();
                            break;

                        case 4:
                            lista.OrdenarDescendente();
                            Console.WriteLine("Lista ordenada descendentemente.");
                            lista.MostrarAdelante();
                            break;

                        case 5:
                            lista.MostrarModas();
                            break;

                        case 6:
                            lista.MostrarGrafico();
                            break;

                        case 7:
                            Console.Write("Ingrese el numero que desea buscar: ");

                            if (int.TryParse(Console.ReadLine(), out dato))
                            {
                                if (lista.Existe(dato))
                                {
                                    Console.WriteLine("El elemento si existe en la lista.");
                                }
                                else
                                {
                                    Console.WriteLine("El elemento no existe en la lista.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Debe ingresar un numero entero.");
                            }
                            break;

                        case 8:
                            Console.Write("Ingrese el numero que desea eliminar: ");

                            if (int.TryParse(Console.ReadLine(), out dato))
                            {
                                lista.EliminarUnaOcurrencia(dato);
                            }
                            else
                            {
                                Console.WriteLine("Debe ingresar un numero entero.");
                            }
                            break;

                        case 9:
                            Console.Write("Ingrese el numero que desea eliminar completamente: ");

                            if (int.TryParse(Console.ReadLine(), out dato))
                            {
                                lista.EliminarTodasLasOcurrencias(dato);
                            }
                            else
                            {
                                Console.WriteLine("Debe ingresar un numero entero.");
                            }
                            break;

                        case 0:
                            Console.WriteLine("Programa finalizado.");
                            break;

                        default:
                            Console.WriteLine("Opcion no valida. Intente nuevamente.");
                            break;
                    }
                }

            } while (opcion != 0);
        }
    }
}
