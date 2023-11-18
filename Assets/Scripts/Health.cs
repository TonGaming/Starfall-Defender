using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 50;

    [SerializeField] ParticleSystem hitEffects;

    // get ra object CameraShake
    CameraShake cameraShake;

    // bool này chỉ dành cho player ship chứ k dành cho enemy
    [SerializeField] bool isPlayer;
    [SerializeField] bool applyingCameraShake;

    // Scoring System
    [SerializeField] float scorePerKill = 50f;
    [SerializeField] GameObject fillArea;

    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    LevelManager levelManager;

    void Awake()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        // cameraShake = Camera.main.GetComponent<CameraShake>();

        audioPlayer = FindObjectOfType<AudioPlayer>();

        levelManager = FindObjectOfType<LevelManager>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public int GetHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check xem có chạm vào Damage Dealer k để trừ máu
        // Nếu chạm vào vật thể có DamageDealer thì sẽ lưu tạm vào biến damageDealer
        // còn nếu không thì damageDealer sẽ là null
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            // ăn dame và trừ máu
            TakeDamage(damageDealer.GetDamage());

            PlayHitEffects();

            // chạy hàm lắc màn hình
            ShakeCamera();

            // kẻ địch sẽ bị huỷ đi khi chạm vào ng chơi
            damageDealer.Hit();

            
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //    audioPlayer.PlayExplodingClip();

        //}
        // nếu là player thì điểm giữ nguyên
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        audioPlayer.PlayExplodingClip();

        if (!isPlayer)
        {
            // tăng điểm khi kp player
            scoreKeeper.IncreaseCurrentScore(scorePerKill);

        } 
        else if (isPlayer)
        {
            fillArea.SetActive(false) ;
            levelManager.StartGORoutine();
        }
    }

    void PlayHitEffects()
    {
        if (hitEffects != null)
        {
            // gán vào một biến tạm thời
            ParticleSystem instance = Instantiate(hitEffects, transform.position, Quaternion.identity);

            // huỷ đi sau khi hết thời gian chạy particles
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyingCameraShake)
        {
            cameraShake.ShakeCamera();

            
        }

        // chạy âm thanh ăn đạn 
        audioPlayer.PlayHurtClip();
    }
}
