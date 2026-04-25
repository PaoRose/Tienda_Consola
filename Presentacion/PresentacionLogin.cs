using Tienda_Consola.Negocios;

namespace Tienda_Consola.Presentacion;

public class PresentacionLogin
{
    private Autenticacion autenticacion;

    public PresentacionLogin(Autenticacion autenticacion)
    {
        this.autenticacion = autenticacion;
    }

    public void SolicitarCredenciales()
    {
        Console.Write("Usuario: ");
        string usuario = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        IniciarSesion(usuario, password);
    }

    public Usuario? IniciarSesion(string usuario, string password)
    {
        return autenticacion.Login(usuario, password);
    }
}