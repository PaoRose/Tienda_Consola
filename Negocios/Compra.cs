namespace Tienda_Consola.Negocios;

public class Compra
{
    private string codigo;
    private DateTime fecha;
    private double total;
    private List<DetalleCompra> items = new List<DetalleCompra>();
    private Usuario usuario; 
    private MetodoPago metodoPago;

    public void ConfirmarCompra()
    {
        foreach (DetalleCompra item in items)
            item.GetProducto().ReducirStock(item.GetCantidad());
        total = CalcularTotal();
    }

    private double CalcularTotal()
    {
        double t = 0;
        foreach (DetalleCompra item in items)
        t += item.CalcularSubtotal();
        return t;
    }
    public double CalcularTotalDescuento()
    {
        double t = 0;
        foreach (DetalleCompra item in items)
            t += item.CalcularSubtotal()%10;
        return t;
    }
    public void RegistrarPago(MetodoPago metodo)
    {
        this.metodoPago = metodo;
        metodo.ProcesarPago(total);
    }

    public Compra(Usuario usuario)
    {
        this.usuario = usuario;
        this.fecha = DateTime.Now;
        this.codigo = "C" + DateTime.Now.Ticks;
    }

    public void AgregarItem(DetalleCompra item)
    {
        items.Add(item);
    }
    
    public string GetCodigo() { return codigo; }
    public double GetTotal() { return total; }
    public double GetTotalDescuento() { return total; }
}