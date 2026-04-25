using Tienda_Consola.Negocios;
namespace Tienda_Consola.Presentacion;

public class PresentacionTienda
{
    private Autenticacion autenticacion;
    private Inventario inventario;
    private Carrito carrito;
    private MostrarTienda mostrarTienda;

    public PresentacionTienda(Autenticacion autenticacion, Inventario inventario)
    {
        this.autenticacion = autenticacion;
        this.inventario = inventario;
        this.carrito = new Carrito();
        this.mostrarTienda = new MostrarTienda(inventario, carrito);
    }

    public void Iniciar()
    {
        bool corriendo = true;
        while (corriendo)
        {
            Console.WriteLine("Tienda de electonicos");
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Usuario? ingresando = autenticacion.Login(usuario, password);

            if (ingresando == null)
            {
                Console.WriteLine("Credenciales incorrectos");
            }
            else if (ingresando.GetRol().GetNombre() == "Administrador")
            {
                MenuAdmin();
            }
            else
            {
                MenuCliente(ingresando);
            }
        }
    }

    public void MenuAdmin()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nAdministrados...");
            Console.WriteLine("1. Listar productos");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Listar usuarios");
            Console.WriteLine("6. Agregar usuario");
            Console.WriteLine("7. Actualizar usuario");
            Console.WriteLine("8. Eliminar usuario");
            Console.WriteLine("9. Cerrar sesion");
            Console.WriteLine("10. Cerrar tienda");
            Console.Write("Opcion: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: mostrarTienda.MostrarInventario(); break;
                case 2: AgregarProducto(); break;
                case 3:     
                    Console.Write("Codigo del producto a actualizar: ");
                    string codAct = Console.ReadLine();
                    Producto pAct = inventario.BuscarProducto(codAct);
                    if (pAct != null)
                    {
                        Console.Write("Nuevo nombre: "); 
                        string nuevoNombre = Console.ReadLine();
                        Console.Write("Nuevo precio: "); 
                        double nuevoPrecio = double.Parse(Console.ReadLine());
                        Console.Write("Nuevo stock: "); 
                        int nuevoStock = int.Parse(Console.ReadLine());
                        Console.Write("Nueva descripcion: "); 
                        string nuevaDesc = Console.ReadLine();
                        Producto actualizado = new Producto(codAct, nuevoNombre, nuevoPrecio, nuevaDesc, nuevoStock, true, pAct.GetSubcategoria());
                        inventario.ActualizarProducto(actualizado);
                        Console.WriteLine("Producto actualizado");
                    }
                    else
                        Console.WriteLine("Producto no encontrado");
                    break;
                case 4: EliminarProducto(); break;
                case 5: ListarUsuarios(); break;
                case 6: AgregarUsuario(); break;
                case 7:
                    Console.Write("Username a actualizar: "); 
                    string userAct = Console.ReadLine();
                    Console.Write("Nueva password: "); 
                    string passAct = Console.ReadLine();
                    Console.Write("Rol (1.Admin / 2.Cliente): ");
                    string rolAct = Console.ReadLine() == "1" ? "Administrador" : "Cliente";
                    Rol nuevoRol = new Rol(rolAct);
                    autenticacion.ActualizarUsuario(new Usuario(userAct, passAct, nuevoRol));
                    Console.WriteLine("Usuario actualizado");
                    break;
                case 8: EliminarUsuario(); break;
                case 9: continuar = false; break;
                case 10: Environment.Exit(0); break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        }
    }

    public void MenuCliente(Usuario usuario)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nCliente...");
            Console.WriteLine("1. Ver productos disponibles");
            Console.WriteLine("2. Realizar una compra");
            Console.WriteLine("3. Cerrar sesion");
            Console.WriteLine("4. Cerrar tienda");
            Console.Write("Opcion: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: mostrarTienda.MostrarCatalogo(); break;
                case 2: MenuCompra(usuario); break;
                case 3: continuar = false; break;
                case 4: Environment.Exit(0); break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        }
    }

    public void MenuCompra(Usuario usuario)
    {
        Compra compra = new Compra(usuario);
        bool comprando = true;

        while (comprando)
        {
            mostrarTienda.MostrarCatalogo();
            Console.WriteLine("\n1. Agregar producto al carrito");
            Console.WriteLine("2. Ver carrito");
            Console.WriteLine("3. Confirmar compra");
            Console.WriteLine("4. Volver");
            Console.Write("Opcion: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Codigo del producto: ");
                    string codigo = Console.ReadLine();
                    Producto p = inventario.BuscarProducto(codigo);
                    if (p != null)
                    {
                        Console.Write("Cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        if (cantidad <= p.GetStock())
                        {
                            DetalleCompra detalle = new DetalleCompra(p, cantidad);
                            carrito.AgregarProducto(detalle);
                            compra.AgregarItem(detalle);
                            Console.WriteLine("Producto agregado al carrito");
                        }
                        else
                            Console.WriteLine("Stock insuficiente");
                    }
                    else
                        Console.WriteLine("Producto no encontrado");
                    break;
                case 2:
                    mostrarTienda.MostrarCarrito();
                    break;
                case 3:
                    Console.WriteLine("Metodo de pago: 1. Efectivo  2. Tarjeta");
                    string tipo = Console.ReadLine() == "1" ? "Efectivo" : "Tarjeta";
                    MetodoPago pago = new MetodoPago(tipo);
                    compra.ConfirmarCompra();
                    compra.RegistrarPago(pago);
                    carrito.VaciarCarrito();
                    Console.WriteLine($"Compra confirmada. Total: {compra.GetTotal()} Bs");
                    comprando = false;
                    break;
                case 4:
                    comprando = false;
                    break;
            }
        }
    }
//Admin
    private void AgregarProducto()
    {
        Console.Write("Codigo: "); string codigo = Console.ReadLine();
        Console.Write("Nombre: "); string nombre = Console.ReadLine();
        Console.Write("Precio: "); double precio = double.Parse(Console.ReadLine());
        Console.Write("Descripcion: "); string desc = Console.ReadLine();
        Console.Write("Stock: "); int stock = int.Parse(Console.ReadLine());
        Producto p = new Producto(codigo, nombre, precio, desc, stock, true, null);
        inventario.AgregarProducto(p);
        Console.WriteLine("Producto agregado");
    }

    private void EliminarProducto()
    {
        Console.Write("Codigo del producto a eliminar: ");
        string codigo = Console.ReadLine();
        inventario.EliminarProducto(codigo);
        Console.WriteLine("Producto eliminado");
    }

    private void ListarUsuarios()
    {
        foreach (Usuario u in autenticacion.ListarUsuario())
            Console.WriteLine($"{u.GetUsuario()} | {u.GetRol().GetNombre()}");
    }

    private void AgregarUsuario()
    {
        Console.Write("Usuario: "); string usuario = Console.ReadLine();
        Console.Write("Password: "); string pass = Console.ReadLine();
        Console.Write("Rol (1.Admin / 2.Cliente): ");
        string rolNombre = Console.ReadLine() == "1" ? "Administrador" : "Cliente";
        Rol rol = new Rol(rolNombre);
        autenticacion.AgregarUsuario(new Usuario(usuario, pass, rol));
        Console.WriteLine("Usuario agregado");
    }
    private void EliminarUsuario()
    {
        Console.Write("Usuario a eliminar: ");
        string usuario = Console.ReadLine();
        autenticacion.EliminarUsuario(usuario);
        Console.WriteLine("Usuario eliminado");
    }
    public void MenuCompra() { }
}