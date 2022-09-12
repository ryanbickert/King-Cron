using UnityEngine;

public class FinalCoinAudio : MonoBehaviour
{
    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAudioSource.Play();
    }
}
