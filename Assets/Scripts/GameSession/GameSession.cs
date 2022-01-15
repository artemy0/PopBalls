using System;
using Zenject;

public class GameSession : IInitializable, IDisposable
{
    public event Action OnGamePaused;
    public event Action OnGameResumed;

    private PlayView _playView;
    private PauseView _pauseView;
    private LoseView _loseView;

    private BaseView _currentView;

    private Player _player;
    private ScoreHandler _scoreHandler;
    private TimeController _timeController;
    private SceneLoader _sceneLoader;


    public GameSession(Player player, ScoreHandler scoreHandler, 
        TimeController timeController, SceneLoader sceneLoader,
        PlayView playView, PauseView pauseView, LoseView loseView)
    {
        _player = player;
        _scoreHandler = scoreHandler;

        _timeController = timeController;
        _sceneLoader = sceneLoader;

        _playView = playView;
        _pauseView = pauseView;
        _loseView = loseView;


        _currentView = _playView;
        _currentView.OpenView();
    }

    public void Initialize()
    {
        _player.OnDie += LoseGame;
        _player.OnHealthChanged += _playView.UpdateHealthSlider;

        _scoreHandler.OnScoreUpdated += _playView.UpdateScoreText;


        _playView.OnPauseButtonClicked += PauseGame;
        _playView.OnRestartButtonClicked += RestartGame;

        _pauseView.OnPlayButtonClicked += ResumeGame;

        _loseView.OnRestartButtonClicked += RestartGame;
    }

    public void Dispose()
    {
        _player.OnDie -= LoseGame;
        _player.OnHealthChanged -= _playView.UpdateHealthSlider;

        _scoreHandler.OnScoreUpdated -= _playView.UpdateScoreText;


        _playView.OnPauseButtonClicked -= PauseGame;
        _playView.OnRestartButtonClicked -= RestartGame;

        _pauseView.OnPlayButtonClicked -= ResumeGame;

        _loseView.OnRestartButtonClicked -= RestartGame;
    }


    private void PauseGame()
    {
        _currentView.CloseView();
        _currentView = _pauseView;
        _currentView.OpenView();

        _pauseView.UpdateCurrentScoreText(_scoreHandler.Score);
        _pauseView.UpdateBestScoreText(_scoreHandler.BestScore);

        _timeController.StopTime();

        OnGamePaused?.Invoke();
    }

    private void ResumeGame()
    {
        _currentView.CloseView();
        _currentView = _playView;
        _currentView.OpenView();

        _timeController.ResumeTime();

        OnGameResumed?.Invoke();
    }

    private void LoseGame()
    {
        _currentView.CloseView();
        _currentView = _loseView;
        _currentView.OpenView();

        _loseView.UpdateGameScoreText(_scoreHandler.Score);
        _loseView.UpdateBestScoreText(_scoreHandler.BestScore);

        _timeController.StopTime();

        OnGamePaused?.Invoke();
    }

    private void RestartGame()
    {
        _timeController.ResumeTime();

        _sceneLoader.ReloadScene();
    }
}
