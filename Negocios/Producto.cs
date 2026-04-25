namespace Tienda_Consola.Negocios;

public class Producto
{
    public string codigo;
    public string nombre;
    private double precio;
    public string descripcion;
    private int stock;
    public bool habilitado;
    private Subcategoria subcategoria;

    public Producto(string codigo, string nombre, double precio, string descripcion, int stock,  bool habilitado, Subcategoria subcategoria)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
        this.descripcion = descripcion;
        this.stock = stock;
        this.habilitado = habilitado;
        this.subcategoria = subcategoria;
    }

    public string GetCodigo() { return codigo; }
    public string GetNombre() { return nombre; }
    public double GetPrecio() { return precio; }
    public int GetStock() { return stock; }
    public Subcategoria GetSubCategoria() { return subcategoria; }

    public void ReducirStock(int cantidad)
    {
        if (cantidad<= stock)
            stock -=cantidad;
        else 
            habilitado = false;
    }

    public bool EstaHabilitado()
    {
        return habilitado && stock > 0;
    }

    public override string ToString()
    {
        return $"{codigo} | {nombre} | {precio} Bs | Stock: {stock}";
    }
    
    public Subcategoria GetSubcategoria(){ return subcategoria; }

    public void AgregarDescuento()
    {
        
    }
    
}