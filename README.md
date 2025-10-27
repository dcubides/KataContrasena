# 🔐 Kata: Validación de Contraseña (Password Validator)

Este proyecto implementa una **kata de validación de contraseñas** utilizando **.NET 9** y **Test Driven Development (TDD)**.  
El objetivo es practicar principios de diseño limpio, refactorización progresiva y escritura de pruebas automatizadas en C#.

---

## 🧠 Objetivo de la Kata

Desarrollar una clase `ValidadorDeContrasena` capaz de validar contraseñas según un conjunto de reglas definidas.  
Por ejemplo:

- La contraseña no debe estar vacía.
- Debe tener al menos 8 caracteres.
- Debe contener al menos una letra mayúscula.
- Debe contener al menos una letra minúscula.
- Debe contener al menos un número.
- Debe contener un guion bajo

El enfoque de TDD implica **escribir primero una prueba que falle**, luego implementar la mínima cantidad de código necesaria para pasarla, y finalmente **refactorizar** manteniendo todas las pruebas verdes.

---

## ⚙️ Tecnologías utilizadas

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- C#
- xUnit para pruebas unitarias
- FluentAssertions para mejorar la legibilidad de las pruebas


