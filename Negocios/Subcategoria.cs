namespace Tienda_Consola.Negocios;

public class Subcategoria
{
    private string codigo;
    private string nombre;
    private string descripcion;
    private Categoria categoria;
    

    public Subcategoria(string codigo, string nombre, string descripcion, Categoria categoria)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
    
    public string GetCodigo() { return codigo; }
    public string GetNombre() { return nombre; }
}