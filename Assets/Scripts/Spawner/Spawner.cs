using System;
using UnityEngine;

[RequireComponent(typeof(SpawnArea))]
public class Spawner : MonoBehaviour
{
    public event Action<Ball> OnBallSpawned;

    [SerializeField] private BallFactory _ballFactory;
    [Space(10)]
    [SerializeField] private Transform spawn—ontainer;
    [SerializeField] private float _timeBetweenSpawn;

    private SpawnArea _spawnArea;

    private float _timeSinceSpawn = 0f;


    private void Awake()
    {
        _spawnArea = GetComponent<SpawnArea>();
    }

    public void Init(Rect cameraRect)
    {
        _spawnArea.Init(cameraRect);
    }


    private void Update()
    {
        _timeSinceSpawn += Time.deltaTime;
        if (_timeSinceSpawn > _timeBetweenSpawn)
        {
            Spawn();
            _timeSinceSpawn = 0f;
        }
    }


    private void Spawn()
    {
        Vector3 spawnPosition = _spawnArea.GetSpawnPosition();
        Ball ball = _ballFactory.Spawn(spawnPosition, Quaternion.identity, spawn—ontainer);

        OnBallSpawned?.Invoke(ball);
    }
}
