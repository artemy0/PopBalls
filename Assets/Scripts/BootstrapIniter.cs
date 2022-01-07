using UnityEngine;

public class BootstrapIniter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private BallClickHandler _ballClickHandler;
    [SerializeField] private BallDetectionHandler _ballDetectionHandler;
    [SerializeField] private BallBorderHandler _ballBorderHandler;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Player _player;

    private IInput _input;
    private ISaveSystem _saveSystem;


    private void Start()
    {
        Init();

        Application.targetFrameRate = 1;
    }


    //я не хотел использовать Zenject в этом проекте
    private void Init()
    {
        InitSpawner();
        InitBallDetection();
        InitSaveSystem();
    }


    private void InitSpawner()
    {
        _spawner.Init(_mainCamera.pixelRect);
    }

    private void InitBallDetection()
    {
        _input = new MouseInput();

        _ballDetectionHandler.Init(_mainCamera, _input);
        _ballClickHandler.Init(_ballDetectionHandler, _player);

        _ballBorderHandler.Init(_mainCamera.pixelRect, _player);
    }

    private void InitSaveSystem()
    {
        _saveSystem = new PlayerPrefsSaveSystem();
    }

    private  void InitScoreSystem()
    {

    }
}
