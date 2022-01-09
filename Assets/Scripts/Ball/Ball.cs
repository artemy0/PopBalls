using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BallMover))]
[RequireComponent(typeof(BallEffecter))]
public class Ball : MonoBehaviour, IDamageable
{
    public event Action<Ball> OnDestroyed;
    public event Action<Ball> OnPopped;

    public int ScoreOnDeath => _scoreOnDeath;
    public int DamageOnDeath => _damageOnDeath;

    private float _health;
    private int _scoreOnDeath;
    private int _damageOnDeath;

    private MeshRenderer _meshRenderer;

    private BallMover _ballMover;
    private BallEffecter _ballEffecter;


    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _ballMover = GetComponent<BallMover>();
        _ballEffecter = GetComponent<BallEffecter>();
    }

    public void Init(float health, float moveSpeed, int scoreOnDeath, int damageOnDeath, Color color)
    {
        _health = health;

        _scoreOnDeath = scoreOnDeath;
        _damageOnDeath = damageOnDeath;

        _meshRenderer.material.color = color;

        _ballMover.Init(moveSpeed);
        _ballEffecter.Init(color);
    }


    public void ApplyDamage(int value)
    {
        _health -= value;

        if(_health > 0)
        {
            _ballEffecter.CallHitEffect();
        }
        else
        {
            PopBall();
        }
    }


    public void DestroyBall()
    {
        _ballEffecter.CallDeathEffect();
        Destroy(gameObject);
    }

    private void PopBall()
    {
        DestroyBall();
        OnPopped?.Invoke(this);
    }


    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
