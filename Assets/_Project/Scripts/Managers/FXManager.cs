using DG.Tweening;
using System;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private float cameraShakeDuration;
    [SerializeField] private float cameraShakeMagnitude;
     
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem ballImpactPSPrefab;
    [SerializeField] private ParticleSystem brickDestroyedPSPrefab;

    public void PlayBallImpactFX(Vector3 pos, Vector3 direction)
    {
        var newPS = Instantiate(ballImpactPSPrefab, transform);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos + direction);
        newPS.Play();
    }

    public void PlayBrickDestroyedPS(Vector3 pos)
    {
        var newPS = Instantiate(brickDestroyedPSPrefab, transform);
        newPS.transform.position = pos;
        newPS.Play();
        ShakeCamera();
    }

    private void ShakeCamera()
    {
        mainCamera.transform.DOShakePosition(cameraShakeDuration, cameraShakeMagnitude, 100);
    }
}
