using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    [SerializeField] private Transform _destroyAnchor;


    public bool IsBallTriggerArea(Ball ball)
    {
        return ball.transform.position.y < _destroyAnchor.position.y;
    }
}
