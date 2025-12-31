using UnityEngine;


using TMPro; // For TextMeshPro UI (recommended)

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText; // Assign in Inspector
    private int score = 0;

    private void Awake()
    {
        // Ensure there’s only one instance
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text =  + score + "/5";
        if (score == 5) Destroy(gameObject);
    }
}
