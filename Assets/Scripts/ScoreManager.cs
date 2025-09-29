using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    private TextMeshProUGUI scoreText;
    private int score = 0;
    
    void Awake()
    {
        Instance = this;
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        UpdateScore();
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}