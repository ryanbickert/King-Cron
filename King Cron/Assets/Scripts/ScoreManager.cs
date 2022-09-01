using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int score;

    public void OnScoreUpdate()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
