using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : BaseView
{
    public event Action OnPlayButtonClicked;

    [SerializeField] private Button _playButton;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;


    private void Awake()
    {
        _playButton.onClick.AddListener(PlayButtonClick);
    }


    public void UpdateCurrentScoreText(int score)
    {
        _currentScoreText.text = $"Score : {score}";
    }
    public void UpdateBestScoreText(int score)
    {
        _bestScoreText.text = $"Best score : {score}";
    }

    private void PlayButtonClick()
    {
        OnPlayButtonClicked?.Invoke();
    }
}
