using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange, interactableLayer))
        {
            CollectibleObject collectible = hit.collider.GetComponent<CollectibleObject>();
            if (collectible != null)
            {
                collectible.Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Just to visualize interaction range in the editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * interactRange);
    }
}

