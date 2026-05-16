using Tienda_Consola.Negocios;
using Tienda_Consola.Presentacion;

// 1. Categorias y subcategorias (Composicion: Categoria *-- Subcategoria)
Categoria catComp  = new Categoria("CAT001", "Computacion",  "Equipos de computo");
Categoria catMovil = new Categoria("CAT002", "Moviles",      "Telefonos y accesorios");

Subcategoria subLaptops    = new Subcategoria("SUB001", "Laptops",      "Computadoras portatiles", catComp);
Subcategoria subAccesorios = new Subcategoria("SUB002", "Accesorios",   "Accesorios de computo",   catComp);
Subcategoria subSmartphone = new Subcategoria("SUB003", "Smartphones",  "Telefonos inteligentes",  catMovil);

// 2. Inventario y productos (Composicion: Inventario *-- Producto)
Inventario inventario = new Inventario();
inventario.AgregarProducto(new Producto("C001", "Laptop HP",       4500, "Laptop 15 pulgadas", 10, true, subLaptops));
inventario.AgregarProducto(new Producto("C002", "Mouse Logitech",   120, "Mouse inalambrico",  50, true, subAccesorios));
inventario.AgregarProducto(new Producto("C003", "Teclado Redragon", 350, "Teclado mecanico",   25, true, subAccesorios));
inventario.AgregarProducto(new Producto("T001", "iPhone 14",       6000, "Smartphone Apple",    5, true, subSmartphone));
inventario.AgregarProducto(new Producto("A001", "AirPods Pro",     1200, "Audifonos Apple",    10, true, subAccesorios));

// 3. Clientes (Herencia: ClienteRegular y ClienteVIP extienden Cliente)
List<Cliente> clientes = new List<Cliente>
{
    new ClienteRegular("Juan Perez",  "juan", "5678"),
    new ClienteVip    ("Pepa Garcia", "pepa", "2468"),
};

// 4. Administrador
Administrador admin = new Administrador("Admin", "admin", "1234");

// 5. Iniciar tienda
PresentacionTienda tienda = new PresentacionTienda(clientes);
tienda.Iniciar(inventario, admin);