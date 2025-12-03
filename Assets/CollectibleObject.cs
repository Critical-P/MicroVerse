using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // You can change this in Inspector

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    // Called when player interacts (presses E)
    public void Interact()
    {
        ScoreManager.Instance.AddScore(1);
        Destroy(gameObject);
    }

    public void Highlight()
    {
        if (rend != null)
            rend.material.color = highlightColor;
    }

    public void RemoveHighlight()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }
}

