using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public event Action<int> OnScoreUpdated;
    public event Action<int> OnBestScoreUpdated;

    public int Score => _score;
    public int BestScore => _bestScore;

    private BallContainer _ballContainer;
    private ISaveSystem _saveSystem;

    private int _score;
    private int _bestScore;


    public void Init(BallContainer ballContainer, ISaveSystem saveSystem)
    {
        _ballContainer = ballContainer;
        _saveSystem = saveSystem;

        SaveData saveData = _saveSystem.Load();

        _score = 0;
        _bestScore = saveData.BestScore;

        _ballContainer.OnSpawnedBallPopped += AddScore;
    }

    private void OnDestroy()
    {
        SaveData saveData = _saveSystem.Load();
        saveData.BestScore = _bestScore;

        _saveSystem.Save(saveData);

        _ballContainer.OnSpawnedBallPopped -= AddScore;
    }


    private void AddScore(Ball ball)
    {
        _score += ball.ScoreOnDeath;
        OnScoreUpdated?.Invoke(_score);

        if(_score > _bestScore)
        {
            _bestScore = _score;
            OnBestScoreUpdated?.Invoke(_bestScore);
        }
    }
}
