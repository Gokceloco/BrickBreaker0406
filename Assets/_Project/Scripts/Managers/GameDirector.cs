using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public BrickManager brickManager;
    public BallManager ballManager;

    public Player player;

    void Start()
    {
        RestartLevel();
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        levelManager.RestartLevelManager();
        brickManager.RestartBrickManager(levelManager.levelNo);
        player.RestartPlayer();
        ballManager.RestartBallManager();
    }

}
