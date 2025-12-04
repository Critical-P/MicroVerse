using UnityEngine;

public class ObjectDestructionTracker : MonoBehaviour
{
    public static ObjectDestructionTracker Instance;

    public int destroyedCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterDestruction()
    {
        destroyedCount++;
        Debug.Log("Object destroyed. Total: " + destroyedCount);
    }
}
