using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private const int _size = 9;
    
    [SerializeField] private TextMeshProUGUI _announceButtonText;
    [SerializeField] private TextMeshProUGUI _resetButton;

    [SerializeField] private Sprite _xSprite, _oSprite;

    [SerializeField] private Image[] _images = new Image[_size];


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void SetMark(int index, bool markIsX)
    {
        _images[index].sprite = (markIsX ? _xSprite: _oSprite);
    }

    public void AnnounceMatchResult(GameController.GameState result)
    {
        _announceButtonText.enabled = true;
        _resetButton.enabled = true;

        foreach (Image image in _images)
        {
            image.raycastTarget = false;
        }

        switch (result)
        {
            case GameController.GameState.Tie:
                _announceButtonText.text = ("Tie!");
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
