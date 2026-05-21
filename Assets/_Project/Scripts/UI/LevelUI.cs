using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI levelTMP;
    public void Show(int levelNo)
    {
        gameObject.SetActive(true);
        levelTMP.text = "LEVEL " + levelNo;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
