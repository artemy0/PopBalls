using UnityEngine;

public class GameComplicator : MonoBehaviour
{
    public float CurrentComplexityCoefficient { get; private set; } = 1f;

    [SerializeField] private float _timeBetween—omplexityIncrease;
    [SerializeField] private float _complexityCoefficientIncrease;

    private float _timeSince—omplexityIncrease = 0f;


    private void Update()
    {
        _timeSince—omplexityIncrease += Time.deltaTime;
        if(_timeSince—omplexityIncrease > _timeBetween—omplexityIncrease)
        {
            IncreaseComplexity();
            _timeSince—omplexityIncrease = 0f;
        }
    }


    private void IncreaseComplexity()
    {
        CurrentComplexityCoefficient += _complexityCoefficientIncrease;
    }
}
