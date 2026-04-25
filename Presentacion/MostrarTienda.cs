using Tienda_Consola.Negocios;
namespace Tienda_Consola.Presentacion;

public class MostrarTienda
{
    private Inventario inventario;
    private Carrito carrito;

    public MostrarTienda(Inventario inventario, Carrito carrito)
    {
        this.inventario = inventario;
        this.carrito = carrito;
    }

    public void MostrarCatalogo()
    {
        foreach (Producto p in inventario.ListarProductos())
            if (p.EstaHabilitado())
                Console.WriteLine(p.ToString());
    }

    public void MostrarInventario()
    {
        foreach (Producto p in inventario.ListarProductos())
            Console.WriteLine(p.ToString());
    }

    public void MostrarCarrito()
    {
        Console.WriteLine($"Total: {carrito.CalcularTotal()} Bs" );
    }    
    
    public void MostrarCarritoVip()
    {
        Console.WriteLine($"Total: {carrito.CalcularTotalDescuento()} Bs" );
    }

}
