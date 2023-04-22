class ListaDoblementeEnlazada<T> : IEnumerable<T> where T : IComparable<T>
{
    public Nodo<T> Primero { get; private set; }
    public Nodo<T> Ultimo { get; private set; }
    public int Longitud { get; private set; }

    public ListaDoblementeEnlazada() {
        this.Primero = this.Ultimo = null;
        this.Longitud = 0;
    }

    public IEnumerator<T> GetEnumerator() => new Enumerador(Primero);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class Enumerador : IEnumerator<T>, IDisposable {
        private Nodo<T>? It { get; set; }
        private Nodo<T>? Primero { get; set; }

        public Enumerador(Nodo<T> Primero) {
            this.Primero = Primero;
            Reset();
        }

        public void Reset() => It = null;
        public T Current => It!.Dato;
        object IEnumerator.Current => Current;

        public bool MoveNext() {
            bool puedoIterar = It == null && Primero != null || It != null && It.Siguiente != null;
            if(puedoIterar)
                It = It == null ? Primero : It.Siguiente;

            return puedoIterar;
        }

        public void Dispose() {
            Primero = null;
            It = null;
        }
    }
}