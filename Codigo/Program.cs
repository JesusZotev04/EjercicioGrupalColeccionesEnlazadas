internal class Program
{
    private static void Main(string[] args)
    {
        // Pruebas
        // ListaDoblementeEnlazada<int> ld = new ListaDoblementeEnlazada<int>();
        // ld.AñadeAlPrincipio(4);
        // ld.AñadeAlPrincipio(3);
        // Console.WriteLine(ld);
        // ld.Clear();
        // ld.AñadeAlFinal(6);
        // ld.AñadeAlFinal(9);
        // ld.AñadeAlPrincipio(3);
        // Console.WriteLine(ld);
        // Nodo<int> nodo = ld.Busca(6);
        // ld.AñadeAntesDe(nodo, 5);
        // ld.AñadeAntesDe(ld.Primero, 1);
        // ld.AñadeDespuesDe(nodo, 7);
        // ld.AñadeDespuesDe(ld.Ultimo, 12);
        // Console.WriteLine(ld);
        // ld.Borra(nodo);
        // ld.Borra(ld.Primero);
        // ld.Borra(ld.Ultimo);
        // Console.WriteLine(ld);

        // Elaborado
        ListaDoblementeEnlazada<string> listaCompra = new ListaDoblementeEnlazada<string>();
        listaCompra.AñadeAlPrincipio("Pan");
        listaCompra.AñadeAlFinal("Aceite");
        listaCompra.AñadeAntesDe(listaCompra.Busca("Aceite"), "Jamon");
        Console.WriteLine(listaCompra);

        listaCompra.AñadeDespuesDe(listaCompra.Busca("Aceite"), "Leche");
        listaCompra.Borra(listaCompra.Busca("Leche"));
        Console.WriteLine(listaCompra);

        listaCompra.AñadeAlFinal("Nesquik");
        listaCompra.EditaNodo("Nesquik", "Colacao", "ultimo");
        Console.WriteLine(listaCompra);

        listaCompra.Clear();
        Console.WriteLine(listaCompra);
    }
}