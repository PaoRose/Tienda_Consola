namespace Tienda_Consola.Negocios;

public class ClienteVip
{
    public ClienteVip(string nombre, string usuario, string password) : base(nombre, usuario, password)
    { }

    public override double CalcularDescuento(double sub)
    {
        double descuentoBase = sub * 0.10;
        double descuentoAdiconal = sub > 500 ? sub * 0.05 : 0;
        return descuentoBase + descuentoAdiconal;
    }
    
    public override string GetTipo() { return "ClienteVip"; }
}