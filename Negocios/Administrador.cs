namespace Tienda_Consola.Negocios;

public class Administrador
{
    private string nombre;
    private string usuario;
    private string password;

    public Administrador(string nombre, string usuario, string password)
    {
        this.nombre = nombre;
        this.nombre = usuario;
        this.password = password;
    }
    
    public string GetNombre() { return nombre; }
    public string GetUsuario() { return usuario; }
    public string GetPassword() { return password; }
}