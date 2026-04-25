using System.ComponentModel;

namespace Tienda_Consola.Negocios;

public class Autenticacion
{
    private List<Usuario> usuarios = new List<Usuario>();
    
    public Usuario Login(string usuario, string password)
    {
        return usuarios.Find(u => u.GetUsuario() == usuario && u.GetPassword() == password);
    }

    public List<Usuario> ListarUsuario()
    {
        return usuarios;
    }
    
    public void AgregarUsuario(Usuario u)
    {
        usuarios.Add(u);
    }
    
    public void ActualizarUsuario(Usuario u)
    {
        Usuario encontrado = usuarios.Find(u => u.GetUsuario() == u.GetPassword());
            
        if (encontrado != null)
        {
            usuarios.Remove(encontrado);
            usuarios.Add(u);
        }
    }

    public void EliminarUsuario(string usuario)
    {
        Usuario encontrado = usuarios.Find(x => x.GetUsuario() == usuario);
        if (encontrado != null)
        {
            usuarios.Remove(encontrado);
        }
    }
}