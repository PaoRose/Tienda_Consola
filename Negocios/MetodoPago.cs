namespace Tienda_Consola.Negocios;

public class MetodoPago
{
    private string tipo;
    private string estado;

    public MetodoPago(string tipo)
    {
        this.tipo = tipo;
        this.estado = "Pediente";
    }

    public bool ProcesarPago(double monto)
    {
        estado = "Aceptado";
        return true;
    }
    public string GetTipo() { return tipo; }
    public string GetEstado() { return estado; }
}