using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayView : BaseView
{
    public event Action OnPauseButtonClicked;
    public event Action OnRestartButtonClicked;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _restartButton;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Slider _healthSlider;


    private void Awake()
    {
        _pauseButton.onClick.AddListener(PauseButtonClick);
        _restartButton.onClick.AddListener(RestartButtonClick);
    }


    public void UpdateScoreText(int score)
    {
        _scoreText.text = $"Score : {score}";
    }
    public void UpdateHealthSlider(int currentHealth, int totalHealth)
    {
        _healthSlider.value = currentHealth / (float)totalHealth;
    }

    private void PauseButtonClick()
    {
        OnPauseButtonClicked?.Invoke();
    }
    private void RestartButtonClick()
    {
        OnRestartButtonClicked?.Invoke();
    }
}
