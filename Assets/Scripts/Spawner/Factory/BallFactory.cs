using UnityEngine;

//[CreateAssetMenu(fileName = "Ball Factory", menuName = "Factories/Ball/BallFactory")]
// : ScriptableObject
public class BallFactory : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private BallIniter _ballIniter;

    public Ball Spawn(Vector3 position, Quaternion rotation, Transform parent)
    {
        Ball ball = Instantiate(_ballPrefab, position, rotation, parent);
        _ballIniter.InitBall(ball);

        return ball;
    }
}
