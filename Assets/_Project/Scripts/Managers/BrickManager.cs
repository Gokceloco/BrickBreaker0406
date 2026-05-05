using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public Brick brickPrefab;

    public void RestartBrickManager(int levelNo)
    {
        for (int i = 0; i < levelNo; i++)
        {
            var newBrick = Instantiate(brickPrefab, transform);
            newBrick.transform.position = new Vector3(i - 2, 2, 0);
        }
    }
}
