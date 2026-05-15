namespace Tienda_Consola.Negocios;

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

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
    public void AgregarProducto(Producto p) { productos.Add(p); }
    
    
    public Producto? BuscarProducto(string codigo)
    {
        return productos.Find(p => p.GetCodigo() == codigo);
    }



    public List<Producto> ListarProductos() { return productos; }
}