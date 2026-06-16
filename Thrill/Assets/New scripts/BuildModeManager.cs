using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    public static BuildModeManager Instance;

    public Camera mainCamera;
    public Camera buildCamera;

    public GameObject player;

    public bool isBuildMode = false;

    void Awake()
    {
        Instance = this;
    }

    public void ToggleBuildMode()
    {
        isBuildMode = !isBuildMode;

        mainCamera.enabled = !isBuildMode;
        buildCamera.enabled = isBuildMode;

        player.SetActive(!isBuildMode);

        Debug.Log("Build Mode: " + isBuildMode);
    }
}