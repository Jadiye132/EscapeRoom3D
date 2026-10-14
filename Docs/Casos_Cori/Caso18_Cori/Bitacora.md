# Bitácora — Caso 18 · Ayelen Cori

**Estado:** recuperación realizada y verificada en Unity.

| Campo | Resultado |
|---|---|
| Rama de simulación | `Feature_Cori_Caso18` |
| Hash del commit de recuperación | `c3b2f00a540cab2d259b114edb59989023513a6d` |
| Operación de pérdida | `git reset --hard HEAD~1` |
| Indicación o autorización del docente | No recibí una autorización específica del docente para esta operación |
| Fecha y hora de la operación | Oct 14 09:31:11 2026|
| Entrada encontrada en `git reflog` | Commit `c3b2f00`, con el mensaje `test: recovery point` |
| Rama restaurada | `Feature_Cori_Caso18_Recuperada` |
| Confirmación de `RECOVERY_TEST.md` | El archivo volvió a aparecer en la carpeta principal del proyecto y pude consultar su contenido. |
| Resultado al abrir Unity | Abrí `MainScene` y ejecuté la escena. Durante la comprobación, la consola mostró 0 errores y 0 advertencias. |
| Evidencia del estado de pérdida | Evidencia 18.2: resultado del Reset e historial sin el commit de prueba. |
| Evidencia del reflog | Evidencia 18.3: localización del commit de recuperación en Reflog. |
| Evidencia de la recuperación | Evidencia 18.4: rama recuperada, commit y archivo restaurado. |
| Publicación en GitHub | La rama recuperada quedó sincronizada con `origin/Feature_Cori_Caso18_Recuperada`. |

**¿Qué ocurrió?**

Creé el archivo `RECOVERY_TEST.md` y lo guardé en el commit `test: recovery point`. Después simulé la pérdida mediante un Reset al commit anterior. El archivo desapareció de la carpeta y el commit dejó de aparecer en el historial de la rama.

**¿Por qué ocurrió?**

El Reset movió la rama al commit anterior y ajustó los archivos a ese estado. El commit de prueba dejó de formar parte del historial de esa rama, pero todavía podía localizarse mediante Reflog.

**¿Cómo se recuperó?**

Busqué el commit con `git reflog` y lo identifiqué por su hash y su mensaje. Luego creé la