using FluentAssertions;
using ValidarContrasena.Core;
using ValidarContrasena.Core.Enums;
using ValidarContrasena.Core.Interfaces;
using ValidarContrasena.Core.Reglas;

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
    [Theory]
    [InlineData("xxxxxxxx", 6)]
    [InlineData("xxxxxxxxxxxxxxxxx", 16)]
    public void Si_ContrasenaTieneMasDeNCaracteres_Debe_RetornarTrue(string contrasena, int cantidadDigitos)
    {
        //Arrange
        ValidarContrasena validarContrasena =  new ValidarContrasena(contrasena);
        validarContrasena.CantidadCaracteres = cantidadDigitos;
        
        //Act
        bool contrasenaValida = validarContrasena.CantidadCaracteresValida();
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConUnaListaDeUnaRegla_Debe_RetornarTrue()
    {   
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaLongitudContrasena(8)
        };
        
        var validador = new ValidadorContrasena(reglas);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxxx");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConUnaListaDeNReglas_Debe_RetornarTrue()
    {
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaNoEsVacia(),
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo()
        };
        
        var validador = new ValidadorContrasena(reglas);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx1234_");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ValidacionEs2Contrasena_Debe_Validar6CaracteresLetraMayusculaLetraMinusculaYUnNumero()
    {
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaLongitudContrasena(6),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
        };
        
        var validador = new ValidadorContrasena(reglas);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx123_");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ValidacionEs3Contrasena_Debe_Validar16CaracteresLetraMayusculaLetraMinusculaYUnGuionBajo()
    {
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaLongitudContrasena(6),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneGuionBajo(),
        };
        
        var validador = new ValidadorContrasena(reglas);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx123_");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_SolicitanValidacion2_Debe_Validar6CaracteresLetraMayusculaLetraMinusculaYUnNumero()
    {
        //Arrange
        var validador = ValidarContrasenaFactory.CrearValidador(TipoValidadorContrasena.ValidadorDos);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx123");
        
        //Assert
        contrasenaValida.Should().BeTrue();

    }
    
    [Fact]
    public void Si_SolicitanValidacion3_Debe_Validar16CaracteresLetraMayusculaLetraMinusculaYUnGuionBajo()
    {
        //Arrange
        var validador = ValidarContrasenaFactory.CrearValidador(TipoValidadorContrasena.ValidadorTres);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx123_xxxxxxxxxx");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaNoCumpleReglas_Debe_DevolverListaDeErrores()
    {
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaNoEsVacia(),
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo(),
        };
        var validador = new ValidadorContrasena(reglas);

        //Act
        var contrasenaValida = validador.Validar("xxx");

        //Assert
        contrasenaValida.EsValida.Should().BeFalse();
        contrasenaValida.Errores.Should().Contain("La contraseña debe contener almenos un numero");
        contrasenaValida.Errores.Should().Contain("La contraseña debe contener almenos una letra mayuscula");
    }
    
}