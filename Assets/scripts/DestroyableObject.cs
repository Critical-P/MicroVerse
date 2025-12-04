using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    private void OnDestroy()
    {
        if (ObjectDestructionTracker.Instance != null)
        {
            ObjectDestructionTracker.Instance.RegisterDestruction();
        }
    }
}
