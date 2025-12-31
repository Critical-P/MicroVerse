using UnityEngine;
using TMPro;

public class PowerUpInteract : MonoBehaviour
{
    [Header("Interaction")]
    public float interactRange = 2.5f;          // 🔧 CHANGE THIS
    public float scaleAmount = 1.2f;
    public KeyCode interactKey = KeyCode.E;

    [Header("Glow Settings")]
    public Color glowColor = Color.yellow;
    public float glowIntensity = 2f;

    [Header("UI")]
    public TextMeshProUGUI interactText;

    private Transform player;
    private Material material;
    private bool isInRange = false;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;

        if (interactText != null)
            interactText.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactRange)
        {
            if (!isInRange)
            {
                isInRange = true;
                EnableGlow();
                ShowUI();
            }

            if (Input.GetKeyDown(interactKey))
            {
                ScalePlayer();
                HideUI();
                Destroy(gameObject);
            }
        }
        else if (isInRange)
        {
            isInRange = false;
            DisableGlow();
            HideUI();
        }
    }

    void ScalePlayer()
    {
        player.localScale *= scaleAmount;
    }

    void EnableGlow()
    {
        material.EnableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", glowColor * glowIntensity);
    }

    void DisableGlow()
    {
        material.SetColor("_EmissionColor", Color.black);
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

    // 🔍 Visualize range in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
