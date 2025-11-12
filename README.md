# Punteria - Juego en Unity

**Repositorio:** [Punteria-Juego](https://github.com/Alejandro-Moreira/Punteria-Juego.git)  
**Autor:** Alejandro Moreira  
**Plataforma:** Unity 2022 (3D)  
**Enlace de juego online:** [Itch.io - Puntería](https://alejandrom11.itch.io/punteria)  
**Video demostrativo:** [Ver video](https://udlaec-my.sharepoint.com/:v:/g/personal/alejandro_moreira_udla_edu_ec/ERs1B9H9zVhBsH8YGN0q7fUBGqCWV034q7NI86FuNv8L6g?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=p0sbDZ)

## Descripción
**Puntería** es un prototipo de videojuego 3D desarrollado en Unity, cuyo objetivo es practicar la **organización y gestión de datos mediante listas (`List<T>`) y diccionarios (`Dictionary<K,V>`)** en C#.  
A través de mecánicas simples de disparo e inventario, se demuestra cómo estas estructuras de datos pueden mejorar la eficiencia y flexibilidad en el manejo de enemigos, objetos y efectos dentro del juego.

## Objetivo General
Comprender cómo usar **listas y diccionarios en Unity** para organizar datos de manera eficiente y aplicarlos en mecánicas básicas de videojuegos.

## Contenidos de Aprendizaje

### 1. Introducción a Colecciones en C#
- Diferencia entre *arrays*, *listas* y *diccionarios*.
- Ventajas de `List` y `Dictionary` en videojuegos.

### 2. Listas en Unity
- Declaración y uso de `List<T>`.
- Métodos comunes: `Add()`, `Remove()`, `Count`, `ForEach`.
- **Ejemplo:** Lista de enemigos activos → instanciación y eliminación dinámica.

### 3. Diccionarios en Unity
- Declaración y uso de `Dictionary<K,V>`.
- Métodos comunes: `Add()`, `ContainsKey()`, `TryGetValue()`.
- **Ejemplo:** Diccionario de ítems (nombre → efecto).

### 4. Ejemplo Integrador – Mini Inventario
- Lista para guardar ítems obtenidos.
- Diccionario que asocia ítems con sus efectos.
- UI básica con `Text` o `TextMeshPro`.
- Al presionar una tecla, se usa un ítem aplicando su efecto.

## Actividades Implementadas

### Actividad 1 – Enemigos en Lista
- Creación de prefab de enemigo.
- Instanciación y agregado dinámico a una `List<GameObject>`.
- Eliminación del enemigo al ser destruido.

### Actividad 2 – Inventario Integrador
- Cada ítem recogido se agrega a la lista de inventario.
- Se muestra en pantalla mediante UI.
- Al presionar una tecla numérica (1, 2), se usa el ítem seleccionado.
- El efecto se obtiene desde el diccionario asociado.

## Entrega Final

**Demostración del proyecto incluye:**
- Enemigos agregados y eliminados de una lista.
- Diccionario funcional con ítems.
- Inventario interactivo con uso de objetos.

 **Versión jugable:** [https://alejandrom11.itch.io/punteria](https://alejandrom11.itch.io/punteria)  
 **Video demostrativo:** [Ver video](https://udlaec-my.sharepoint.com/:v:/g/personal/alejandro_moreira_udla_edu_ec/ERs1B9H9zVhBsH8YGN0q7fUBGqCWV034q7NI86FuNv8L6g?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=p0sbDZ)

## Cómo Clonar y Ejecutar el Proyecto

1. **Clona el repositorio**
   ```bash
   git clone https://github.com/Alejandro-Moreira/Punteria-Juego.git
