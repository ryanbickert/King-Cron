using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnApplicationFocus(bool focus)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        audioSource.Pause();
    }
}
