using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton reference
    public TMP_Text scoreText; // Use TMP_Text instead of UI Text
    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score; // Update UI
    }
}
