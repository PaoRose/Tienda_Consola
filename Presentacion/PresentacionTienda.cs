using Tienda_Consola.Negocios;

namespace Tienda_Consola.Presentacion;

public class PresentacionTienda
{
    private List<Cliente> clientes;

    public PresentacionTienda(List<Cliente> clientes)
    {
        this.clientes = clientes;
    }

    public void Iniciar(Inventario inventario, Administrador admin)
    {
        Console.WriteLine("Tienda Consola");
        Console.WriteLine("Admin(usuario: admin, pass: 1234)");
        Console.WriteLine("Cliente R(usuario: juan, pass: 5678), VIP(pepa, 2468)");

        bool cerrarTienda = false;
        while (!cerrarTienda)
        {
            object? sesion = Login(admin);

            if (sesion is Administrador adminLogueado)
            {
                MenuAdministrador menu = new MenuAdministrador(inventario, clientes, adminLogueado);
                menu.Mostrar();
            }
            else if (sesion is Cliente clienteLogueado)
            {
                MenuCliente menu = new MenuCliente(clienteLogueado, inventario);
                menu.Mostrar();
            }
            else
            {
                Console.Write("  Usuario o password incorrectos. ¿Intentar de nuevo? (s/n): ");
                if ((Console.ReadLine() ?? "").ToLower() != "s")
                    cerrarTienda = true;
            }
        }

        Console.WriteLine("\nGracias por visitar la tienda. Hasta pronto!");
    }

    public void Login() { }

    private object? Login(Administrador admin)
    {
        Console.WriteLine("\n--- Iniciar sesion ---");
        Console.Write("Usuario  : ");
        string usuario = Console.ReadLine() ?? "";
        Console.Write("Password : ");
        string password = Console.ReadLine() ?? "";

        if (usuario == admin.GetUsuario() && password == admin.GetPassword())
        {
            Console.WriteLine($"  Bienvenido, {admin.GetNombre()}.");
            return admin;
        }

        Cliente? encontrado = clientes.Find(
            c => c.GetUsuario() == usuario && c.GetPassword() == password);

        if (encontrado != null)
        {
            Console.WriteLine($"  Bienvenido, {encontrado.GetNombre()} ({encontrado.GetTipo()}).");
            return encontrado;
        }

        return null;
    }
}