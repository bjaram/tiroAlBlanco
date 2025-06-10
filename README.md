# Tarea 3 - Tiro al blanco (simple)

Este es un proyecto básico de juego desarrollado en Unity donde el jugador dispara proyectiles para destruir cubos en movimiento. El objetivo es eliminar todos los cubos y alcanzar la victoria. Ideal como base para entender colisiones, movimiento interpolado, UI y lógica de juego.

## 🎮 Mecánicas del Juego

- El jugador dispara proyectiles (`balas`) hacia cubos.
- Los cubos se mueven horizontalmente de derecha a izquierda con efecto de ease-in-out, y vuelven en un movimiento repetitivo.
- Si una bala colisiona con un cubo, **ambos se destruyen**.
- Cuando **todos los cubos han sido destruidos**, aparece un mensaje: **"¡Ganaste!"**.
- Puedes presionar **`R`** para reiniciar el nivel en cualquier momento.

## 🧠 Lo que este proyecto enseña

- Uso de `Rigidbody` y `Collider` para detectar colisiones.
- Cómo aplicar `Destroy()` y gestionar la sincronización entre objetos destruidos.
- Mostrar mensajes en pantalla con `TextMeshProUGUI`.
- Control de flujo de victoria y reinicio de juego.
- Movimiento interpolado (con `Mathf.PingPong`, `Lerp`, etc.).
- Comunicación entre scripts.

## 🚀 Controles

| Acción                 | Tecla/Comando   |
|------------------------|-----------------|
| Disparar proyectil     | Click del mouse |
| Reiniciar el juego     | `R`             |

## 📦 Dependencias

- Unity 2021.3+ (aunque puede funcionar en versiones anteriores)
- TextMeshPro (incluido por defecto en Unity)

## ✅ Estado del Proyecto

✔️ Funcional  
🔜 Podría expandirse con:  
- Sistema de puntuación  
- Sonido al disparar o destruir  
- Animaciones  
- Niveles múltiples

## 🧪 Cómo probarlo

1. Abre el proyecto en Unity.
2. Ejecuta la escena principal `SampleScene.unity`.
3. Dispara y destruye todos los cubos.
4. Lee los mensajes en pantalla y presiona `R` para reiniciar.

---

### 🎓 Bryan Jara Miranda / Estudiante la universidad de Cenfotec

Este proyecto fue desarrollado como una práctica de aprendizaje en Unity para entender cómo manejar colisiones, instanciación de objetos, mensajes UI y lógica de victoria.  