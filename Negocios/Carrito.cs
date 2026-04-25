namespace Tienda_Consola.Negocios;

public class Carrito
{
    private List<DetalleCompra> items = new List<DetalleCompra>();

    public void AgregarProducto(DetalleCompra item)
    {
        items.Add(item);
    }

    public void EliminarProducto(string codigo)
    {
        DetalleCompra? encontrado = items.Find(i => i.GetProducto().GetCodigo() == codigo);
        if (encontrado != null)
            items.Remove(encontrado);
    }

    public double CalcularTotal()
    {
        double total = 0;
        foreach (DetalleCompra item in items)
            total += item.CalcularSubtotal();
        return total;
    }

    public void VaciarCarrito()
    {
        items.Clear();
    }
}