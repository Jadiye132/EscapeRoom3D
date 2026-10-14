using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EscapeRoomSceneSetup
{
    [MenuItem("Escape Room/Configure Main Scene for Cases 15-17")]
    private static void ConfigureMainScene()
    {
        GameObject player = GameObject.Find("Player");
        GameObject chestObject = GameObject.Find("Chest");
        GameObject doorObject = GameObject.Find("Door");
        GameObject puzzleObject = GameObject.Find("PuzzleSystem");
        Camera mainCamera = Camera.main;

        if (player == null || chestObject == null || doorObject == null || puzzleObject == null || mainCamera == null)
        {
            EditorUtility.DisplayDialog(
                "Escape Room",
                "No se encontraron Player, Chest, Door, PuzzleSystem o MainCamera. Abre Assets/00_Scenes/MainScene.unity e inténtalo de nuevo.",
                "Aceptar");
            return;
        }

        GameManager gameManager = GetOrAdd<GameManager>(puzzleObject);
        ChestController chest = GetOrAdd<ChestController>(chestObject);
        DoorController door = GetOrAdd<DoorController>(doorObject);
        PuzzleManager puzzle = puzzleObject.GetComponent<PuzzleManager>();
        PlayerInteraction playerInteraction = GetOrAdd<PlayerInteraction>(player);
        PlayerCameraFollow cameraFollow = GetOrAdd<PlayerCameraFollow>(mainCamera.gameObject);

        OldDoorController oldDoor = doorObject.GetComponent<OldDoorController>();
        if (oldDoor != null)
        {
            Undo.DestroyObjectImmediate(oldDoor);
        }

        cameraFollow.SetTarget(player.transform);
        playerInteraction.SetPlayerCamera(mainCamera);
        door.SetKeyProviderSource(gameManager);
        puzzle.SetChest(chest);

        GameObject key = FindInActiveSceneIncludingInactive("Key");
        if (key == null)
        {
            key = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Undo.RegisterCreatedObjectUndo(key, "Create Escape Room key");
            key.name = "Key";
            key.transform.localScale = Vector3.one * 0.25f;
            key.transform.position = chestObject.transform.position + Vector3.up * 0.4f;
        }

        KeyPickup keyPickup = GetOrAdd<KeyPickup>(key);
        keyPickup.SetGameManager(gameManager);
        chest.SetKeyReward(key);

        GameObject ground = GameObject.Find("Ground");
        if (ground == null)
        {
            ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Undo.RegisterCreatedObjectUndo(ground, "Create Escape Room ground");
            ground.name = "Ground";
            ground.transform.position = new Vector3(0f, -0.1f, 0f);
            ground.transform.localScale = new Vector3(12f, 0.2f, 12f);
        }

        Scene scene = SceneManager.GetActiveScene();
        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        EditorUtility.DisplayDialog(
            "Escape Room",
            "MainScene quedó conectada: E interactúa, P valida el código, el cofre activa la llave y la puerta la requiere. Se guardó la escena.",
            "Aceptar");
    }

    private static T GetOrAdd<T>(GameObject target) where T : Component
    {
        T component = target.GetComponent<T>();
        return component != null ? component : Undo.AddComponent<T>(target);
    }

    private static GameObject FindInActiveSceneIncludingInactive(string objectName)
    {
        GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int i = 0; i < roots.Length; i++)
        {
            Transform[] children = roots[i].GetComponentsInChildren<Transform>(true);
            for (int j = 0; j < children.Length; j++)
            {
                if (children[j].name == objectName)
                {
                    return children[j].gameObject;
                }
            }
        }

        return null;
    }
}
