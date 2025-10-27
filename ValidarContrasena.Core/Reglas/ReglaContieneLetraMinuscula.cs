using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaContieneLetraMinuscula : IReglasDeValidacion
{
    public bool EsValida(string contrasena)
    {
        return contrasena.Any(char.IsLower);
    }
}