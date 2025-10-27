using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core.Reglas;

public class ReglaLongitudContrasena : IReglasDeValidacion
{
    private readonly int _cantidadCaracteres;
    public ReglaLongitudContrasena(int cantidadCaracteres)
    {
        _cantidadCaracteres = cantidadCaracteres;
    }

    public bool EsValida(string contrasena)
    {
        return  contrasena.Length > _cantidadCaracteres;
    }
}