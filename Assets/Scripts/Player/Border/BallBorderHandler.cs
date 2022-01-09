using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyArea))]
public class BallBorderHandler : MonoBehaviour
{
    private Player _player;
    private BallContainer _ballContainer;

    private DestroyArea _destroyArea;


    private void Awake()
    {
        _destroyArea = GetComponent<DestroyArea>();
    }

    public void Init(Player player, BallContainer ballContainer)
    {
        _player = player;
        _ballContainer = ballContainer;
    }


    private void Update()
    {
        foreach (Ball ball in _ballContainer.SpawnedBalls)
        {
            if (_destroyArea.IsBallTriggerArea(ball))
            {
                BallTriggerBorder(ball);
            }
        }
    }


    private void BallTriggerBorder(Ball ball)
    {
        _player.ApplyDamage(ball.DamageOnDeath);
        ball.DestroyBall();
    }
}
