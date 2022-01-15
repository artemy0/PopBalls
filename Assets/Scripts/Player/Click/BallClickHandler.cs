using System;
using UnityEngine;
using Zenject;

public class BallClickHandler : IInitializable, IDisposable
{
    private BallDetectionHandler _ballDetectionHandler;
    private Player _player;
    private GameSession _gameSession;

    private int _clickDamage;


    public BallClickHandler(BallDetectionHandler ballDetectionHandler, Player player, GameSession gameSession)
    {
        _ballDetectionHandler = ballDetectionHandler;
        _player = player;
        _gameSession = gameSession;

        _clickDamage = player.Dagame;
    }

    public void Initialize()
    {
        _ballDetectionHandler.OnBallClicked += OnBallClick;
        _player.OnDie += DisableInput;

        _gameSession.OnGamePaused += DisableInput;
        _gameSession.OnGameResumed += EnableInput;
    }

    public void Dispose()
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
