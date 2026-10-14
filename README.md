# Escape Room 3D — entrega de Yubidsa

Proyecto de Unity del repositorio `Jadiye132/EscapeRoom3D`. Esta entrega parte de `Dev` en el commit `c26857f` (estado del caso 14), conserva el ajuste pendiente de tecla de `Feature_Puzzle` y prepara el trabajo de Yubidsa para los casos 15, 16 y 17.

## Integrantes

1. Ayelen
2. Yubidsa
3. Adrian
4. Alejandro Lazcano Estrella
5. Erick Ferrel Limachi

## Objetivo

Desarrollar un Escape Room 3D colaborativo donde el jugador explora, resuelve un código, abre un cofre, obtiene una llave y escapa por la puerta.

## Herramientas

- Unity 6000.5.5f1
- Visual Studio Code
- Git y GitHub

## Controles

- **WASD o flechas:** mover al jugador.
- **E:** interactuar con el objeto que está frente a la cámara.
- **P:** comprobar el código del puzzle.
- Código correcto: **1234**. En Play Mode, selecciona `PuzzleSystem` y cambia `Entered Code` a `1234`; después pulsa P.

## Preparar la escena una sola vez

1. Abre `Assets/00_Scenes/MainScene.unity` en Unity 6000.5.5f1.
2. Espera a que termine la compilación.
3. Ejecuta **Escape Room > Configure Main Scene for Cases 15-17**.
4. Guarda la escena si Unity lo solicita.

La configuración conecta `GameManager`, `ChestController`, `DoorController`, `KeyPickup` y la cámara. El puzzle desbloquea el cofre; al abrirlo aparece una llave; la llave permite abrir la puerta. La escena conserva los objetos que ya existían en `Dev`.

## Pruebas rápidas

1. En Play Mode, mueve al jugador con WASD.
2. En `PuzzleSystem`, pon `Entered Code = 0` y pulsa P: debe indicar código incorrecto.
3. Pon `Entered Code = 1234` y pulsa P: el cofre queda desbloqueado.
4. Mira hacia el cofre y pulsa E; recoge la llave que aparece.
5. Mira hacia la puerta y pulsa E; debe abrirse.
6. Comprueba que Unity Console no tenga errores.

## Archivos de la entrega

- `Documentation/ENTREGA_CASOS_15_17.md`: trabajo, ramas y pasos de integración.
- `Documentation/EVIDENCIAS_CASOS_15_17.md`: bitácora lista para completar con resultados, hashes y capturas reales.
- `Documentation/PRUEBAS_CASOS_15_17.md`: matriz de pruebas.
- `Assets/Editor/EscapeRoomSceneSetup.cs`: conecta los objetos existentes al menú de Unity indicado arriba.

Las capturas y hashes se completan después de ejecutar los merges y pruebas reales. No se incluyen evidencias inventadas.
