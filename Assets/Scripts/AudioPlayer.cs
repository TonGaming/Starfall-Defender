using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0, 1)] float shootingVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField][Range(0, 1)] float explodingVolume = 1f;

    [Header("Got Shot ")]
    [SerializeField] AudioClip GotShotClip;
    [SerializeField][Range(0, 1)] float gotShotVolume = 1f;

    // Hàm chung cho tiện
    private void PlayClip (AudioClip clip, float volume)
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
    }

    public void PlayShootingClip()
    {
        //if (shootingClip != null)
        //{
        //    AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        //}

        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayExplodingClip()
    {
        //if(explosionClip != null)
        //{
        //    AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, explodingVolume);
        //}
        PlayClip(explosionClip, explodingVolume);
    }

    public void PlayHurtClip()
    {
        //if(GotShotClip != null)
        //{
        //    AudioSource.PlayClipAtPoint(GotShotClip, Camera.main.transform.position, gotShotVolume);
        //}
        PlayClip(GotShotClip, gotShotVolume);
    }
}
