namespace Tienda_Consola.Pruebas;

public class PruebasClass
{
    /*  Pruebas de: Usuario, Aunticacion, Privilegio y Rol
    //1. Privilegios
    Privilegio AgregarProducto = new Privilegio ("agregarproducto", "sin descripcion");
    Privilegio ConfirmarCompra = new Privilegio ("confirmarcompra", "sin descripcion");
    Console.WriteLine("Priv creados");

    //2. Roles
    Rol Administrador = new Rol ("Adminstrador");
    Administrador.AgregarPrivilegio(AgregarProducto);
    
    
    Rol Cliente = new Rol ("Cliente");
    Cliente.AgregarPrivilegio(ConfirmarCompra);

    Console.WriteLine("rols creados");
    
    //3.Tiene Privilegio?

    Console.WriteLine (Administrador.TienePrivilegio("agregar Producto"));
    Console.WriteLine (Cliente.TienePrivilegio("confirmarcompra"));

    //4. CrearUsuario
    Usuario admin = new Usuario("admin", "1234", Administrador);
    Usuario cliente = new Usuario("pepa", "2468",  Cliente);

    Console.WriteLine("usuarios creados");

    //5. Auntenticacia
    Autenticacion auto = new Autenticacion();
    auto.AgregarUsuario(admin);
    auto.AgregarUsuario(cliente);

    Usuario logueado = auto.Login("admin", "1234");
    Console.WriteLine(logueado != null ? $"Login OK — {logueado.GetUsuario()} ({logueado.GetRol().GetNombre()})" : "Login FAIL");
    // Login OK — admin (Administrador)

    Usuario fallido = auto.Login("admin", "wrongpass");
    Console.WriteLine(fallido != null ? "Login OK" : "Login FAIL — credenciales incorrectas");
    // Login FAIL — credenciales incorrectas


    foreach (Usuario u in auto.ListarUsuario())
    Console.WriteLine($"- {u.GetUsuario()} | Rol: {u.GetRol().GetNombre()}");

    auto.EliminarUsuario("juan");
    Console.WriteLine($"Usuarios restantes: {auto.ListarUsuario().Count}"); // 1

    Usuario adminActualizado = new Usuario("admin", "nuevaclave", Administrador);
    auto.ActualizarUsuario(adminActualizado);
    Usuario verificar = auto.Login("admin", "nuevaclave");
    Console.WriteLine(verificar != null ? "Actualización OK" : "Actualización FAIL");
    // Actualización OK
    */
}