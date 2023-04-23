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
    public void AñadeAlPrincipio(Nodo<T> nuevo)
        {
            nuevo.Siguiente = Primero;
            if (Primero != null) { Primero.Anterior = nuevo; }

            Primero = nuevo;

            if (Vacia)
            { Ultimo = nuevo; }
            Longitud++;
        }
        public void AñadeAlPrincipio(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            nuevo.Siguiente = Primero;
            Primero = nuevo;
            if (Vacia) Ultimo = nuevo;
            Longitud++;
        }
        public void AñadeAlFinal(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (Longitud == 0)
            {
                Primero = nuevo;
            }
            else
            {
                Ultimo!.Siguiente = nuevo;
                nuevo.Anterior = Ultimo;
            }
            Ultimo = nuevo;
            Longitud++;
        }
        public void AñadeAlFinal(Nodo<T> nuevo)
        {

            if (Vacia)
            { Primero = nuevo; }
            else
                Ultimo!.Siguiente = nuevo;
            nuevo.Anterior = Ultimo;

            Ultimo = nuevo;
            Longitud++;
        }


    // DAVID 
    // public NodoListaDoblementeEnlazada<T> Busca(T dato)
    public Nodo<T> Busca(T dato)
{
    Nodo<T> actual = Primero;
    while (actual != null)
    {
        if (actual.dato.Equals(dato))
        {
            return actual;
        }
        actual = actual.Siguiente;
    }
    return null;
}
    // public void EditaNodo(T datoAnterior, T datoNuevo, string dirección)
     public void EditaNodo(T datoAnterior, T datoNuevo, string direccion)
{
    if (Primero == null)
    {
        Console.WriteLine("La lista está vacía");
    }
    Nodo<T> actual;
    if (direccion.ToLower() == "primero")
    {
        actual = Primero;
        while (actual != null)
        {
            if (actual.dato.Equals(datoAnterior))
            {
                actual.dato = datoNuevo;
            }
            actual = actual.Siguiente;
        }
    }
    else if (direccion.ToLower() == "ultimo")
    {
        actual = Ultimo;
        while (actual != null)
        {
            if (actual.dato.Equals(datoAnterior))
            {
                actual.dato = datoNuevo;
            }
            actual = actual.Anterior;
        }
    }
    else
    {
        Console.WriteLine("Dirección inválida");
    }
}

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
    
    // BENJAMIN
    public void Borra(Nodo<T> nodo) {
        if (Vacia) throw new ListaException("No se puede borrar un nodo de una lista vacía");
        if (Longitud == 1) {
            if (nodo != Primero && nodo != Ultimo) throw new ListaException("El nodo debe ser de la lista");
            Primero = Ultimo = null;
        } else if (nodo == Primero) {
            Primero = nodo.Siguiente;
            nodo.Siguiente.Anterior = null;
        } else if (nodo == Ultimo) {
            Ultimo = nodo.Anterior;
            nodo.Anterior.Siguiente = null;
        } else {
            nodo.Anterior.Siguiente = nodo.Siguiente;
            nodo.Siguiente.Anterior = nodo.Anterior;
        }
        nodo.Dispose();
        Longitud--;
    }
    // BENJAMIN
    public override string ToString() {
        string salida = "";
        for (Nodo<T> i = Primero; i != null; i = i.Siguiente)
            salida += $"[{i.Dato}] ";
        salida += $"-";

        for (Nodo<T> i = Ultimo; i != null; i = i.Anterior)
           salida += $"[{i.Dato}]";
        return salida;
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
