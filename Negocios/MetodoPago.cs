namespace Tienda_Consola.Negocios;

public abstract class MetodoPago
{
    private string tipo;

    public MetodoPago(string tipo) 
    {
        this.tipo   = tipo;
    }
    public string GetTipo() { return tipo; }
    public abstract bool ProcesarPago(double monto);
    public abstract void MostrarMetodoPago();

}