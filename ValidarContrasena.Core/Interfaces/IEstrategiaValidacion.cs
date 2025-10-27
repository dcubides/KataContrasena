namespace ValidarContrasena.Core;

public interface IEstrategiaValidacion
{
    bool EsValida(List<string> errores, int totalReglas);
}