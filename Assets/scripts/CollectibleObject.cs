using UnityEngine;
using TMPro;

public class CollectibleObject : MonoBehaviour
{
    [Header("Interaction")]
    public float interactRange = 0.18f;
    public KeyCode interactKey = KeyCode.E;

    [Header("Highlight")]
    public Color highlightColor = Color.yellow;

    [Header("UI")]
    public TextMeshProUGUI interactText;

    private Renderer rend;
    private Color originalColor;
    private Transform player;
    private bool isInRange = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactRange)
        {
            if (!isInRange)
            {
                isInRange = true;
                Highlight();
                ShowUI();
            }

            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }
        else if (isInRange)
        {
            isInRange = false;
            RemoveHighlight();
            HideUI();
        }
    }

    // Called when player interacts (presses E)
    public void Interact()
    {
        ScoreManager.Instance.AddScore(1);
        HideUI();
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

    void ShowUI()
    {
        if (interactText != null)
        {
            interactText.text = $"Press {interactKey}";
            interactText.gameObject.SetActive(true);
        }
    }

    void HideUI()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    // 🔍 Visualize interact range in Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
