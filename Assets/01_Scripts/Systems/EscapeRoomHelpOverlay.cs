using UnityEngine;

public class EscapeRoomHelpOverlay : MonoBehaviour
{
    [SerializeField] private bool showControls = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            showControls = !showControls;
        }
    }

    private void OnGUI()
    {
        if (!showControls)
        {
            return;
        }

        GUI.Box(new Rect(16f, 16f, 440f, 180f), "CONTROLES DEL JUEGO");
        GUI.Label(new Rect(30f, 50f, 410f, 130f),
            "WASD / Flechas: moverse\n" +
            "E: interactuar\n" +
            "O: puerta\n" +
            "P: comprobar codigo\n\n" +
            "Pulsa H para ocultar o volver a mostrar esta ayuda.");
    }
}