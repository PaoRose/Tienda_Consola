namespace Tienda_Consola.Negocios;

public class Compra
{
    private string              codigo;
    private DateTime            fecha;
    private double              total;
    private List<DetalleCompra> items = new List<DetalleCompra>();
    private MetodoPago?         metodoPago;

    public Compra()   // fix: el UML no tiene Cliente como atributo de Compra
    {
        this.fecha  = DateTime.Now;
        this.codigo = "C" + DateTime.Now.Ticks;
    }

    public void AgregarItem(DetalleCompra item) { items.Add(item); }

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

    public void RegistrarPago(MetodoPago metodo)
    {
        this.metodoPago = metodo;
        metodo.ProcesarPago(total);
    }

    public void MostrarDetalleSimple()
    {
        Console.WriteLine($"\n  Codigo : {codigo}");
        Console.WriteLine($"  Fecha  : {fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"  Items  :");
        foreach (DetalleCompra item in items)
            item.MostrarDetalle();
        Console.WriteLine($"  Total  : {total:F2} Bs");
        if (metodoPago != null)
            metodoPago.MostrarMetodoPago();
    }

    public string GetCodigo() { return codigo; }
    public double GetTotal()  { return total; }
}