using FluentAssertions;

namespace KataContrasena.Test;

public class ValidarContrasenaTest
{
    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiNoEsVacia()
    {
        //Arrange
        ValidarContrasena validarContrasena = new ValidarContrasena("xxx");
        //Act
        bool contrasenaValida = validarContrasena.NoEstaVacia();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneMasDeOchoCaracteres()
    {
        //Arrange
        ValidarContrasena validarContrasena = new ValidarContrasena("xxxxxxxxx");
        //Act
        bool contrasenaValida = validarContrasena.CantidadCaracteresValida();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMayuscula()
    {
        //Arrange
        ValidarContrasena validarContrasena = new ValidarContrasena("Xxxxx");
        //Act
        bool contrasenaValida = validarContrasena.ContieneLetraMayuscula();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMinuscula()
    {
        //Arrange
        ValidarContrasena  validarContrasena = new ValidarContrasena("Xxxxx");
        
        //Act
        bool contrasenaValida = validarContrasena.ContieneLetraMinuscula();
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnNumero()
    {
        //Arrange
        ValidarContrasena validarContrasena = new ValidarContrasena("Xxxx1");
        //Act
        bool contrasenaValida = validarContrasena.ContieneNumero();
        
        //Assert
        contrasenaValida.Should().BeTrue();

    }
}

public class ValidarContrasena
{
    private readonly string _contrasena;
    
    private const int CantidadCaracteres = 8;
    
    public ValidarContrasena(string contrasena)
    { 
        _contrasena =  contrasena;
    }

    public bool NoEstaVacia()
    {
        return !string.IsNullOrEmpty(_contrasena);
    }

    public bool CantidadCaracteresValida()
    {
        return _contrasena.Length > CantidadCaracteres;
    }

    public bool ContieneLetraMayuscula()
    {
        return _contrasena.Any(char.IsUpper);
    }

    public bool ContieneLetraMinuscula()
    {
        return _contrasena.Any(char.IsLower);
    }

    public bool ContieneNumero()
    {
        return _contrasena.Any(char.IsDigit);
    }
}