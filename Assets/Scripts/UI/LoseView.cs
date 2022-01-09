using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseView : BaseView
{
    public event Action OnRestartButtonClicked;

    [SerializeField] private Button _restartButton;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _gameScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;


    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartButtonClick);
    }


    public void UpdateGameScoreText(int score)
    {
        _gameScoreText.text = $"Score : {score}";
    }
    public void UpdateBestScoreText(int score)
    {
        _bestScoreText.text = $"Best score : {score}";
    }

    private void RestartButtonClick()
    {
        OnRestartButtonClicked?.Invoke();
    }
}
