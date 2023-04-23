public interface IEnumerable {
    IEnumerator GetEnumerator();
}

public interface IEnumerable<T> : IEnumerable {
    IEnumerator<T> GetEnumerator();
}
public interface IEnumerator {
    object Current { get; }
    void Reset();
    bool MoveNext();
}




public interface IEnumerator<T> : IDisposable, IEnumerator {
    T Current { get; }
}
class ListaException : Exception {
    public ListaException(string mensaje) : base(mensaje) { }
}





class ListaDoblementeEnlazada<T> : IDisposable, IEnumerable<T> where T : IComparable<T>
{
    public Nodo<T>? Primero { get; private set; }
    public Nodo<T>? Ultimo { get; private set; }
    public int Longitud { get; private set; }
    public bool Vacia => Longitud == 0;

    public ListaDoblementeEnlazada()
    {
        this.Primero = this.Ultimo = null;
        this.Longitud = 0;
    }
    public ListaDoblementeEnlazada(IEnumerable<T> secuencia)
    {
        this.Primero = null;
        this.Ultimo = null;
        this.Longitud = 0;

        foreach (T dato in secuencia)
            AñadeAlFinal(dato);
    }

    // JESUS 
    public void AñadeAntesDe(Nodo<T> nodo, Nodo<T> nuevo)
    {
        if (Vacia)
            throw new ListaException("La lista no puede estar vacía");

        if(nodo == Primero) {
            AñadeAlPrincipio(nuevo);
        } else {
            nodo.Anterior.Siguiente = nuevo;
            nuevo.Anterior = nodo.Anterior;
            nodo.Anterior = nuevo;
            nuevo.Siguiente = nodo;
            Longitud++;
        }
    }
    public void AñadeAntesDe(Nodo<T> nodo, T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);        

        AñadeAntesDe(nodo, nuevo);
    }
    public void AñadeDespuesDe(Nodo<T> nodo, Nodo<T> nuevo)
    {
        if (Vacia)
            throw new ListaException("La lista no puede estar vacía");

        if(nodo == Ultimo) {
            AñadeAlFinal(nuevo);
        } else {
            nodo.Siguiente.Anterior = nuevo;
            nuevo.Siguiente = nodo.Siguiente;
            nodo.Siguiente = nuevo;
            nuevo.Anterior = nodo;
            Longitud++;
        }
    }
    public void AñadeDespuesDe(Nodo<T> nodo, T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);
        AñadeDespuesDe(nodo, nuevo);
    }

    public void AñadeAlPrincipio(Nodo<T> nuevo)
    {
        if(Vacia) {
            Primero = Ultimo = nuevo;
        } else {
            Primero.Anterior = nuevo;
            nuevo.Siguiente = Primero;
            Primero = nuevo;
        }
        Longitud++;
    }
    public void AñadeAlPrincipio(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);
        AñadeAlPrincipio(nuevo);
    }
    public void AñadeAlFinal(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);

        AñadeAlFinal(nuevo);
    }
    public void AñadeAlFinal(Nodo<T> nuevo)
    {
        if(Vacia) {
            Primero = Ultimo = nuevo;
        } else {
            Ultimo.Siguiente = nuevo;
            nuevo.Anterior = Ultimo;
            Ultimo = nuevo;
        }
        Longitud++;
    }


    // DAVID 
    public Nodo<T> Busca(T dato)
    {
        Nodo<T>? actual = Primero;
        while (actual != null)
        {
            if (actual.Dato.Equals(dato))
            {
                return actual;
            }
            actual = actual.Siguiente;
        }
        return null;
    }
    public void EditaNodo(T datoAnterior, T datoNuevo, string direccion)
    {
        if (Primero == null)
        {
            Console.WriteLine("La lista está vacía");
        }
        Nodo<T>? actual;
        if (direccion.ToLower() == "primero")
        {
            actual = Primero;
            while (actual != null)
            {
                if (actual.Dato.Equals(datoAnterior))
                {
                    actual.Dato = datoNuevo;
                }
                actual = actual.Siguiente;
            }
        }
        else if (direccion.ToLower() == "ultimo")
        {
            actual = Ultimo;
            while (actual != null)
            {
                if (actual.Dato.Equals(datoAnterior))
                {
                    actual.Dato = datoNuevo;
                }
                actual = actual.Anterior;
            }
        }
        else
        {
            Console.WriteLine("Dirección inválida");
        }
    }

    // BENJAMIN
    public void Borra(Nodo<T> nodo)
    {
        if (Vacia) throw new ListaException("No se puede borrar un nodo de una lista vacía");
        if (Longitud == 1)
        {
            if (nodo != Primero && nodo != Ultimo) throw new ListaException("El nodo debe ser de la lista");
            Primero = Ultimo = null;
        }
        else if (nodo == Primero)
        {
            Primero = nodo.Siguiente;
            nodo.Siguiente.Anterior = null;
        }
        else if (nodo == Ultimo)
        {
            Ultimo = nodo.Anterior;
            nodo.Anterior.Siguiente = null;
        }
        else
        {
            nodo.Anterior.Siguiente = nodo.Siguiente;
            nodo.Siguiente.Anterior = nodo.Anterior;
        }
        nodo.Dispose();
        Longitud--;
    }
    // BENJAMIN
    public override string ToString()
    {
        string salida = "";
        for (Nodo<T> i = Primero; i != null; i = i.Siguiente)
            salida += $"[{i.Dato}] ";
        salida += $"- ";

        for (Nodo<T> i = Ultimo; i != null; i = i.Anterior)
            salida += $"[{i.Dato}] ";
        return salida;
    }

    public IEnumerator<T> GetEnumerator() => new Enumerador(Primero);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Clear() => Dispose();

    public void Dispose()
    {
        Nodo<T>? actual = Primero;
        Nodo<T>? siguiente;
        Longitud = 0;

        this.Primero = this.Ultimo = null;
        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Dispose();
            actual = siguiente;
        }
    }

    private class Enumerador : IEnumerator<T>, IDisposable
    {
        private Nodo<T>? It { get; set; }
        private Nodo<T>? Primero { get; set; }

        public Enumerador(Nodo<T> Primero)
        {
            this.Primero = Primero;
            Reset();
        }

        public void Reset() => It = null;
        public T Current => It!.Dato;
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            bool puedoIterar = It == null && Primero != null || It != null && It.Siguiente != null;
            if (puedoIterar)
                It = It == null ? Primero : It.Siguiente;

            return puedoIterar;
        }

        public void Dispose()
        {
            Primero = null;
            It = null;
        }
    }
}





public class Nodo<T> : IDisposable {
    public Nodo<T>? Siguiente { get; set; }
    public Nodo<T>? Anterior { get; set; }
    public T Dato { get; set; }

    public Nodo(T Dato) {
        this.Siguiente = this.Anterior = null;
        this.Dato = Dato;
    }

    public void Dispose() {
        this.Siguiente = this.Anterior = null;
        if(Dato is IDisposable d)
            d.Dispose();
    }
}




internal class Program {
    private static void Main(string[] args) {
        ListaDoblementeEnlazada<int> ld = new ListaDoblementeEnlazada<int>();
        ld.AñadeAlPrincipio(4);
        ld.AñadeAlPrincipio(3);
        Console.WriteLine(ld);
        ld.Clear();
        ld.AñadeAlFinal(6);
        ld.AñadeAlFinal(9);
        ld.AñadeAlPrincipio(3);
        Console.WriteLine(ld);
        Nodo<int> nodo = ld.Busca(6);
        ld.AñadeAntesDe(nodo, 5);
        ld.AñadeAntesDe(ld.Primero, 1);
        ld.AñadeDespuesDe(nodo, 7);
        ld.AñadeDespuesDe(ld.Ultimo, 12);
        Console.WriteLine(ld);
        ld.Borra(nodo);
        ld.Borra(ld.Primero);
        ld.Borra(ld.Ultimo);
        Console.WriteLine(ld);

        /* PRUEBAS CON STRINGS
        ListaDoblementeEnlazada<string> ld = new ListaDoblementeEnlazada<string>();
        ld.AñadeAlPrincipio("A1");
        ld.AñadeAlPrincipio("A2");
        Console.WriteLine(ld);
        ld.Clear();
        ld.AñadeAlFinal("F1");
        ld.AñadeAlFinal("F2");
        ld.AñadeAlPrincipio("P1");
        Console.WriteLine(ld);
        Nodo<string> nodo = ld.Busca("F1");
        ld.AñadeAntesDe(nodo, "AF1");
        ld.AñadeAntesDe(ld.Primero, "APrim");
        ld.AñadeDespuesDe(nodo, "DF1");
        ld.AñadeDespuesDe(ld.Ultimo, "DFin");
        Console.WriteLine(ld);
        ld.Borra(nodo);
        ld.Borra(ld.Primero);
        ld.Borra(ld.Ultimo);
        Console.WriteLine(ld);
        */
        Console.ReadLine();
    }
}
    
