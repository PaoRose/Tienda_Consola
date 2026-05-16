namespace Tienda_Consola.Negocios;

public class PagoEfectivo
{
    private double montoRecibido;
    private double cambio;

    public PagoEfectivo(double montoRecibido) : base("Efectivo")
    {
        this.montoRecibido = montoRecibido;
    }

    public override bool ProcesarPago(double monto)
    {
        if (montoRecibido < monto)
            return false;
        cambio = montoRecibido - monto;
        return true;    
    }
    
    public override void MostrarMetodoPago()
    {
        Console.WriteLine($"  Metodo de pago  : {GetTipo()}");
        Console.WriteLine($"  Monto recibido  : {montoRecibido:F2} Bs");
        Console.WriteLine($"  Cambio          : {cambio:F2} Bs");
    }

    public double GetMontoRecibido() { return montoRecibido; }
    public double GetCambio()        { return cambio; }
}
