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

    // static variables persists on all of the same type of gameObject in the scene
    // static AudioPlayer instance;


    //Singleton Handling
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length; 
        if (instanceCount > 1)
        {
            // destroy game object only works when a frame ends, to prevent anything trying to grab this game object 
            // that we disabled it, which is execute right on the spot
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

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
