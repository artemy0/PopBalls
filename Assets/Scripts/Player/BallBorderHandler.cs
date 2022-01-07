using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyArea))]
public class BallBorderHandler : MonoBehaviour
{
    private Player _player;

    private DestroyArea _destroyArea;


    private void Awake()
    {
        _destroyArea = GetComponent<DestroyArea>();
    }

    public void Init(Rect cameraRect, Player player)
    {
        _player = player;

        _destroyArea.Init(cameraRect);
        _destroyArea.OnBallTriggeredEnter += BallTriggerBorder;
    }

    private void OnDestroy()
    {
        _destroyArea.OnBallTriggeredEnter -= BallTriggerBorder;
    }


    private void BallTriggerBorder(Ball ball)
    {
        _player.ApplyDamage(ball.DamageOnDeath);
        ball.DestroyBall();
    }
}
