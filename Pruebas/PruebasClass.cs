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
    
    ////////////////////////////////////////////////////////////////////////////////////////////
    
    /* PRUEBA CATEGORIA-SUB-PRODUCTO
     
     using Tienda_Consola.Negocios;

    // 1. Crear categorias y sub
    Categoria catComputacion = new Categoria("CAT001", "Computacion", "Equipos de computo");
    Subcategoria subLaptops = new Subcategoria("SUB001", "Laptops", "Computadoras portatiles");
    Subcategoria subAccesorios = new Subcategoria("SUB002", "Accesorios", "Accesorios de computacion");

    Console.WriteLine("\n=== TEST CATEGORIA ===");
    Console.WriteLine(catComputacion.GetNombre());   // Computacion
    Console.WriteLine(subLaptops.GetNombre());        // Laptops
    Console.WriteLine("✓ Categoria y Subcategoria OK");

    // 2. productos
    Producto laptop = new Producto("C001", "Laptop HP", 4500, "Laptop 15 pulgadas", 10, true, subLaptops);
    Producto mouse  = new Producto("C002", "Mouse Logitech", 120, "Mouse inalambrico", 50, true, subAccesorios);
    Producto teclado = new Producto("C003", "Teclado Redragon", 350, "Teclado mecanico", 0, true, subAccesorios);

    Console.WriteLine(laptop.ToString());    // C001 | Laptop HP | Bs 4500 | Stock: 10
    Console.WriteLine(mouse.ToString());     // C002 | Mouse Logitech | Bs 120 | Stock: 50

    // 3. Disponibilidad correcta?
    Console.WriteLine(laptop.EstaHabilitado());   // True  — tiene stock
    Console.WriteLine(teclado.EstaHabilitado());  // False — stock 0

    // 4. SE Redujo Stock ?
    laptop.ReducirStock(3);
    Console.WriteLine(laptop.GetStock());    // 7
    laptop.ReducirStock(999);               // Stock insuficiente
    Console.WriteLine(laptop.GetStock());    // 7 — no cambió

    // 5. GetSubcategoria
    Console.WriteLine(laptop.GetSubcategoria().GetNombre());  // Laptops
    Console.WriteLine("Producto OK");
     */
    
    ////////////////////////////////////////////////////////////////////////////////////////////

    /*
     
     */
}