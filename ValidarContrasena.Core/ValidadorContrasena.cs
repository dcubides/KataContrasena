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

    public ResultadoValidacion Validar(string contrasena)
    {
        var resultado = new ResultadoValidacion();

        foreach (var regla in _reglas)
        {
            if (!regla.EsValida(contrasena))
            {
                resultado.AgregarError(regla.MensajeError);
            }
        }

        return resultado;
    }
}

public class ResultadoValidacion
{
    public bool EsValida => !Errores.Any();
    public List<string> Errores { get; }

    public ResultadoValidacion()
    {
        Errores = new List<string>();
    }

    public void AgregarError(string mensaje)
    {
        Errores.Add(mensaje);
    }
}