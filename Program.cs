using Tienda_Consola.Negocios;
using Tienda_Consola.Presentacion;

// 1. privilegios
Privilegio pGestionarProductos = new Privilegio("gestionar_productos", "Gestionar inventario");
Privilegio pGestionarUsuarios  = new Privilegio("gestionar_usuarios", "Gestionar usuarios");
Privilegio pVerCatalogo        = new Privilegio("ver_catalogo", "Ver productos");
Privilegio pRealizarCompra     = new Privilegio("realizar_compra", "Comprar productos");
Privilegio pDescuentoFidelidad = new Privilegio("descuento-fidelidad", "Descuento por ser cliente vip");

// 2. roles
Rol rolAdmin = new Rol("Administrador");
rolAdmin.AgregarPrivilegio(pGestionarProductos);
rolAdmin.AgregarPrivilegio(pGestionarUsuarios);
rolAdmin.AgregarPrivilegio(pVerCatalogo);

Rol rolCliente = new Rol("Cliente");
rolCliente.AgregarPrivilegio(pVerCatalogo);
rolCliente.AgregarPrivilegio(pRealizarCompra);

Rol rolClienteVip = new Rol("ClienteVip");
rolClienteVip.AgregarPrivilegio(pVerCatalogo);
rolClienteVip.AgregarPrivilegio(pRealizarCompra);
rolClienteVip.AgregarPrivilegio(pDescuentoFidelidad);

// 3. autenticacion y usuarios
Autenticacion auth = new Autenticacion();
auth.AgregarUsuario(new Cliente("admin", "1234", rolAdmin));
auth.AgregarUsuario(new Cliente("juan", "5678", rolCliente));
auth.AgregarUsuario(new Cliente("pepa", "2468", rolClienteVip));

// 4. inventarios y prodiuctos
Subcategoria subLaptops    = new Subcategoria("SUB001", "Laptops", "Computadoras portatiles");
Subcategoria subAccesorios = new Subcategoria("SUB002", "Accesorios", "Accesorios de computo");
Categoria catComp = new Categoria("CAT001", "Computacion", "Equipos de computo");

Inventario inventario = new Inventario();
inventario.AgregarProducto(new Producto("C001", "Laptop HP", 4500, "Laptop 15 pulgadas", 10, true, subLaptops));
inventario.AgregarProducto(new Producto("C002", "Mouse Logitech", 120, "Mouse inalambrico", 50, true, subAccesorios));
inventario.AgregarProducto(new Producto("C003", "Teclado Redragon", 350, "Teclado mecanico", 25, true, subAccesorios));
inventario.AgregarProducto(new Producto("T001", "iPhone 14", 6000, "Smartphone Apple", 5, true, subAccesorios));
inventario.AgregarProducto(new Producto("A001", "AirPods Pro", 1200, "Audifonos Apple", 10, true, subAccesorios));

//INCIIO!!!
PresentacionTienda tienda = new PresentacionTienda(auth, inventario);
tienda.Iniciar();