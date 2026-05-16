namespace Tienda_Consola.Negocios;

public class MetodoPago
{
    private string tipo;
    private string estado;

    public MetodoPago(string tipo)   // fix: sobraba el parámetro estado
    {
        this.tipo   = tipo;
        this.estado = "Pendiente";
    }

    public bool ProcesarPago(double monto)   // fix: era "procesar MetodoPago()"
    {
        estado = "Aceptado";
        return true;
    }

    public void MostrarMetodoPago()
    {
        Console.WriteLine($"  MetodoPago : {tipo}");
        Console.WriteLine($"  Estado     : {estado}");
    }

    public string GetTipo()   { return tipo; }
    public string GetEstado() { return estado; }
}