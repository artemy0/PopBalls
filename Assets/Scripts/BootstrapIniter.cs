using UnityEngine;

public class BootstrapIniter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private BallClickHandler _ballClickHandler;
    [SerializeField] private BallDetectionHandler _ballDetectionHandler;
    [SerializeField] private BallBorderHandler _ballBorderHandler;
    [SerializeField] private BallContainer _ballContainer;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private GameSession _gameSession;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Player _player;

    private IInput _input;
    private ISaveSystem _saveSystem;
    private TimeController _timeController;
    private SceneLoader _sceneLoader;


    private void Start()
    {
        Init();
    }


    //я не хотел использовать Zenject в этом проекте
    private void Init()
    {
        InitSpawner();
        InitBallDetection();
        InitSaveSystem();
        InitScoreSystem();
        InitTimeController();
        InitGameSession();
    }


    private void InitSpawner()
    {
        _spawner.Init(_mainCamera.pixelRect);
    }

    private void InitBallDetection()
    {
        _input = new MouseInput();

        _ballDetectionHandler.Init(_mainCamera, _input);
        _ballClickHandler.Init(_ballDetectionHandler, _player, _gameSession);

        _ballBorderHandler.Init(_player, _ballContainer);
    }

    private void InitSaveSystem()
    {
        _saveSystem = new PlayerPrefsSaveSystem();
    }

    private  void InitScoreSystem()
    {
        _scoreHandler.Init(_ballContainer, _saveSystem);
    }

    private void InitTimeController()
    {
        _timeController = new TimeController();
    }

    private void InitGameSession()
    {
        _sceneLoader = new SceneLoader();

        _gameSession.Init(_player, _scoreHandler, _timeController, _sceneLoader);
    }
}
