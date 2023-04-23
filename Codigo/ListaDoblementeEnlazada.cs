class ListaDoblementeEnlazada<T> : IDisposable, IEnumerable<T> where T : IComparable<T>
{
    public Nodo<T>? Primero { get; private set; }
    public Nodo<T>? Ultimo { get; private set; }
    public int Longitud { get; private set; }
    public bool Vacia => Longitud == 0;

    public ListaDoblementeEnlazada() {
        this.Primero = this.Ultimo = null;
        this.Longitud = 0;
    }
    public ListaDoblementeEnlazada(IEnumerable<T> secuencia) {
        this.Primero = null;
        this.Ultimo = null;
        this.Longitud = 0;

        foreach(T dato in secuencia)
            AñadeAlFinal(dato);
    }

    // JESUS 
    public void AñadeAntesDe(Nodo<T> nodo, Nodo<T> nuevo) {
        if(Vacia)
            throw new ListaException("La lista no puede estar vacía");

        nuevo.Anterior = nodo.Anterior;
        nuevo.Siguiente = nodo;
        if(nodo != Primero) nodo.Anterior.Siguiente = nuevo; // El siguiente de nodo anterior es el nuevo
        nodo.Anterior = nuevo;

        if(nodo == this.Primero)
            this.Primero = nuevo;
        this.Longitud++;
    }
    public void AñadeAntesDe(Nodo<T> nodo, T dato) {
        if(Vacia)
            throw new ListaException("La lista no puede estar vacía");

        Nodo<T> nuevo = new Nodo<T>(dato);
        nuevo.Anterior = nodo.Anterior;
        nuevo.Siguiente = nodo;
        if(nodo != Primero) nodo.Anterior.Siguiente = nuevo;
        nodo.Anterior = nuevo;

        if(nodo == this.Primero)
            this.Primero = nuevo;
        this.Longitud++;
    }
    public void AñadeDespuesDe(Nodo<T> nodo, Nodo<T> nuevo) {
        if(Vacia)
            throw new ListaException("La lista no puede estar vacía");

        nuevo.Anterior = nodo;
        nuevo.Siguiente = nodo.Siguiente;
        if(nodo != Ultimo) nodo.Siguiente.Anterior = nuevo; // El anterior de nodo siguiente es el nuevo
        nodo.Siguiente = nuevo;

        if(nodo == this.Ultimo)
            this.Ultimo = nuevo;
        this.Longitud++;
    }
    public void AñadeDespuesDe(Nodo<T> nodo, T dato) {
        if(Vacia)
            throw new ListaException("La lista no puede estar vacía");

        Nodo<T> nuevo = new Nodo<T>(dato);
        nuevo.Anterior = nodo;
        nuevo.Siguiente = nodo.Siguiente;
        if(nodo != Ultimo) nodo.Siguiente.Anterior = nuevo;
        nodo.Siguiente = nuevo;

        if(nodo == this.Ultimo)
            this.Ultimo = nuevo;
        this.Longitud++;
    }


    // ANTONIO 
    // public void AñadeAlPrincipio(NodoListaDoblementeEnlazada<T> nuevo)
    // public void AñadeAlPrincipio(T dato)
    // public void AñadeAlFinal(NodoListaDoblementeEnlazada<T> nuevo)
    // public void AñadeAlFinal(T dato)

    // BENJAMIN 
    // public void Borra(NodoListaDoblementeEnlazada<T> nodo)

    // DAVID 
    // public NodoListaDoblementeEnlazada<T> Busca(T dato)
    // public void EditaNodo(T datoAnterior, T datoNuevo, string dirección)

    public IEnumerator<T> GetEnumerator() => new Enumerador(Primero);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Clear() => Dispose();

    public void Dispose() {
        Nodo<T>? actual = Primero;
        Nodo<T>? siguiente;

        this.Primero = this.Ultimo = null;
        while(actual != null) {
            siguiente = actual.Siguiente;
            actual.Dispose();
            actual = siguiente;
        }
    }

    public override string ToString() {
        string mensaje = "";

        for (Nodo<T>? i = Primero; i != null; i = i.Siguiente)
            mensaje += $"[{i.Dato}]";
        mensaje += " - ";
        for (Nodo<T>? i = Ultimo; i != null; i = i.Siguiente)
            mensaje += $"[{i.Dato}]";

        return mensaje;
    }

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