# Entrega de Yubidsa — casos 15, 16 y 17

Repositorio: [Jadiye132/EscapeRoom3D](https://github.com/Jadiye132/EscapeRoom3D)

## Base real descargada

Se descargó el repositorio completo, con historial y todas sus ramas remotas. Para continuar los casos se usa `Dev`, no `main`: al descargar esta copia, `origin/Dev` estaba en `c26857f` (documentación del caso 14) y `main` seguía en `e6403c0` (commit inicial). La única rama con cambios propios por delante de `Dev` era `Feature_Puzzle`; se incorporó su cambio `53bcb9c`, que permite elegir la tecla del puzzle (`solveKey`, P por defecto). El proyecto usa Unity `6000.5.5f1`, el sistema de entrada está en modo Both y `MainScene` ya contiene `Player`, `Chest`, `Door` y `PuzzleSystem`. `Player.prefab` contiene `PlayerController`, `PlayerInteraction`, `CapsuleCollider` y `Animator`.

Los controladores originales de interacción y puerta eran prototipos: E solo mostraba un mensaje y la puerta respondía a O. Esta entrega completa la interacción para usar E, conectar puzzle-cofre-llave-puerta y mantener una comprobación de inicialización útil para el caso 16.

## Rama y responsabilidad

La rama individual de Yubidsa es `yubidsa`, creada desde `Dev`. En el caso 15, Yubidsa aporta la rama B; Ayelen prepara la rama A; Alejandro integra y Erick hace QA según el plan del equipo. Yubidsa lidera el caso 17 y participa en el caso 16.

La copia entregada modifica estos tres archivos compartidos para el caso 15:

| Archivo | Cambio preparado en `yubidsa` | Valor final recomendado tras integrar |
|---|---|---|
| `Assets/01_Scripts/Player/PlayerController.cs` | Movimiento normalizado y orientación hacia el movimiento; E se deja a `PlayerInteraction` | Mantener normalización, movimiento y giro; sin registros por frame |
| `Assets/02_Prefabs/Player.prefab` | `speed: 6` | `speed: 6` |
| `Assets/00_Scenes/MainScene.unity` | Spawn del Player en X = `0.5` | X = `0` al resolver el conflicto |

### Corrección necesaria para el caso 15

La guía asigna A a `PlayerController + Player.prefab` y B a `PlayerController + MainScene`, pero pide conflictos en los tres archivos. Con esa distribución solo hay edición concurrente en `PlayerController`: un archivo que cambia en una sola rama normalmente se integra sin conflicto. Para producir y capturar los tres conflictos, A también debe cambiar la posición del Player en `MainScene`, y la rama B de Yubidsa debe modificar el mismo valor de `speed` en `Player.prefab`. Esos dos cambios ya están preparados aquí. Ambas ramas deben partir del mismo `Dev` y editar las mismas líneas para que Git solicite una resolución.

## Caso 15 — conflictos en varios archivos

### Preparación de ramas

1. Actualiza `Dev` con el estado acordado por el equipo.
2. Crea `Feature_Caso15_A` desde ese `Dev`. En esa rama, Ayelen cambia `PlayerController`, `Player.prefab` (por ejemplo `speed: 10`) y el X del Player en `MainScene` (por ejemplo `-0.5`). Guarda y hace un commit real.
3. Yubidsa trabaja en `yubidsa`, que debe tener la misma base de `Dev`. Esta copia ya tiene los cambios B: movimiento, `speed: 6` y X = `0.5`. Revisa el diff y crea el commit de la rama B.
4. Cada autor publica su propia rama. No se deben escribir commits en nombre de otra persona.
5. Alejandro actualiza `Dev`, integra primero A y después `yubidsa`. Al segundo merge debe aparecer conflicto en `PlayerController.cs`, `Player.prefab` y `MainScene.unity` porque ambos lados cambiaron los mismos bloques.

### Resolución y resultado

- En `PlayerController.cs`, conserva el movimiento de ambos cambios: lectura de ejes, normalización diagonal y giro hacia la dirección de avance. E queda a cargo de `PlayerInteraction`; no dejes dos lectores de E.
- En `Player.prefab`, conserva todos los componentes y referencias (`PlayerController`, `PlayerInteraction`, `CapsuleCollider` y `Animator`) y deja `speed: 6`.
- En `MainScene.unity`, conserva `Player`, `Chest`, `Door`, `PuzzleSystem` y `Main Camera`; deja el spawn del Player en X = `0`.
- Guarda cada resultado, confirma que Source Control ya no muestre conflictos y completa el merge.
- Abre Unity, ejecuta el menú de preparación del README si aún no se ejecutó, guarda la escena y realiza todas las pruebas de `PRUEBAS_CASOS_15_17.md`.

### Evidencias

Captura el listado de los tres conflictos, el Merge Editor de cada archivo, el Inspector final del prefab, la jerarquía final de la escena, el working tree limpio y las pruebas del juego. Ver la lista de archivos modificados del merge no sustituye a la captura que muestra los conflictos.

## Caso 16 — Accept Both rompe el juego

`GameManager.Initialize()` se llama una vez desde `Awake`. También cuenta cuántas veces se invoca; si se duplica, registra un error en Unity Console. Ese control hace visible la resolución funcional incorrecta.

1. Parte del `GameManager` preparado en esta rama y acuerda una base común con el equipo.
2. En dos ramas, los autores añaden cada uno otra llamada `Initialize()` dentro del `Awake` existente, en la misma zona. Al aceptar Both se conserva más de una llamada (en esta base la llamada existente más las dos agregadas pueden dejar tres).
3. Reproduce el merge y pulsa Play. Confirma en Console el error “GameManager.Initialize se ejecutó más de una vez” y en el Inspector `Initialization Calls` mayor que 1.
4. Edita el resultado para dejar exactamente una llamada dentro de `Awake`, guarda y termina el merge.
5. Vuelve a Play. `Initialization Calls` debe ser 1 y no debe aparecer el error.

La cantidad observada se anota desde Unity; no se rellena anticipadamente. El objetivo es demostrar que Accept Both resuelve marcadores de texto, pero no comprueba el comportamiento.

## Caso 17 — Revert de un cambio compartido

Se ejecuta en `Dev` después de que el equipo acuerde la prueba y exista en esa rama el sistema de puerta de esta entrega.

1. Crea un commit deliberadamente defectuoso sobre `DoorController.cs`: dentro de `OpenDoor`, cambia `Quaternion.AngleAxis(openAngleDegrees, axis)` por `Quaternion.AngleAxis(0f, axis)`. El commit debe estar publicado en `Dev` antes de revertirlo.
2. Abre Unity, recoge la llave y prueba la puerta: el código marca el intento como abierto, pero el objeto no gira. Captura el fallo y anota el hash del commit defectuoso.
3. En History de VS Code/Git Graph o GitHub Desktop, selecciona ese commit y ejecuta **Revert**. Si la interfaz no ofrece el comando, usa la terminal integrada con `git revert <hash>`.
4. Revisa el cambio nuevo, crea el commit de revert y haz push de `Dev`.
5. Comprueba que History conserva tanto el commit defectuoso como el commit de revert. Abre una sesión nueva de Play Mode, recoge la llave y confirma que Door vuelve a girar.

No uses Reset ni borres el commit publicado. Al terminar el caso, la puerta debe funcionar y la historia debe contener ambos commits.

## Subir la rama a GitHub desde el proyecto Unity

Unity guarda los archivos; el commit y el push se hacen desde Source Control de Visual Studio Code, tal como pide la guía.

1. Clona el repositorio con GitHub Desktop o VS Code, o abre tu copia local existente.
2. En VS Code, cambia a `Dev` y actualízala con **Pull**.
3. Haz clic en el nombre de rama de la esquina inferior izquierda, selecciona **Create new branch**, escribe `yubidsa` y elige `Dev` como base.
4. Copia los archivos de esta entrega dentro de la raíz del clon local, reemplazando solo los que coinciden. Conserva intacta la carpeta `.git`.
5. Abre esa misma carpeta en Unity Hub. Abre `MainScene`, espera la compilación y ejecuta **Escape Room > Configure Main Scene for Cases 15-17**. Prueba el juego y guarda la escena.
6. Vuelve a VS Code, revisa los cambios y stagea `Assets`, `Documentation`, `README.md` y `Evidencias` si ya añadiste capturas. No stagees `Library`, `Temp` ni `Logs`.
7. Crea el commit `feat: prepare cases 15-17 and interaction`.
8. Selecciona **Publish Branch** o **Push**. Comprueba en GitHub que la rama `yubidsa` aparece y que su base es `Dev`.

Si GitHub rechaza el push por permisos, el propietario debe añadir la cuenta que hace push como colaboradora. No compartas contraseña ni códigos de verificación.
