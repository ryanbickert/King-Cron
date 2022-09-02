using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject highScoreUI;
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text playerName;

    private string url = "https://www.catalyst.com";

    public void ActivateEndGameUI()
    {
        gameOverUI.SetActive(true);
        player.SetActive(false);
    }

    public void SubmitHighScore()
    {
        StartCoroutine(nameof(SendHighScore));
        highScoreUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private IEnumerator SendHighScore()
    {
        WWWForm form = new();
        form.AddField("playerName", playerName.text);
        form.AddField("score", scoreManager.score);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error with score upload");
            }
            else
            {
                Debug.Log("The score was uploaded");
            }
        }
    }
}
