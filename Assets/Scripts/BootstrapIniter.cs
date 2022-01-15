using UnityEngine;
using Zenject;

public class BootstrapIniter : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Player _player;
    [Space(10)]
    [SerializeField] private BallContainer _ballContainer;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private BallBorderHandler _ballBorderHandler;
    [Space(10)]
    [SerializeField] private PlayView _playView;
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private LoseView _loseView;


    public override void InstallBindings()
    {
        BindMain();
        BindGeneral();

        BindBallHandle();

        BindView();

        BindGameStatistic();
        BindGameSession();

        BindPlayerInput();
    }


    private void BindMain()
    {
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
    }
    
    private void BindGeneral()
    {
        Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().FromNew().AsSingle();
        Container.Bind<TimeController>().FromNew().AsSingle();
        Container.Bind<SceneLoader>().FromNew().AsSingle();
    }
    
    private void BindBallHandle()
    {
        Container.Bind<BallContainer>().FromInstance(_ballContainer).AsSingle();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle();
        Container.Bind<BallBorderHandler>().FromInstance(_ballBorderHandler).AsSingle();
    }

    private void BindView()
    {
        Container.Bind<PlayView>().FromInstance(_playView).AsSingle();
        Container.Bind<PauseView>().FromInstance(_pauseView).AsSingle();
        Container.Bind<LoseView>().FromInstance(_loseView).AsSingle();
    }
    
    private void BindGameStatistic()
    {
        Container.BindInterfacesAndSelfTo<ScoreHandler>().FromNew().AsSingle();
    }

    private void BindGameSession()
    {
        Container.BindInterfacesAndSelfTo<GameSession>().FromNew().AsSingle();
    }

    private void BindPlayerInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) 
        {
            Container.BindInterfacesAndSelfTo<HandheldInput>().AsSingle();
        }
        else
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }

        Container.BindInterfacesAndSelfTo<BallDetectionHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<BallClickHandler>().FromNew().AsSingle();
    }
}
