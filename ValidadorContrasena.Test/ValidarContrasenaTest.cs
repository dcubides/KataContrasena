using FluentAssertions;
using ValidarContrasena.Core;
using ValidarContrasena.Core.Enums;
using ValidarContrasena.Core.Interfaces;
using ValidarContrasena.Core.Reglas;

namespace KataContrasena.Test;

public class ValidarContrasenaTest
{
    private readonly List<IReglasDeValidacion> _reglas;
    public ValidarContrasenaTest()
    {
        _reglas = new();
    }
    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiNoEsVacia()
    {
        //Arrange
        _reglas.Add(new ReglaNoEsVacia());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxx");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneMasDeOchoCaracteres()
    {
        //Arrange
        _reglas.Add(new ReglaLongitudContrasena(8));
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxxx");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMayuscula()
    {
        //Arrange
        _reglas.Add(new ReglaContieneLetraMayuscula());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxxxxxx");
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnaLetraMinuscula()
    {
        //Arrange
        _reglas.Add(new ReglaContieneLetraMinuscula());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxx");
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnNumero()
    {
        //Arrange
        _reglas.Add(new ReglaContieneNumero());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxx5");
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_IngresaContrasena_Debe_RetornarTrueSiContieneUnGuionBajo()
    {
        //Arrange
        _reglas.Add(new ReglaContieneGuionBajo());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxx5_");
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConTodasLasValidaciones_Debe_RetornarTrue()
    {
        //Arrange
      
        _reglas.AddRange(
            new ReglaNoEsVacia(),
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo()
        );
        
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxxxxxx5_");
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
        _reglas.Add(new ReglaLongitudContrasena(cantidadDigitos));
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida(contrasena);
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConUnaListaDeUnaRegla_Debe_RetornarTrue()
    {   
        //Arrange
        _reglas.Add(new ReglaLongitudContrasena(8));
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("xxxxxxxxx");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ContrasenaCumpleConUnaListaDeNReglas_Debe_RetornarTrue()
    {
        //Arrange
        _reglas.AddRange(
            new ReglaNoEsVacia(),
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo());
        
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx1234_");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ValidacionEs2Contrasena_Debe_Validar6CaracteresLetraMayusculaLetraMinusculaYUnNumero()
    {
        //Arrange
        _reglas.AddRange(
            new ReglaLongitudContrasena(6),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneNumero()
        );
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxx123_");
        
        //Assert
        contrasenaValida.Should().BeTrue();
    }

    [Fact]
    public void Si_ValidacionEs3Contrasena_Debe_Validar16CaracteresLetraMayusculaLetraMinusculaYUnGuionBajo()
    {
        //Arrange
        _reglas.AddRange(
            new ReglaLongitudContrasena(16),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneLetraMinuscula(),
            new ReglaContieneGuionBajo());
        var validador = new ValidadorContrasena(_reglas, null);
        
        //Act
        bool contrasenaValida = validador.EsValida("Xxxxxxxxxxxxx123_");
        
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
       
        var estrategia = new EstrategiaCumpleTodasLasReglas();
        var validador = new ValidadorContrasena(reglas, estrategia);

        //Act
        var contrasenaValida = validador.Validar("xxx");

        //Assert
        contrasenaValida.EsValida.Should().BeFalse();
        contrasenaValida.Errores.Should().Contain("La contraseña debe contener almenos un numero");
        contrasenaValida.Errores.Should().Contain("La contraseña debe contener almenos una letra mayuscula");
    }

    [Fact]
    public void Si_ContrasenaCumpleTodasLasReglasMenosUna_Debe_RetornarTrue()
    {
        //Arrange
        List<IReglasDeValidacion> reglas = new List<IReglasDeValidacion>
        {
            new ReglaLongitudContrasena(8),
            new ReglaContieneLetraMayuscula(),
            new ReglaContieneNumero(),
            new ReglaContieneGuionBajo(),
        };
        
        var estrategia = new EstrategiaPermiteUnaFalla();
        
        var validador = new ValidadorContrasena(reglas, estrategia);
        
        //Act
        var contrasenaValida = validador.Validar("Xxxxxx123");
        
        //Assert
        contrasenaValida.EsValida.Should().BeTrue();
        contrasenaValida.Errores.Should().Contain("La contraseña debe contener un guion bajo");
    }
    
}