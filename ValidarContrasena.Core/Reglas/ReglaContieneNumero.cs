using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaContieneNumero : IReglasDeValidacion
{
    public bool EsValida(string contrasena)
    {
        return contrasena.Any(char.IsDigit);
    }

    public string MensajeError { get; }
}