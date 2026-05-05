using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Ball ballPrefab;

    public void RestartBallManager()
    {
        var newBall = Instantiate(ballPrefab, transform);
        newBall.transform.position = Vector3.zero;
    }
}
