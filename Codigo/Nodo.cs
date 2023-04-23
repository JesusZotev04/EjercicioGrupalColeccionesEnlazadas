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