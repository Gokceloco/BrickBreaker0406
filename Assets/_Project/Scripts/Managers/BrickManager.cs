using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameDirector gameDirector;
    [SerializeField] private Brick brickPrefab;

    private List<Brick> _bricks = new List<Brick>();

    public List<GameObject> brickSlots;

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
        List<GameObject> availableSlots = new List<GameObject>(brickSlots);

        var brickCount = Mathf.Clamp(levelNo, 1, 20);

        for (int i = 0; i < brickCount; i++)
        {
            var newBrick = Instantiate(brickPrefab, transform);            

            var selectedSlot = availableSlots[Random.Range(0, availableSlots.Count)];            

            newBrick.transform.position = selectedSlot.transform.position;
            availableSlots.Remove(selectedSlot);

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
        gameDirector.fXManager.PlayBrickDestroyedPS(brick.transform.position);
    }
}
