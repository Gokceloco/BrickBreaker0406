using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Ball ballPrefab;

    private List<Ball> _balls = new List<Ball>();

    public void RestartBallManager()
    {
        DestroyOldBalls();
        CreateNewBall();
    }

    private void CreateNewBall()
    {
        var newBall = Instantiate(ballPrefab, transform);
        newBall.transform.position = Vector3.zero;
        _balls.Add(newBall);
    }

    private void DestroyOldBalls()
    {
        foreach (var b in _balls)
        {
            Destroy(b.gameObject);
        }
        _balls.Clear();
    }
}
