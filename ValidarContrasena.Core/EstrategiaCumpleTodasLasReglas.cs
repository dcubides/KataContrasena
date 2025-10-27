namespace ValidarContrasena.Core;

public class EstrategiaCumpleTodasLasReglas: IEstrategiaValidacion
{
    public bool EsValida(List<string> errores, int totalReglas)
    {
        return errores.Count == 0;
    }
}