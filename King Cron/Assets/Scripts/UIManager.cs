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
    [SerializeField] private ReturnJSON returnJSON;
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text playerNameTMP;

    private string url = "http://localhost:3000/server/cron-functions/submit-score";

    public void ActivateEndGameUI()
    {
        gameOverUI.SetActive(true);
        player.SetActive(false);
    }

    public void SubmitHighScore()
    {
        highScoreUI.SetActive(false);
        StartCoroutine(nameof(SendHighScore));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private IEnumerator SendHighScore()
    {
        returnJSON.playerName = playerNameTMP.text;
        returnJSON.score = scoreManager.score;
        string testc = returnJSON.ConvertToJSON(playerNameTMP.text, scoreManager.score);

        using (UnityWebRequest webRequest = UnityWebRequest.Put(url, testc))
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            Debug.Log(webRequest.result);

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("The score was uploaded");
            }
            else
            {
                Debug.Log("Error with score upload");
            }
        }
    }
}
