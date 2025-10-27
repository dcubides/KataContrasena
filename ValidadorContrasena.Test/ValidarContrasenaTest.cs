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
}

public class ValidarContrasena
{
    public ValidarContrasena(string xxx)
    { 
    }

    public bool NoEstaVacia()
    {
        return true;
    }
}