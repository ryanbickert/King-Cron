using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        uiManager.ActivateEndGameUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        uiManager.ActivateEndGameUI();
    }
}
