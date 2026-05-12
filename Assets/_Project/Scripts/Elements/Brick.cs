using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private TextMeshPro healthTMP;
    [SerializeField] private int startHealth;

    private int _currentHealth;

    public void StartBrick()
    {
        _currentHealth = startHealth;
    }

    public void GetHit()
    {
        _currentHealth--;
        healthTMP.text = _currentHealth.ToString();
        if (_currentHealth <= 0)
        {
            DestroyBricks();
        }
    }

    private void DestroyBricks()
    {
        GetComponentInParent<BrickManager>().BrickDestroyed(this);
        Destroy(gameObject);
    }
}
