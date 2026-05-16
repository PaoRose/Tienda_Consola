namespace Tienda_Consola.Negocios;

public class ClienteVip : Cliente   // fix: faltaba : Cliente
{
    public ClienteVip(string nombre, string usuario, string password)
        : base(nombre, usuario, password) { }

    public override double CalcularDescuento(double sub)
    {
        double descuentoBase      = sub * 0.10;
        double descuentoAdicional = sub > 500 ? sub * 0.05 : 0;
        return descuentoBase + descuentoAdicional;
    }

    public override string GetTipo() { return "Cliente VIP"; }
}