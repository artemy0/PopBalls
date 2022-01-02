using UnityEngine;

public class BootstrapIniter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private BallClickHandler _ballClickHandler;
    [SerializeField] private BallDetectionHandler _ballDetectionHandler;

    [SerializeField] private Player _player;


    private void Start()
    {
        Init();
    }

    //я не хотел использовать Zenject в этом проекте
    private void Init()
    {
        InitSpawner();
        InitBallDetection();
    }

    private void InitSpawner()
    {
        Camera mainCamera = Camera.main;
        _spawner.Init(mainCamera.pixelRect);
    }

    private void InitBallDetection()
    {
        Camera mainCamera = Camera.main;
        IInput input = new MouseInput();
        _ballDetectionHandler.Init(mainCamera, input);

        _ballClickHandler.Init(_ballDetectionHandler, _player);
    }

}
