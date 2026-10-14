# Pruebas de Unity — casos 15, 16 y 17

Abre `Assets/00_Scenes/MainScene.unity`, espera a que compile y ejecuta una vez **Escape Room > Configure Main Scene for Cases 15-17**. Repite las pruebas desde Play Mode nuevo cuando cambie la rama o se resuelva un merge.

| ID | Acción | Resultado esperado |
|---|---|---|
| T15-01 | Abrir MainScene | Player, Chest, Door, PuzzleSystem y Main Camera están en Hierarchy; no hay Missing Script |
| T15-02 | Mover con WASD y flechas | Player avanza sin movimiento diagonal más rápido y gira hacia el avance |
| T15-03 | Pulsar E sin mirar un objeto | No se produce interacción |
| T15-04 | Mirar al Chest y pulsar E antes de resolver puzzle | Console indica que el cofre está cerrado |
| T15-05 | Seleccionar PuzzleSystem, poner Entered Code = 0 y pulsar P | Console indica código incorrecto; cofre sigue cerrado |
| T15-06 | Poner Entered Code = 1234 y pulsar P; mirar Chest y pulsar E | Puzzle resuelto; cofre se abre y aparece Key |
| T15-07 | Mirar Key y pulsar E; luego mirar Door y pulsar E | Se obtiene llave y Door gira; sin llave Door no abre |
| T15-08 | Revisar Console | No hay errores críticos ni referencias Missing |
| T16-01 | Ejecutar merge intencional con Accept Both y entrar a Play | `Initialization Calls` mayor que 1 y aparece error de inicialización duplicada |
| T16-02 | Dejar una sola llamada y volver a Play | `Initialization Calls` = 1; error duplicado desaparece |
| T17-01 | Con la versión defectuosa publicada, recoger llave e interactuar con Door | Se observa que Door no gira |
| T17-02 | Tras `git revert` y push, empezar Play de nuevo y repetir | Door gira y Console confirma apertura |

Registra el resultado real (Aprobado/Falló), versión de Unity y observaciones en `EVIDENCIAS_CASOS_15_17.md`. Una prueba prevista no cuenta como prueba ejecutada.
