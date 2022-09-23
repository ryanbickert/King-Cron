using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private AudioSource audioSource;

    private void FixedUpdate()
    {
        Vector2 screenView = myCamera.ScreenToViewportPoint(Input.mousePosition);
        bool mouseIsOutside = screenView.x < 0 || screenView.x > 1 || screenView.y < 0 || screenView.y > 1;

        if (mouseIsOutside)
        {
            audioSource.Pause();
        }
        else if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
