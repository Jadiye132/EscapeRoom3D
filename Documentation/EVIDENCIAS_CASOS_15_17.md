# Bitácora y evidencias — casos 15, 16 y 17

**Equipo:** EscapeRoom3D
**Repositorio:** `Jadiye132/EscapeRoom3D`
**Integrante:** Yubidsa
**Fecha de ejecución:** ____________________
**Versión de Unity:** ____________________
**Rama personal:** `yubidsa`

> Completa resultados, hashes, participantes y enlaces después de ejecutar cada operación. No escribas hashes ni resultados supuestos.

## Caso 15 — Conflictos en varios archivos

**Responsables reales:** A ____________________ · B/Yubidsa · integración ____________________ · QA ____________________
**Rama A:** ____________________ · **Rama B:** `yubidsa` · **Rama de integración:** `Dev`
**Commit A:** ____________________ · **Commit B:** ____________________ · **Merge:** ____________________

**Problema provocado:** dos ramas creadas desde la misma base modificaron bloques coincidentes de `PlayerController.cs`, `Player.prefab` y `MainScene.unity`. Source Control mostró tres conflictos.

**Resolución realizada:** en el controlador se conservaron movimiento normalizado, giro y una sola lectura de E; en el prefab se preservaron sus componentes y `speed: 6`; en la escena se conservaron Player, Chest, Door, PuzzleSystem y Main Camera, con Player en X = 0. Se stagearon los archivos resueltos y se completó el merge.

**Pruebas reales:** movimiento ____ · interacción ____ · código incorrecto ____ · puzzle/código 1234 ____ · cofre/llave ____ · puerta ____ · Console sin errores ____.

**Evidencias guardadas:** `15_01_ramas.png` ____ · `15_02_conflictos.png` ____ · `15_03_PlayerController.png` ____ · `15_04_PlayerPrefab.png` ____ · `15_05_MainScene.png` ____ · `15_06_Unity_PlayMode.png` ____ · `15_07_limpio.png` ____.

**Reflexión:** Git marca conflictos por archivo; una decisión no resuelve los otros. El Merge Editor permite combinar cambios, pero Unity debe validar los componentes, referencias y comportamiento.

## Caso 16 — Accept Both rompe el juego

**Responsables reales:** A ____________________ · B ____________________ · integración ____________________ · QA ____________________
**Ramas:** ____________________ · **Commit de corrección:** ____________________

**Problema provocado:** Accept Both dejó varias llamadas a `GameManager.Initialize()` dentro de `Awake`. La prueba real mostró `Initialization Calls` = ____ y el mensaje de Console: ____________________.

**Corrección realizada:** se editó el resultado para conservar exactamente una llamada a Initialize, se guardó, stageó y completó el merge.

**Resultado después de corregir:** `Initialization Calls` = ____ · Error duplicado desapareció: ____ · Juego probado: ____.

**Evidencias guardadas:** `16_01_conflicto.png` ____ · `16_02_accept_both.png` ____ · `16_03_error_unity.png` ____ · `16_04_correccion.png` ____ · `16_05_unity_final.png` ____.

**Reflexión:** Accept Both solo combina líneas de texto. No sabe si dos llamadas duplican inicialización ni puede decidir si la lógica sigue correcta.

## Caso 17 — Revert de un cambio compartido

**Líder:** Yubidsa · **Autor del defecto:** ____________________ · **QA:** ____________________
**Rama compartida:** `Dev` · **Commit defectuoso:** ____________________ · **Commit Revert:** ____________________

**Problema provocado:** el commit defectuoso dejó el ángulo de apertura de la puerta en cero. Después de publicar, Unity mostró: ____________________.

**Resolución realizada:** se seleccionó el commit publicado y se creó un nuevo commit Revert. No se eliminó ni se reescribió el commit original. Ambos commits permanecen en History.

**Prueba posterior al Revert:** la puerta volvió a girar ____ · llave requerida ____ · Console sin errores ____ · push de Dev comprobado ____.

**Evidencias guardadas:** `17_01_commit_defectuoso.png` ____ · `17_02_puerta_rota.png` ____ · `17_03_revert.png` ____ · `17_04_history.png` ____ · `17_05_puerta_funcional.png` ____.

**Reflexión:** Revert añade un commit compensatorio y mantiene intacta la historia compartida, por eso el equipo puede ver qué se introdujo y cuándo se deshizo.

## Cómo tomar y guardar las capturas

- Windows: pulsa **Win + Shift + S** y selecciona la ventana completa o el área necesaria. Mac: **Shift + Command + 4**. Guarda PNG, sin tapar rama, nombre de archivo, repositorio o mensaje relevante.
- En VS Code, incluye la barra de rama y Source Control/Merge Editor. En Unity, incluye Hierarchy, Game view y Console/Inspector según la prueba.
- Guarda los PNG dentro de `Evidencias/Casos15-17/` con los nombres indicados arriba y añade esa carpeta al commit de evidencias.
- No uses una captura de una instrucción como evidencia del resultado. La imagen debe mostrar la operación que ocurrió en tu sesión.
