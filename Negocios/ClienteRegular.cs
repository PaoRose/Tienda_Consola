namespace Tienda_Consola.Negocios;

public class ClienteRegular : Cliente
{
    public ClienteRegular(string nombre, string usuario, string password)
        : base(nombre, usuario, password) { }

    public override double CalcularDescuento(double sub)
    {
        return sub > 500 ? sub * 0.05 : 0;
    }

    public override string GetTipo() { return "Cliente Regular"; }
}