using Tienda_Consola.Negocios;

namespace Tienda_Consola.Presentacion;

public class MenuCliente
{
    private Cliente cliente;
    private Inventario inventario;

    public MenuCliente(Cliente cliente, Inventario inventario)
    {
        this.cliente = cliente;
        this.inventario = inventario;
    }

    public void Mostrar()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menu Cliente");
            Console.WriteLine("${cliente.GetNombre()} | {cliente.GetTipo()}");
            
            Console.WriteLine("1. Ver catalogo");
            Console.WriteLine("2. Agregar producto al carrito");
            Console.WriteLine("3. Ver carrito");
            Console.WriteLine("4. Ver resumen de descuento");
            Console.WriteLine("5. Confirmar compra");
            Console.WriteLine("0. Cerrar sesion (• ֊ •)੭");
            
            Console.WriteLine("Opcion: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1": MostrarCatalogo();   break;
                case "2": AgregarAlCarrito();  break;
                case "3": VerCarrito();        break;
                case "4": VerResumenDescuento();  break;
                case "5": ConfirmarCompra();   break;
                case "0": salir = true;        break;
                
                default: Console.WriteLine("Opcion no valida"); break;
            }
            
        }
    }
    
    //ᕙ(•̀‸•́‶)ᕗ 
    // ---------------------------------------------------------------------

    public void MostrarCatalogo()
    {
        Console.WriteLine("\nCatalogo De Productos");
        bool hayProductos = false;
        foreach (Producto p in inventario.ListarProductos())
        {
            if (p.EstaDisponible())
            {
                Console.WriteLine("  " + p.ToString());
                hayProductos = true;
            }
        }
        if (!hayProductos)
            Console.WriteLine("No hay productos");
    }

    public void AgregarAlCarrito()
    {
        MostrarCatalogo();
        Console.Write("Codigo del producto: ");
        string codigo = Console.ReadLine() ?? "";
 
        Producto? producto = inventario.BuscarProducto(codigo);
        if (producto == null || !producto.EstaDisponible())
        {
            Console.WriteLine("  No se encontro el producto o no hay stock.");
            return;
        }
 
        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("  Cantidad invalida.");
            return;
        }
 
        if (cantidad > producto.GetStock())
        {
            Console.WriteLine($"  Stock insuficiente. Disponible: {producto.GetStock()}");
            return;
        }
 
        cliente.GetCarrito().AgregarProducto(new DetalleCompra(producto, cantidad));
        Console.WriteLine($"  '{producto.GetNombre()}' agregado al carrito.");
    }

    public void VerCarrito()
    {
        Console.Write("\n✮⋆˙Tu Carrito˙⋆✮");
        cliente.GetCarrito().MostrarCarrito();
        if (!cliente.GetCarrito().EstaVacio())
            Console.WriteLine($"   Subtotal: {cliente.GetCarrito().CalcularTotal():F2} Bs.");

    }

    public void VerResumenDescuento()
    {
        if (cliente.GetCarrito().EstaVacio())
        {
            Console.WriteLine("  El carrito esta vacio.");
            return;
        }
 //d - poli
        double subtotal           = cliente.GetCarrito().CalcularTotal();
        double descuento          = cliente.CalcularDescuento(subtotal);
        double total              = subtotal - descuento;
        double descuentoBase      = 0;
        double descuentoAdicional = 0;
 
        if (cliente is ClienteVip)
        {
            descuentoBase      = subtotal * 0.10;
            descuentoAdicional = subtotal > 500 ? subtotal * 0.05 : 0;
        }
        else
        {
            descuentoAdicional = subtotal > 500 ? subtotal * 0.05 : 0;
        }
 
        Console.WriteLine("\nResumen de descuentos");
        Console.WriteLine($"  Tipo de cliente         : {cliente.GetTipo()}");
        Console.WriteLine($"  Subtotal                : {subtotal,10:F2} Bs");
        Console.WriteLine($"  Descuento base          : {descuentoBase,10:F2} Bs");
        Console.WriteLine($"  Descuento adicional(5%) : {descuentoAdicional,10:F2} Bs");
        Console.WriteLine($"  {"",32}----------");
        Console.WriteLine($"  Total a pagar           : {total,10:F2} Bs");
    }

    public void ConfirmarCompra()
    {

        if (cliente.GetCarrito().EstaVacio())
        {
            Console.WriteLine("  El carrito esta vacio.");
            return;
        }

        VerResumenDescuento();

        Console.Write("\n¿Confirmar compra? (s/n): ");
        if ((Console.ReadLine() ?? "").ToLower() != "s")
        {
            Console.WriteLine("  Compra cancelada.");
            return;
        }

        Console.WriteLine("\nMetodo de pago:");
        Console.WriteLine("  1. Efectivo");
        Console.WriteLine("  2. Tarjeta");
        Console.WriteLine("  3. QR");
        Console.Write("Opcion: ");
        string tipo = (Console.ReadLine() ?? "") switch
        {
            "1" => "Efectivo",
            "2" => "Tarjeta",
            "3" => "QR",
            _ => "Efectivo"
        };
        
        // Carrito --> Compra (asociación)
            Compra compra = cliente.GetCarrito().GenerarCompra();
            compra.ConfirmarCompra();
             
            MetodoPago metodo = new MetodoPago(tipo);
            compra.RegistrarPago(metodo);
             
            Console.WriteLine("\n  Compra realizada exitosamente.");
            compra.MostrarDetalleSimple();
            cliente.GetCarrito().VaciarCarrito();
    }
    
}