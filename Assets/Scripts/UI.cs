using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _announceButtonText;
    [SerializeField] private TextMeshProUGUI _resetButton;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void AnnounceMatchResult(GameController.GameState result)
    {
        _announceButtonText.enabled = true;
        _resetButton.enabled = true;

        switch (result)
        {
            case GameController.GameState.Tie:
                _announceButtonText.SetText("Tie!");
                return;
            case GameController.GameState.OWin:
                _announceButtonText.SetText("O wins!");
                return;
            case GameController.GameState.XWin:
                _announceButtonText.SetText("X wins!");
                return;
        }
    }
}
