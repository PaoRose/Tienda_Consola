namespace Tienda_Consola.Negocios;

public class Categoria
{
    public string codigo;
    public string nombre;
    public string descripcion;

    public Categoria(string codigo, string nombre, string descripcion)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
    
    public string GetCodigo() { return codigo; }
    public string GetNombre() { return nombre; }
    public string GetDescripcion() { return descripcion; }
}