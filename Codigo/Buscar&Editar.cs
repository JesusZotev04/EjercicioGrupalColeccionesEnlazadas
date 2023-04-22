/*
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
*/