using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public WinUI winUI;
    public FailUI failUI;
    public LevelUI levelUI;

    public void ShowMainMenu()
    {
        mainMenu.Show();
        winUI.Hide();
        failUI.Hide();
        HideInGameUI();
    }

    public void ShowVictoryUI()
    {
        winUI.Show();
        HideInGameUI();
    }

    public void ShowFailUI()
    {
        failUI.Show();
        HideInGameUI();
    }

    public void PlayGameButtonPressed()
    {
        mainMenu.Hide();
        gameDirector.RestartLevel();
    }

    public void LoadNextLevelButtonPressed()
    {
        winUI.Hide();
        gameDirector.LoadNextLevel();
    }

    public void RetryButtonPressed()
    {
        failUI.Hide();
        gameDirector.RestartLevel();
    }

    public void ShowInGameUI(int levelNo)
    {
        levelUI.Show(levelNo);
    }

    public void HideInGameUI()
    {
        levelUI.Hide();
    }
}
