namespace KataContrasena.Test;

public class ValidarContrasena
{
    private readonly string _contrasena;

    public int CantidadCaracteres = 8;
    
    public ValidarContrasena(string contrasena)
    { 
        _contrasena =  contrasena;
    }

    public bool NoEstaVacia() => !string.IsNullOrEmpty(_contrasena);
    public bool CantidadCaracteresValida() => _contrasena.Length > CantidadCaracteres;

    public bool ContieneLetraMayuscula() => _contrasena.Any(char.IsUpper);

    public bool ContieneLetraMinuscula() => _contrasena.Any(char.IsLower);

    public bool ContieneNumero() => _contrasena.Any(char.IsDigit);

    public bool ContieneUnGuionBajo() => _contrasena.Contains('_');

    public bool EsValida()
    {
        return  NoEstaVacia() &&
                CantidadCaracteresValida() &&
                ContieneLetraMayuscula() &&
                ContieneLetraMinuscula() &&
                ContieneNumero() &&
                ContieneUnGuionBajo();
    }
}