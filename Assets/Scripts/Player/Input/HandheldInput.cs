using System;
using UnityEngine;
using Zenject;

public class HandheldInput : IInput, ITickable
{
    public event Action<Vector3> OnClicked;

    public void Tick()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                OnClicked?.Invoke(firstTouch.position);
            }
        }
    }
}
