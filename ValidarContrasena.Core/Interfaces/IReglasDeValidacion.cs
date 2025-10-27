namespace ValidarContrasena.Core.Interfaces;

public interface IReglasDeValidacion
{
    bool EsValida(string contrasena);
    string MensajeError { get; }
}