namespace Tienda_Consola.Negocios;

public class Privilegio
{
    private string nombre;
    private string descripcion;
    
    //constructor
    public Privilegio(string nombre, string descripcion)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
    }
    
    public string GetNombre() { return nombre; }
}