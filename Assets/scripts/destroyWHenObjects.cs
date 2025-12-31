using UnityEngine;

public class DoorController_Destroy : MonoBehaviour
{
    public int requiredDestroyedObjects = 5; // How many objects must be destroyed
    public float destroyDelay = 0f;          // Optional delay before destroying

    private bool destroyed = false;

    void Update()
    {
        if (!destroyed && ObjectDestructionTracker.Instance.destroyedCount >= requiredDestroyedObjects)
        {
            destroyed = true;
            Debug.Log("Required count reached — destroying object!");

            Destroy(gameObject, destroyDelay);
        }
    }
}
