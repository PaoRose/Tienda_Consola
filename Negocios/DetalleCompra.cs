namespace Tienda_Consola.Negocios;

public class DetalleCompra
{
    private int cantidad;
    private double precioUnitario;
    private double subtotal;
    private Producto producto;

    public DetalleCompra(Producto producto, int cantidad)
    {
        this.producto = producto;
        this.cantidad = cantidad;
        this.precioUnitario = producto.GetPrecio();
        this.subtotal = precioUnitario * this.cantidad;
    }

    public double CalcularSubtotal()
    {
        return precioUnitario * this.cantidad;
    }
    
    public Producto GetProducto() { return producto; }
    
    public int GetCantidad() { return cantidad; }
}