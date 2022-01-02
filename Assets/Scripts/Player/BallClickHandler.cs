using System;
using UnityEngine;

public class BallClickHandler : MonoBehaviour
{
    [SerializeField] private int _clickDamage = 10;
    
    private BallDetectionHandler _ballDetectionHandler;
    private Player _player;


    public void Init(BallDetectionHandler ballDetectionHandler, Player player)
    {
        _ballDetectionHandler = ballDetectionHandler;
        _player = player;

        _ballDetectionHandler.OnBallClicked += OnBallClick;
        _player.OnDie += DisableInput;
    }

    private void OnDestroy()
    {
        _ballDetectionHandler.OnBallClicked -= OnBallClick;
        _player.OnDie -= DisableInput;
    }


    private void OnBallClick(Ball ball)
    {
        ball.ApplyDamage(_clickDamage);
    }

    private void DisableInput()
    {
        _ballDetectionHandler.OnBallClicked += OnBallClick;
    }
}
