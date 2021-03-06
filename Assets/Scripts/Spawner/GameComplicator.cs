using UnityEngine;

public class GameComplicator : MonoBehaviour
{
    public float CurrentComplexityCoefficient { get; private set; } = 1f;

    [SerializeField] private float _timeBetweenÑomplexityIncrease;
    [SerializeField] private float _complexityCoefficientIncrease;

    private float _timeSinceÑomplexityIncrease = 0f;


    private void Update()
    {
        _timeSinceÑomplexityIncrease += Time.deltaTime;
        if(_timeSinceÑomplexityIncrease > _timeBetweenÑomplexityIncrease)
        {
            IncreaseComplexity();
            _timeSinceÑomplexityIncrease = 0f;
        }
    }


    private void IncreaseComplexity()
    {
        CurrentComplexityCoefficient += _complexityCoefficientIncrease;
    }
}
