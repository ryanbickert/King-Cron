using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float timeToWait = 0.1f;

    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAudioSource.Play();
        scoreManager.OnScoreUpdate();
        StartCoroutine(nameof(DestroyCoin));
    }

    private IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(timeToWait);

        Destroy(gameObject);
    }
}
