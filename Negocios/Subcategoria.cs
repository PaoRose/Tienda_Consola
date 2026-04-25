namespace Tienda_Consola.Negocios;

public class Subcategoria
{
    public string codigo;
    public string nombre;
    public string descripcion;

    public Subcategoria(string codigo, string nombre, string descripcion)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
    
    public string GetCodigo() { return codigo; }
    public string GetNombre() { return nombre; }
}