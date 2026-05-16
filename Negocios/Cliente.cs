namespace Tienda_Consola.Negocios;

public abstract class Cliente
{
    private string nombre;
    private string usuario;
    private string password;
    private Carrito carrito;

    public Cliente(string nombre, string usuario, string password)
    {
        this.nombre   = nombre;
        this.usuario  = usuario;
        this.password = password;
        this.carrito  = new Carrito();
    }

    public string  GetNombre()   { return nombre; }   // fix: faltaban ()
    public string  GetUsuario()  { return usuario; }
    public string  GetPassword() { return password; }
    public Carrito GetCarrito()  { return carrito; }

    public abstract double CalcularDescuento(double sub);
    public abstract string GetTipo();
}