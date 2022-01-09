using UnityEngine;

public class BallIniter : MonoBehaviour
{
    [SerializeField] private BallConfig _ballConfig;
    [SerializeField] private GameComplicator _gameComplicator;


    public void InitBall(Ball ball)
    {
        float cureentMoveSpeed = _gameComplicator.CurrentComplexityCoefficient * _ballConfig.MoveSpeed;

        ball.Init(_ballConfig.Health, cureentMoveSpeed,
            _ballConfig.ScoreOnDeath, _ballConfig.DamageOnDeath,
            _ballConfig.Color);
    }
}
