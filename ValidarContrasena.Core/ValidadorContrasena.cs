using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core;

public class ValidadorContrasena
{
    private readonly List<IReglasDeValidacion> _reglas;
    public ValidadorContrasena(List<IReglasDeValidacion> reglas)
    {
        _reglas =  reglas;
    }

    public bool EsValida(string contrasena)
    {
        return _reglas.All(reglas => reglas.EsValida(contrasena));
    }
}