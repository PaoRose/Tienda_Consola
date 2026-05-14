namespace Tienda_Consola.Negocios;

public class DetalleCompra
{
    private int cantidad;
    private double precioUnitario;
    private Producto producto;
    
    public DetalleCompra(Producto producto, int cantidad)
    {
        this.producto = producto;
        this.cantidad = cantidad;
        this.precioUnitario = producto.GetPrecio();
    }

    public double CalcularSubtotal()
    {
        return precioUnitario * cantidad;
    }
    
    public Producto GetProducto() { return producto; }
    public int GetCantidad() { return cantidad; }

    public void MostrarDetalle()
    {
        Console.WriteLine($"  {producto.GetNombre(),-25} x {cantidad}  " + $"{precioUnitario,8:F2} Bs c/u  =>  {CalcularSubtotal(),8:F2} Bs");
    }
    
    //F2 en C# lo usan para decimales rtipo en este caso es dos
}