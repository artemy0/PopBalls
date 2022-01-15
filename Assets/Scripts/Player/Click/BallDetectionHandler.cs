using System;
using UnityEngine;
using Zenject;

public class BallDetectionHandler : IInitializable, IDisposable
{
    public event Action<Ball> OnBallClicked;

    private Camera _camera;
    private IInput _input;


    public BallDetectionHandler(Camera camera, IInput input)
    {
        _camera = camera;
        _input = input;
    }

    public void Initialize()
    {
        _input.OnClicked += OnClick;
    }

    public void Dispose()
    {
        _input.OnClicked -= OnClick;
    }


    private void OnClick(Vector3 clickPosition)
    {
        Ray ray = _camera.ScreenPointToRay(clickPosition);

        if(Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity))
        {
            if(hit.collider.TryGetComponent(out Ball ball))
            {
                OnBallClicked?.Invoke(ball);
            }
        }
    }
}
