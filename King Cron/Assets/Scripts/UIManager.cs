using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject gameOverUI;

    public void OnRestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSubmitHighScore()
    {


    }
}
