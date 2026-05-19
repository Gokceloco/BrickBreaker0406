using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource ballImpactAS;
    [SerializeField] private AudioSource enemyHitAS;

    public void PlayBallImpactAS()
    {
        ballImpactAS.Play();
    }

    public void PlayEnemyHitAS()
    {
        enemyHitAS.Play();
    }
}
