using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public WinUI winUI;
    public FailUI failUI;

    public void ShowMainMenu()
    {
        mainMenu.Show();
    }

    public void ShowVictoryUI()
    {
        winUI.Show();
    }

    public void ShowFailUI()
    {
        failUI.Show();
    }

    public void PlayGameButtonPressed()
    {
        mainMenu.Hide();
        gameDirector.RestartLevel();
    }

    public void LoadNextLevelButtonPressed()
    {
        winUI.Hide();
    }

    public void RetryButtonPressed()
    {
        failUI.Hide();
    }
}
