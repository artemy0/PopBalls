using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public event Action OnDie;
    public event Action<int, int> OnHealthChanged;

    [SerializeField] private int _maxHealth;
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
