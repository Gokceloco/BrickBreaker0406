using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
    public GameState gameState;

    public UIManager uiManager;
    public LevelManager levelManager;
    public BrickManager brickManager;
    public BallManager ballManager;

    public Player player;

    void Start()
    {
        gameState = GameState.MainMenu;
        uiManager.ShowMainMenu();
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        var state = Random.state;
        Random.InitState(levelManager.levelNo);

        gameState = GameState.GamePlay;
        levelManager.RestartLevelManager();
        brickManager.RestartBrickManager(levelManager.levelNo);
        player.RestartPlayer();
        ballManager.RestartBallManager();

        Random.state = state;
    }

    public void LevelCompleted()
    {
        gameState = GameState.WinUI;
        ballManager.DestroyOldBalls();
        uiManager.ShowVictoryUI();
    }

    public void LevelFailed()
    {
        gameState = GameState.FailUI;
        uiManager.ShowFailUI();
    }

    public void LoadNextLevel()
    {
        levelManager.levelNo++;
        RestartLevel();
    }
}

public enum GameState
{ 
    MainMenu,
    GamePlay,
    WinUI,
    FailUI 
}