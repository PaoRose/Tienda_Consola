using Tienda_Consola.Negocios;

namespace Tienda_Consola.Presentacion;

public class MenuAdministrador
{
    private Inventario    inventario;
    private List<Cliente> clientes;
    private Administrador admin;

    public MenuAdministrador(Inventario inventario, List<Cliente> clientes, Administrador admin)
    {
        this.inventario = inventario;
        this.clientes   = clientes;
        this.admin      = admin;
    }

    public void Mostrar()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menu Administrador");
            
            Console.WriteLine("✮Productos✮");
            Console.WriteLine("  1. Listar productos");
            Console.WriteLine("  2. Agregar producto");
            Console.WriteLine("  3. Actualizar producto");
            Console.WriteLine("  4. Eliminar producto");
            
            Console.WriteLine("✮Usuarios✮");
            Console.WriteLine("  5. Listar usuarios");
            Console.WriteLine("  6. Agregar usuario");
            Console.WriteLine("  7. Actualizar usuario");
            Console.WriteLine("  8. Eliminar usuario");
            Console.WriteLine("  0. Cerrar sesion (• ֊ •)੭");
            Console.Write("Opcion: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1": ListarProductos();    break;
                case "2": AgregarProducto();    break;
                case "3": ActualizarProducto(); break;
                case "4": EliminarProducto();   break;
                case "5": ListarUsuarios();     break;
                case "6": AgregarUsuario();     break;
                case "7": ActualizarUsuario();  break;
                case "8": EliminarUsuario();    break;
                case "0": salir = true;         break;
                default:  Console.WriteLine("  Opcion invalida."); break;
            }
        }
    }

    public void ListarProductos()
    {
        Console.WriteLine("\n✮⋆˙Listar Productos˙⋆✮");
        inventario.MostrarInventario();
    }

    public void AgregarProducto()
    {
        Console.WriteLine("\n✮⋆˙Agregar Producto˙⋆✮");
        Console.Write("Codigo      : "); string codigo = Console.ReadLine() ?? "";
        Console.Write("Nombre      : "); string nombre = Console.ReadLine() ?? "";
        Console.Write("Precio      : "); double.TryParse(Console.ReadLine(), out double precio);
        Console.Write("Descripcion : "); string desc   = Console.ReadLine() ?? "";
        Console.Write("Stock       : "); int.TryParse(Console.ReadLine(), out int stock);

        Categoria    cat  = new Categoria("CAT001", "General", "General");
        Subcategoria sub  = new Subcategoria("SUB001", "General", "General", cat);
        Producto     nuevo = new Producto(codigo, nombre, precio, desc, stock, true, sub);
        inventario.AgregarProducto(nuevo);
        Console.WriteLine($"  Producto '{nombre}' agregado.");
    }

    public void ActualizarProducto()
    {
        ListarProductos();
        Console.Write("\nCodigo del producto a actualizar: ");
        string codigo = Console.ReadLine() ?? "";

        Producto? encontrado = inventario.BuscarProducto(codigo);
        if (encontrado == null)
        {
            Console.WriteLine("  Producto no encontrado.");
            return;
        }

        Console.Write($"Nuevo nombre ({encontrado.GetNombre()}): ");
        string nombre = Console.ReadLine() ?? "";
        if (!string.IsNullOrEmpty(nombre)) encontrado.SetNombre(nombre);

        Console.Write($"Nuevo precio ({encontrado.GetPrecio()}): ");
        string precioStr = Console.ReadLine() ?? "";
        if (double.TryParse(precioStr, out double precio)) encontrado.SetPrecio(precio);

        Console.Write($"Nuevo stock ({encontrado.GetStock()}): ");
        string stockStr = Console.ReadLine() ?? "";
        if (int.TryParse(stockStr, out int stock)) encontrado.SetStock(stock);

        inventario.ActualizarProducto(encontrado);
        Console.WriteLine("  Producto actualizado.");
    }

    public void EliminarProducto()
    {
        ListarProductos();
        Console.Write("\nCodigo del producto a eliminar: ");
        string codigo = Console.ReadLine() ?? "";
        inventario.EliminarProducto(codigo);
        Console.WriteLine($"  Producto '{codigo}' eliminado.");
    }
    
    //----------------------------------------------------------------------
    
    public void ListarUsuarios()
    {
        Console.WriteLine("\nListar Usuarios");
        if (clientes.Count == 0)
        {
            Console.WriteLine("  No hay usuarios.");
            return;
        }
        Console.WriteLine($"  {"Usuario",-15} {"Nombre",-20} {"Tipo"}");
        Console.WriteLine("  " + new string('-', 45));
        foreach (Cliente c in clientes)
            Console.WriteLine($"  {c.GetUsuario(),-15} {c.GetNombre(),-20} {c.GetTipo()}");
    }

    public void AgregarUsuario()
    {
        Console.WriteLine("\nAgregar Usuario");
        Console.Write("Nombre   : "); string nombre   = Console.ReadLine() ?? "";
        Console.Write("Usuario  : "); string usuario  = Console.ReadLine() ?? "";
        Console.Write("Password : "); string password = Console.ReadLine() ?? "";
        Console.WriteLine("Tipo: 1. Regular  2. VIP");
        Console.Write("Opcion: ");   string tipo = Console.ReadLine() ?? "";

        Cliente nuevo = tipo == "2"
            ? new ClienteVip(nombre, usuario, password)
            : new ClienteRegular(nombre, usuario, password);

        clientes.Add(nuevo);
        Console.WriteLine($"  Usuario '{usuario}' agregado como {nuevo.GetTipo()}.");
    }

    public void ActualizarUsuario()
    {
        ListarUsuarios();
        Console.Write("\nUsuario a actualizar: ");
        string usuario = Console.ReadLine() ?? "";

        Cliente? encontrado = clientes.Find(c => c.GetUsuario() == usuario);
        if (encontrado == null)
        {
            Console.WriteLine("  Usuario no encontrado.");
            return;
        }

        Console.Write($"Nuevo nombre ({encontrado.GetNombre()}): ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Nueva password: ");
        string password = Console.ReadLine() ?? "";
        Console.WriteLine("Nuevo tipo: 1. Regular  2. VIP");
        Console.Write("Opcion: "); string tipo = Console.ReadLine() ?? "";

        string nuevoNombre   = string.IsNullOrEmpty(nombre)   ? encontrado.GetNombre()   : nombre;
        string nuevoPassword = string.IsNullOrEmpty(password) ? encontrado.GetPassword() : password;

        Cliente actualizado = tipo == "2"
            ? new ClienteVip(nuevoNombre, usuario, nuevoPassword)
            : new ClienteRegular(nuevoNombre, usuario, nuevoPassword);

        clientes.Remove(encontrado);
        clientes.Add(actualizado);
        Console.WriteLine("  Usuario actualizado.");
    }

    public void EliminarUsuario()
    {
        ListarUsuarios();
        Console.Write("\nUsuario a eliminar: ");
        string usuario = Console.ReadLine() ?? "";

        Cliente? encontrado = clientes.Find(c => c.GetUsuario() == usuario);
        if (encontrado != null)
        {
            clientes.Remove(encontrado);
            Console.WriteLine($"  Usuario '{usuario}' eliminado.");
        }
        else
            Console.WriteLine("  Usuario no encontrado.");
    }
}