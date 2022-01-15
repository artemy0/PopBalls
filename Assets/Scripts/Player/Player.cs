using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public event Action OnDie;
    public event Action<int, int> OnHealthChanged;

    public int Dagame => _damage;

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;

    private int _currentHealth;



    private void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void ApplyDamage(int value)
    {
        _currentHealth -= value;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if(_currentHealth <= 0)
        {
            OnDie?.Invoke();
        }
    }
}
