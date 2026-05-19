using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem ballImpactPSPrefab;

    public void PlayBallImpactFX(Vector3 pos, Vector3 direction)
    {
        var newPS = Instantiate(ballImpactPSPrefab, transform);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos + direction);
        newPS.Play();
    }
}
