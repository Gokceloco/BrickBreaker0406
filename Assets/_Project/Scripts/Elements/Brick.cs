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
        transform.DOScale(1, .3f).SetEase(Ease.OutElastic);

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

    private void OnDestroy()
    {
        sr.transform.DOKill();
        healthTMP.DOKill();
        healthTMP.transform.DOKill();
    }

    void PlayHitFX()
    {
        sr.transform.DOKill();
        sr.transform.localScale = Vector3.one * 1.2f;
        sr.transform.DOScale(1.5f, .1f).SetLoops(2, LoopType.Yoyo);

        healthTMP.transform.DOKill();
        healthTMP.transform.localScale = Vector3.one;
        healthTMP.transform.DOScale(1.5f, .1f).SetLoops(2, LoopType.Yoyo);

        healthTMP.DOKill();
        healthTMP.color = Color.white;
        healthTMP.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
    }

    private void DestroyBricks()
    {
        GetComponentInParent<BrickManager>().BrickDestroyed(this);
        Destroy(gameObject);
    }
}
