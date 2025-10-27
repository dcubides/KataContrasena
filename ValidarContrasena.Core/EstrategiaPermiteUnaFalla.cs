namespace ValidarContrasena.Core;

public class EstrategiaPermiteUnaFalla: IEstrategiaValidacion
{
    public bool EsValida(List<string> errores, int totalReglas)
    {
        return errores.Count <= 1;
    }
}