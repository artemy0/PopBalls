using System;
using UnityEngine;

public class BallDetectionHandler : MonoBehaviour
{
    public event Action<Ball> OnBallClicked;

    private Camera _camera;
    private IInput _input;


    public void Init(Camera camera, IInput input)
    {
        _camera = camera;
        _input = input;

        _input.OnClicked += OnClick;
    }

    private void Update()
    {
        _input?.OnUpdate();
    }

    private void OnDestroy()
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
