using UnityEngine;

public class ScaleUpOnInteract : MonoBehaviour
{
    public float scaleAmount = 1.2f;     // How much to scale the player
    public KeyCode interactKey = KeyCode.E;

    private bool canInteract = false;
    private Transform player;

    void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            ScalePlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            player = null;
        }
    }

    void ScalePlayer()
    {
        Vector3 newScale = player.localScale * scaleAmount;
        player.localScale = newScale;
    }
}
