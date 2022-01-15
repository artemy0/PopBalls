using System;
using System.Collections.Generic;
using UnityEngine;

public class BallContainer : MonoBehaviour
{
    public event Action<Ball> OnSpawnedBallPopped;
    public IReadOnlyList<Ball> SpawnedBalls => _spawnedBalls;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Player _player;
    [Space(10)]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private BallBorderHandler _ballBorderHandler;

    private List<Ball> _spawnedBalls = new List<Ball>();


    private void Awake()
    {
        _spawner.Init(_mainCamera);
        _ballBorderHandler.Init(_player, this);
    }

    private void Start()
    {
        _spawner.OnBallSpawned += AddSpawnedBall;
    }

    private void OnDestroy()
    {
        _spawner.OnBallSpawned -= AddSpawnedBall;
    }


    private void AddSpawnedBall(Ball ball)
    {
        _spawnedBalls.Add(ball);

        ball.OnPopped += PoppSpawnedBall;
        ball.OnDestroyed += RemoveSpawnedBall;
    }

    private void PoppSpawnedBall(Ball ball)
    {
        OnSpawnedBallPopped?.Invoke(ball);
    }

    private void RemoveSpawnedBall(Ball ball)
    {
        _spawnedBalls.Remove(ball);

        ball.OnPopped -= PoppSpawnedBall;
        ball.OnDestroyed -= RemoveSpawnedBall;
    }
}
