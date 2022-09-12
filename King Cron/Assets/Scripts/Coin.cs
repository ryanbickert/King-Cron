using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

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
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}
