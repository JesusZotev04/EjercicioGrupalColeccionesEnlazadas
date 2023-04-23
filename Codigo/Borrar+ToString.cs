/*
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

public override string ToString() {
    string salida = "";
    for (Nodo<T> i = Primero; i != null; i = i.Siguiente)
        salida += $"[{i.Dato}] ";

    salida += $"-";
    
    for (Nodo<T> i = Ultimo; i != null; i = i.Anterior)
       salida += $"[{i.Dato}]";

    return salida;
}
*/
