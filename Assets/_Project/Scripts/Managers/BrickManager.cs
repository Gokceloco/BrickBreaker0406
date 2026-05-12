using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameDirector gameDirector;
    [SerializeField] private Brick brickPrefab;

    private List<Brick> _bricks = new List<Brick>();

    public void RestartBrickManager(int levelNo)
    {
        DestroyBircks();
        CreateNewBricks(levelNo);
    }
    void DestroyBircks()
    {
        foreach (var b in _bricks)
        {
            Destroy(b.gameObject);
        }
        _bricks.Clear();
    }
    void CreateNewBricks(int levelNo)
    {
        for (int i = 0; i < levelNo; i++)
        {
            var newBrick = Instantiate(brickPrefab, transform);
            newBrick.transform.position = new Vector3(i - 2, 2, 0);
            newBrick.StartBrick();
            _bricks.Add(newBrick);
        }
    }

    public void BrickDestroyed(Brick brick)
    {
        _bricks.Remove(brick);
        if (_bricks.Count <= 0)
        {
            gameDirector.LevelCompleted();
        }
    }
}
