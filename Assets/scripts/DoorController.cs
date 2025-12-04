using UnityEngine;

public class DoorController_Rotate : MonoBehaviour
{
    public int requiredDestroyedObjects = 5;   // How many objects must be destroyed
    public float rotateSpeed = 2f;             // How fast the door rotates

    [Header("Rotation Settings")]
    public Vector3 rotationAmount = new Vector3(0, 90f, 0);
    // Change this to rotate any direction:
    // (0,  90, 0)  = rotate right
    // (0, -90, 0)  = rotate left
    // (90, 0,  0)  = rotate forward
    // (-90,0,  0)  = rotate backward

    private bool doorOpen = false;
    private Quaternion targetRotation;

    private void Start()
    {
        // Calculate the final rotation
        targetRotation = Quaternion.Euler(transform.localEulerAngles + rotationAmount);
    }

    private void Update()
    {
        if (!doorOpen && ObjectDestructionTracker.Instance.destroyedCount >= requiredDestroyedObjects)
        {
            doorOpen = true;
            Debug.Log("Rotating door open!");
        }

        if (doorOpen)
        {
            transform.localRotation = Quaternion.Lerp(
                transform.localRotation,
                targetRotation,
                Time.deltaTime * rotateSpeed
            );
        }
    }
}
