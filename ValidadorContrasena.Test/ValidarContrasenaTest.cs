using FluentAssertions;

namespace KataContrasena.Test;

public class ValidarContrasenaTest
{
    private ValidarContrasena validarContrasena;
    public ValidarContrasenaTest()
    {
        validarContrasena = new ValidarContrasena("Xx1_xxxxxx");
    }
    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiNoEsVacia()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.NoEstaVacia();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneMasDeOchoCaracteres()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.CantidadCaracteresValida();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMayuscula()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.ContieneLetraMayuscula();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMinuscula()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.ContieneLetraMinuscula();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnNumero()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.ContieneNumero();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnGuionBajo()
    {
        //Arrange

        //Act
        bool contrasenaValida = validarContrasena.ContieneUnGuionBajo();
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConTodasLasValidaciones_Debe_RetornarTrue()
    {
        //Arrange
        
        //Act
        bool contrasenaValida = validarContrasena.EsValida();
        //Assert
        contrasenaValida.Should().BeTrue();
    }
    
    //Segunda iteracion
    [Fact]
    
    public void Si_ContrasenaTieneMasDe6Caracteres_Debe_RetornarTrue()
    {
        //Arrange
        ValidarContrasena validarContrasena =  new ValidarContrasena("xxxxxxx");
        validarContrasena.CantidadCaracteres = 6;
        
        //Act
        bool contrasenaValida = validarContrasena.CantidadCaracteresValida();
        //Assert
        contrasenaValida.Should().BeTrue();
    }
}



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