
namespace Taller5
{
    internal class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Anterior;
        public Nodo<T> Siguiente;

        public Nodo(T dato)
        {
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }
    }
}
