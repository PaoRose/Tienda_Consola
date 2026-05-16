namespace Tienda_Consola.Negocios;

public class Producto
{
    private string       codigo;
    private string       nombre;
    private double       precio;
    private string       descripcion;
    private int          stock;
    private bool         habilitado;
    private Subcategoria subcategoria;

    public Producto(string codigo, string nombre, double precio,
        string descripcion, int stock, bool habilitado,
        Subcategoria subcategoria)
    {
        this.codigo       = codigo;
        this.nombre       = nombre;
        this.precio       = precio;
        this.descripcion  = descripcion;
        this.stock        = stock;
        this.habilitado   = habilitado;
        this.subcategoria = subcategoria;
    }

    public string       GetCodigo()        { return codigo; }
    public string       GetNombre()        { return nombre; }
    public double       GetPrecio()        { return precio; }
    public string       GetDescripcion()   { return descripcion; }
    public int          GetStock()         { return stock; }
    public Subcategoria GetSubcategoria()  { return subcategoria; }

    public void SetNombre(string nombre)       { this.nombre = nombre; }
    public void SetPrecio(double precio)       { this.precio = precio; }
    public void SetDescripcion(string desc)    { this.descripcion = desc; }
    public void SetStock(int stock)            { this.stock = stock; }
    public void SetHabilitado(bool habilitado) { this.habilitado = habilitado; }

    public void ReducirStock(int cantidad)
    {
        if (cantidad <= stock)
            stock -= cantidad;
        else
            habilitado = false;
    }

    public bool EstaDisponible()
    {
        return habilitado && stock > 0;
    }

    public override string ToString()
    {
        return $"{codigo,-8} | {nombre,-25} | {precio,8:F2} Bs | Stock: {stock}";
    }
}