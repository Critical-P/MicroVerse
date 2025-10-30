using UnityEngine;

using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    // This function is called when the player interacts with the object
    public void Interact()
    {
        // Notify the GameManager or ScoreManager
        ScoreManager.Instance.AddScore(1);

        // Destroy (make the object disappear)
        Destroy(gameObject);
    }
}
