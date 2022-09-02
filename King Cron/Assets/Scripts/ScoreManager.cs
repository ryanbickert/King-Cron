using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [System.NonSerialized] public int score;

    [SerializeField] private TMP_Text scoreText;

    public void OnScoreUpdate()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
