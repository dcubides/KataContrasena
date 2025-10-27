using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaContieneLetraMayuscula : IReglasDeValidacion
{
    public bool EsValida(string contrasena)
    {
        return contrasena.Any(char.IsUpper);
    }

    public string MensajeError { get; }
}