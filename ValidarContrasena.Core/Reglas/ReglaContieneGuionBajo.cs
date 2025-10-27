
using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaContieneGuionBajo : IReglasDeValidacion
{
    public bool EsValida(string contrasena)
    {
        return contrasena.Contains('_');
    }
}