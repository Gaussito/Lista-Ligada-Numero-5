
using Taller5;

namespace Taller5
{
    internal class ListaDoblementeLigada<T>
        where T : IComparable<T>
    {
        private Nodo<T> primero;
        private Nodo<T> ultimo;

        public ListaDoblementeLigada()
        {
            primero = null;
            ultimo = null;
        }

        // 1. Adicionar en orden ascendente
        public void Adicionar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
            }
            else
            {
                Nodo<T> actual = primero;

                while (actual != null &&
                       dato.CompareTo(actual.Dato) >= 0)
                {
                    actual = actual.Siguiente;
                }

                if (actual == primero)
                {
                    nuevo.Siguiente = primero;
                    primero.Anterior = nuevo;
                    primero = nuevo;
                }
                else if (actual == null)
                {
                    ultimo.Siguiente = nuevo;
                    nuevo.Anterior = ultimo;
                    ultimo = nuevo;
                }
                else
                {
                    nuevo.Anterior = actual.Anterior;
                    nuevo.Siguiente = actual;

                    actual.Anterior.Siguiente = nuevo;
                    actual.Anterior = nuevo;
                }
            }
        }

        // 2. Mostrar hacia adelante
        public void MostrarAdelante()
        {
            if (primero == null)
            {
                Console.WriteLine("La lista esta vacia.");
            }
            else
            {
                Nodo<T> actual = primero;

                while (actual != null)
                {
                    Console.Write(actual.Dato + " ");

                    actual = actual.Siguiente;
                }

                Console.WriteLine();
            }
        }

        // 3. Mostrar hacia atras
        public void MostrarAtras()
        {
            if (ultimo == null)
            {
                Console.WriteLine("La lista esta vacia.");
            }
            else
            {
                Nodo<T> actual = ultimo;

                while (actual != null)
                {
                    Console.Write(actual.Dato + " ");

                    actual = actual.Anterior;
                }

                Console.WriteLine();
            }
        }

        // 4. Ordenar descendentemente
        public void OrdenarDescendente()
        {
            if (primero == null)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Nodo<T> actual = primero;

            while (actual != null)
            {
                Nodo<T> siguiente = actual.Siguiente;

                while (siguiente != null)
                {
                    if (actual.Dato.CompareTo(siguiente.Dato) < 0)
                    {
                        T temporal = actual.Dato;

                        actual.Dato = siguiente.Dato;
                        siguiente.Dato = temporal;
                    }

                    siguiente = siguiente.Siguiente;
                }

                actual = actual.Siguiente;
            }
        }

        // 5. Mostrar las modas
        public void MostrarModas()
        {
            if (primero == null)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            int mayorFrecuencia = 0;
            Nodo<T> actual = primero;

            while (actual != null)
            {
                int frecuencia = 0;
                Nodo<T> recorrido = primero;

                while (recorrido != null)
                {
                    if (actual.Dato.CompareTo(recorrido.Dato) == 0)
                    {
                        frecuencia++;
                    }

                    recorrido = recorrido.Siguiente;
                }

                if (frecuencia > mayorFrecuencia)
                {
                    mayorFrecuencia = frecuencia;
                }

                actual = actual.Siguiente;
            }

            actual = primero;

            Console.Write("La(s) moda(s) son: ");

            while (actual != null)
            {
                bool yaMostrada = false;
                Nodo<T> anterior = primero;

                while (anterior != actual)
                {
                    if (anterior.Dato.CompareTo(actual.Dato) == 0)
                    {
                        yaMostrada = true;
                        break;
                    }

                    anterior = anterior.Siguiente;
                }

                if (!yaMostrada)
                {
                    int frecuencia = 0;
                    Nodo<T> recorrido = primero;

                    while (recorrido != null)
                    {
                        if (actual.Dato.CompareTo(recorrido.Dato) == 0)
                        {
                            frecuencia++;
                        }

                        recorrido = recorrido.Siguiente;
                    }

                    if (frecuencia == mayorFrecuencia)
                    {
                        Console.Write(actual.Dato + " ");
                    }
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine();
        }

        // 6. Mostrar grafico de ocurrencias
        public void MostrarGrafico()
        {
            if (primero == null)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }

            Nodo<T> actual = primero;

            while (actual != null)
            {
                bool yaMostrado = false;
                Nodo<T> anterior = primero;

                while (anterior != actual)
                {
                    if (anterior.Dato.CompareTo(actual.Dato) == 0)
                    {
                        yaMostrado = true;
                        break;
                    }

                    anterior = anterior.Siguiente;
                }

                if (!yaMostrado)
                {
                    int frecuencia = 0;
                    Nodo<T> recorrido = primero;

                    while (recorrido != null)
                    {
                        if (actual.Dato.CompareTo(recorrido.Dato) == 0)
                        {
                            frecuencia++;
                        }

                        recorrido = recorrido.Siguiente;
                    }

                    Console.Write(actual.Dato + " ");

                    for (int i = 0; i < frecuencia; i++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }

                actual = actual.Siguiente;
            }
        }

        // 7. Buscar si existe un elemento
        public bool Existe(T dato)
        {
            Nodo<T> actual = primero;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        // Metodo auxiliar para desconectar un nodo
        private void Desconectar(Nodo<T> actual)
        {
            if (actual.Anterior == null)
            {
                primero = actual.Siguiente;
            }
            else
            {
                actual.Anterior.Siguiente = actual.Siguiente;
            }

            if (actual.Siguiente == null)
            {
                ultimo = actual.Anterior;
            }
            else
            {
                actual.Siguiente.Anterior = actual.Anterior;
            }

            actual.Anterior = null;
            actual.Siguiente = null;
        }

        // 8. Eliminar una ocurrencia
        public void EliminarUnaOcurrencia(T dato)
        {
            Nodo<T> actual = primero;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    Desconectar(actual);

                    Console.WriteLine(
                        "Se elimino una ocurrencia de " + dato);

                    return;
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine("El elemento no existe en la lista.");
        }

        // 9. Eliminar todas las ocurrencias
        public void EliminarTodasLasOcurrencias(T dato)
        {
            Nodo<T> actual = primero;
            int eliminados = 0;

            while (actual != null)
            {
                Nodo<T> siguiente = actual.Siguiente;

                if (actual.Dato.CompareTo(dato) == 0)
                {
                    Desconectar(actual);
                    eliminados++;
                }

                actual = siguiente;
            }

            if (eliminados > 0)
            {
                Console.WriteLine(
                    "Se eliminaron " + eliminados +
                    " ocurrencia(s) de " + dato);
            }
            else
            {
                Console.WriteLine(
                    "El elemento no existe en la lista.");
            }
        }
    }
}
