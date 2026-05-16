namespace Tienda_Consola.Negocios;

public class Inventario
{
    private List<Producto> productos = new List<Producto>(); // Composición: Inventario *-- Producto

    public void AgregarProducto(Producto p) { productos.Add(p); }

    public void ActualizarProducto(Producto p)
    {
        Producto? encontrado = productos.Find(x => x.GetCodigo() == p.GetCodigo());
        if (encontrado != null)
        {
            productos.Remove(encontrado);
            productos.Add(p);
        }
    }

    public void EliminarProducto(string codigo)
    {
        Producto? encontrado = productos.Find(p => p.GetCodigo() == codigo);
        if (encontrado != null)
            productos.Remove(encontrado);
    }

    public List<Producto> ListarProductos() { return productos; }

    public Producto? BuscarProducto(string codigo)
    {
        return productos.Find(p => p.GetCodigo() == codigo);
    }

    public void MostrarInventario()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("  No hay productos en el inventario.");
            return;
        }
        Console.WriteLine($"\n  {"Codigo",-8} {"Nombre",-25} {"Precio",10} {"Stock",8}");
        Console.WriteLine("  " + new string('-', 55));
        foreach (Producto p in productos)
            Console.WriteLine("  " + p.ToString());
    }
}