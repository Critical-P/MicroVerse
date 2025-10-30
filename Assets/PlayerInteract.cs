using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;

    private CollectibleObject currentTarget; // the object currently highlighted

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact();
            currentTarget = null;
        }
    }

    void CheckForInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange, interactableLayer))
        {
            CollectibleObject found = hit.collider.GetComponent<CollectibleObject>();

            if (found != null)
            {
                if (currentTarget != found)
                {
                    ClearHighlight();
                    currentTarget = found;
                    currentTarget.Highlight();
                }
                return;
            }
        }

        // If no interactable in range or looking away, clear highlight
        ClearHighlight();
    }

    void ClearHighlight()
    {
        if (currentTarget != null)
        {
            currentTarget.RemoveHighlight();
            currentTarget = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * interactRange);
    }
}

