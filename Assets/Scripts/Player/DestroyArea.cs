using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DestroyArea : GameArea
{
    public event Action<Ball> OnBallTriggeredEnter;


    public void Init(Rect cameraRect)
    {
        base.Init(cameraRect);

        SetDestroyAreaScale();
    }

    private void SetDestroyAreaScale()
    {
        Vector3 destroyAreaScale = Vector3.one;
        destroyAreaScale.x = _areaWidth * destroyAreaScale.x;

        transform.localScale = destroyAreaScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Ball ball))
        {
            OnBallTriggeredEnter?.Invoke(ball);
        }
    }
}
