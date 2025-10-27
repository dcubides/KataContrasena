using ValidarContrasena.Core.Interfaces;

namespace ValidarContrasena.Core;

public class ValidadorContrasena
{
    private readonly List<IReglasDeValidacion> _reglas;
    private readonly IEstrategiaValidacion _estrategia;
    public ValidadorContrasena(List<IReglasDeValidacion> reglas, IEstrategiaValidacion? estrategia)
    {
        _reglas =  reglas;
        _estrategia = estrategia;
    }

    public bool EsValida(string contrasena)
    {
        return _reglas.All(reglas => reglas.EsValida(contrasena));
    }

    public ResultadoValidacion Validar(string contrasena)
    {
        //var resultado = new ResultadoValidacion();
        var listaErrores = new List<string>();

        foreach (var regla in _reglas)
        {
            if (!regla.EsValida(contrasena))
            {
                listaErrores.Add(regla.MensajeError);
            }
        }
        
        bool esValida = _estrategia.EsValida(listaErrores, _reglas.Count);

        return new ResultadoValidacion
        {
            EsValida = esValida,
            Errores = listaErrores
            
        };
    }
}

public class ResultadoValidacion
{
    public bool EsValida { set; get; }
    public List<string> Errores { get; set; }

    public ResultadoValidacion()
    {
        Errores = new List<string>();
        EsValida = !Errores.Any();
    }

    public void AgregarError(string mensaje)
    {
        Errores.Add(mensaje);
    }
}