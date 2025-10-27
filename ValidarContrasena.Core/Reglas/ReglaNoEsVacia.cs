using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaNoEsVacia : IReglasDeValidacion
{
    public bool EsValida(string contrasena)
    {
        return !string.IsNullOrEmpty(contrasena);
    }

    public string MensajeError { get; }
}