using System;
using UnityEngine;

public class MouseInput : IInput
{
    public event Action<Vector3> OnClicked;

    private const int LeftMouseButton = 0;


    public void OnUpdate()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnClicked?.Invoke(Input.mousePosition);
        }
    }
}
