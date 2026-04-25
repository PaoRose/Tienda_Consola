namespace Tienda_Consola.Negocios;

public class Rol
{
    private string nombre;
    private List <Privilegio> privilegios = new List<Privilegio>();

    public Rol(string nombre)
    {
        this.nombre = nombre;
    }
    public void AgregarPrivilegio(Privilegio p)
    {
        privilegios.Add(p);
    }

    public bool TienePrivilegio(string nombre)
    {
        Privilegio encontrado = privilegios.Find(p => p.GetNombre() == nombre);
        return encontrado != null;
    }

    public string GetNombre()
    {
        return nombre;
    }
}