using DG.Tweening;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private TextMeshPro healthTMP;
    [SerializeField] private int startHealth;
    [SerializeField] SpriteRenderer sr;

    private int _currentHealth;

    public void StartBrick()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1, .2f).SetEase(Ease.OutBounce);

        _currentHealth = startHealth;
    }

    public void GetHit()
    {
        PlayHitFX();
        _currentHealth--;
        healthTMP.text = _currentHealth.ToString();
        if (_currentHealth <= 0)
        {
            DestroyBricks();
        }
    }

    void PlayHitFX()
    {
        //sr.transform.DOScale(1.1f, .1f);
    }

    private void DestroyBricks()
    {
        GetComponentInParent<BrickManager>().BrickDestroyed(this);
        Destroy(gameObject);
    }
}
