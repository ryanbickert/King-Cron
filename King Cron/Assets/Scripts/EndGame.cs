using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        uiManager.ActivateEndGameUI();
    }
}
