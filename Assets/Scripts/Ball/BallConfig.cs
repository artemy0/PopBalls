using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallConfig", menuName = "Factories/Ball/BallConfig")]
public class BallConfig : ScriptableObject
{
    [SerializeField] private MinMax _health;
    [SerializeField] private MinMax _moveSpeed;
    [SerializeField] private MinMax _scoreOnDeath;
    [SerializeField] private MinMax _damageOnDeath;
    [SerializeField] private List<Color> _colors;

    public float Health => _health.Random();
    public float MoveSpeed => _moveSpeed.Random();
    public int ScoreOnDeath => Mathf.RoundToInt(_scoreOnDeath.Random());
    public int DamageOnDeath => Mathf.RoundToInt(_damageOnDeath.Random());
    public Color Color => _colors.RandomItem();
}

[System.Serializable]
class MinMax
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float Random()
    {
        float normalizedRandomValue = UnityEngine.Random.value;
        return Mathf.Lerp(_min, _max, normalizedRandomValue);
    }
}
