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
}

public class ValidarContrasena
{
    private readonly string _contrasena;
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
        throw new NotImplementedException();
    }
}