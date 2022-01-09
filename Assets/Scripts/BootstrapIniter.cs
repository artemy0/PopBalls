using UnityEngine;

public class BootstrapIniter : MonoBehaviour
{
    [SerializeField] private BallContainer _ballContainer; //можно отказаться от MB, как и многие другие компоненты тут
    [SerializeField] private Spawner _spawner;
    [Space(10)]
    [SerializeField] private BallClickHandler _ballClickHandler;
    [SerializeField] private BallDetectionHandler _ballDetectionHandler;
    [Space(10)]
    [SerializeField] private BallBorderHandler _ballBorderHandler;
    [Space(10)]
    [SerializeField] private ScoreHandler _scoreHandler;
    [Space(10)]
    [SerializeField] private GameSession _gameSession;
    [Space(20)]
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
        InitSaveSystem();
        InitTimeController();
        InitSceneLoader();
        
        InitSpawner();
        InitBallDetection();
        InitScoreSystem();
        InitGameSession();
    }


    private void InitSaveSystem()
    {
        _saveSystem = new PlayerPrefsSaveSystem();
    }
    private void InitTimeController()
    {
        _timeController = new TimeController();
    }
    private void InitSceneLoader()
    {
        _sceneLoader = new SceneLoader();
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

    private  void InitScoreSystem()
    {
        _scoreHandler.Init(_ballContainer, _saveSystem);
    }

    private void InitGameSession()
    {
        _gameSession.Init(_player, _scoreHandler, _timeController, _sceneLoader);
    }
}
