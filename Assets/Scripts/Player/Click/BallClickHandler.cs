using UnityEngine;

public class BallClickHandler : MonoBehaviour
{
    [SerializeField] private int _clickDamage = 10;
    
    private BallDetectionHandler _ballDetectionHandler;
    private Player _player;
    private GameSession _gameSession;


    public void Init(BallDetectionHandler ballDetectionHandler, Player player, GameSession gameSession)
    {
        _ballDetectionHandler = ballDetectionHandler;
        _player = player;
        _gameSession = gameSession;

        _ballDetectionHandler.OnBallClicked += OnBallClick;
        _player.OnDie += DisableInput;

        _gameSession.OnGamePaused += DisableInput;
        _gameSession.OnGameResumed += EnableInput;
    }

    private void OnDestroy()
    {
        _ballDetectionHandler.OnBallClicked -= OnBallClick;
        _player.OnDie -= DisableInput;

        _gameSession.OnGamePaused -= DisableInput;
        _gameSession.OnGameResumed -= EnableInput;
    }


    private void OnBallClick(Ball ball)
    {
        ball.ApplyDamage(_clickDamage);
    }

    private void EnableInput()
    {
        _ballDetectionHandler.OnBallClicked += OnBallClick;
    }
    private void DisableInput()
    {
        _ballDetectionHandler.OnBallClicked -= OnBallClick;
    }
}
