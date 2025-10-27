using ValidarContrasena.Core.Enums;
using ValidarContrasena.Core.Interfaces;
using ValidarContrasena.Core.Reglas;

namespace ValidarContrasena.Core;

public static class ValidarContrasenaFactory
{
    public static ValidadorContrasena CrearValidador(TipoValidadorContrasena tipo)
    {
        return tipo switch
        {
            TipoValidadorContrasena.ValidadorUno => CrearValidadorUno(),
            TipoValidadorContrasena.ValidadorDos => CrearValidadorDos(),
            TipoValidadorContrasena.ValidadorTres => CrearValidadorTres(),
            TipoValidadorContrasena.ValidadorCuatro => CrearValidadorCuatro(),
            _ => throw new ArgumentException("Tipo de validador no soportado")
        };
    }

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
        
        return new ValidadorContrasena(reglas, new EstrategiaCumpleTodasLasReglas());
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
        
        return new ValidadorContrasena(reglas, new EstrategiaCumpleTodasLasReglas());
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
        
        return new ValidadorContrasena(reglas, new EstrategiaCumpleTodasLasReglas());
    }
    
    public static ValidadorContrasena CrearValidadorCuatro()
    {
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>()
        {
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneGuionBajo(),
        };
        
        return new ValidadorContrasena(reglas, new EstrategiaPermiteUnaFalla());
    }
}