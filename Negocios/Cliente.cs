namespace Tienda_Consola.Negocios;

public class Cliente
{
    private string usuario;
    private string password;
    private Rol rol;

    public Cliente(string usuario, string password, Rol rol)
    {
        this.usuario = usuario;
        this.password = password;
        this.rol = rol;
    }

    public string GetUsuario() { return usuario; }
    public string GetPassword() { return password; }
    public Rol GetRol() { return rol; }

}