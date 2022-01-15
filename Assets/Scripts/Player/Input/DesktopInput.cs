using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> OnClicked;

    private const int LeftMouseButton = 0;


    public void Tick()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnClicked?.Invoke(Input.mousePosition);
        }
    }
}
