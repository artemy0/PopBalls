using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private float _moveSpeed;


    public void Init(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }


    public void Update()
    {
        Move(_moveSpeed * Time.deltaTime);
    }


    private void Move(float moveSpeed)
    {
        transform.Translate(moveSpeed * Vector3.down);
    }
}
