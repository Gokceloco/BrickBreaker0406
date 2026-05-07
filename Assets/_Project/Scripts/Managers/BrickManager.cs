using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;

    public List<Brick> bricks;

    public void RestartBrickManager(int levelNo)
    {
        DestroyBircks();
        CreateNewBricks(levelNo);
    }

    void DestroyBircks()
    {
        foreach (var b in bricks)
        {
            Destroy(b.gameObject);
        }
        bricks.Clear();
    }
    void CreateNewBricks(int levelNo)
    {
        for (int i = 0; i < levelNo; i++)
        {
            var newBrick = Instantiate(brickPrefab, transform);
            newBrick.transform.position = new Vector3(i - 2, 2, 0);
            bricks.Add(newBrick);
        }
    }
}
