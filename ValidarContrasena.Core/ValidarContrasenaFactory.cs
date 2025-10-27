using ValidarContrasena.Core.Interfaces;
using ValidarContrasena.Core.Reglas;

namespace ValidarContrasena.Core;

public static class ValidarContrasenaFactory
{
    public static ValidadorContrasena CrearValidadorUno()
    {
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>()
        {
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo(),
        };
        
        return new ValidadorContrasena(reglas);
    }
    public static ValidadorContrasena CrearValidadorDos()
    {
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>()
        {
            new ReglaLongitudContrasena(6),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
        };
        
        return new ValidadorContrasena(reglas);
    }

    public static ValidadorContrasena CrearValidadorTres()
    {
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>()
        {
            new ReglaLongitudContrasena(6),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneGuionBajo(),
        };
        
        return new ValidadorContrasena(reglas);
    }
}