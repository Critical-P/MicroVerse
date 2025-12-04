using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    public int itemsCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            itemsCollected++;
            Debug.Log("Collected item! Total: " + itemsCollected);
            Destroy(other.gameObject);
        }
    }
}
