using UnityEngine;


public class GameController : MonoBehaviour
{
    private const int Size = 9;
    private int[] _fieldArray = new int[Size];
    private bool _currentTurnX = true;
    private GameState _result;

    [SerializeField] private UI _UIController;

    public void SetFieldState(int place)
    {
        if(_fieldArray[place] != 0) return;
        _fieldArray[place] = 1 - 2 * (_currentTurnX ? 0: 1);
        _UIController.SetMark(place, _currentTurnX);
        _currentTurnX = !_currentTurnX;
        
        CheckWin();

        if (_result != GameState.GameInProgress)
        {
            _UIController.AnnounceMatchResult(_result);
        }

        Debug.Log(_result);
    }
    private void CheckWin()
    {
        for (var i = 0; i < 3; i++)
        {
            switch (_fieldArray[i*3] + _fieldArray[i*3 + 1] + _fieldArray[i*3 + 2])
            {
                case 3:
                    _result = GameState.XWin;
                    return;
                case -3:
                    _result = GameState.OWin;
                    return;
            }
            switch (_fieldArray[i] + _fieldArray[i + 3] + _fieldArray[i + 6])
            {
                case 3:
                    _result = GameState.XWin;
                    return;
                case -3:
                    _result = GameState.OWin;
                    return;
            }
        }

        switch (_fieldArray[0] + _fieldArray[4] + _fieldArray[8])
        {
            case 3:
                _result = GameState.XWin;
                return;
            case -3:
                _result = GameState.OWin;
                return;
        }
        switch (_fieldArray[2] + _fieldArray[4] + _fieldArray[6])
        {
            case 3:
                _result = GameState.XWin;
                return;
            case -3:
                _result = GameState.OWin;
                return;
        }

        for (var i = 0; i < Size; i++)
        {
            if (_fieldArray[i] == 0) return;
        }

        _result = GameState.Tie;
    }

    public enum GameState
    {
        GameInProgress,
        Tie,
        XWin,
        OWin
    }
}

