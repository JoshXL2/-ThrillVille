using UnityEngine;

public class BuildPlate : MonoBehaviour
{
    bool inside = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            inside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            inside = false;
    }

    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E))
        {
            BuildModeManager.Instance.ToggleBuildMode();
        }
    }
}