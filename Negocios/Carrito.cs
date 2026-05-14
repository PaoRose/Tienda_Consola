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

    public void MostrarCarrito()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("El carrito esta vacio.");
            return;
        }

        foreach (DetalleCompra item in items)
            item.MostrarDetalle();
    }
    
    public void VaciarCarrito() { items.Clear(); }
    public List<DetalleCompra> GetItems() { return items; }
    public bool EstaVacio () { return items.Count == 0; }
    
    //Corrito->Compra
    public Compra GenerarCompra()
    {
        Compra compra = new Compra();
        foreach ( DetalleCompra item in items)
            compra.AgregarItem(item);
        return compra;
    }
}