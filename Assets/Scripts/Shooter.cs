using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject bullet;

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 5f;

    [Header("Fire Rate Modifications")]
    [SerializeField] float fireRatePlayer = 1f;
    [SerializeField] float fireRateBased = 1f;
    [SerializeField] float fireRateMaximum = 2f;
    [SerializeField] float fireRateVariance = .5f;

    [Header("AI thinggy")]
    [SerializeField] bool useAI; 
    

    [HideInInspector] public bool isFiring;

    // private things
    bool isReload = false;
    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();

    }

    void Fire()
    {
        if (isFiring && !isReload)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring || isReload)
        {
            // Gỡ Coroutine ra khỏi biến để bắn thì có chỗ gán coroutine vào 
            // StopCoroutine(firingCoroutine);
            // firingCoroutine = null;

            return; 

        }

    }

    IEnumerator FireContinuously()  
    {
        do
        {
            Vector3 gunPoint = new Vector3(transform.position.x , transform.position.y + 0.2f, transform.position.z);

            // Gán viên đạn đc spawn ra vào một biến 
            GameObject spawnedBullet = Instantiate(bullet, gunPoint, Quaternion.identity);

            // Get ra rigidbody của viên đạn vừa spawn
            Rigidbody2D bulletRigidbody = spawnedBullet.GetComponent<Rigidbody2D>();

            // giá trị gốc của transform.up là 1 * với bulletSpeed
            bulletRigidbody.velocity = transform.up * bulletSpeed;

            // hàm Destroy tích hợp thời gian luôn nên k cần dùng Invoke hay Coroutine nữa
            Destroy(spawnedBullet, bulletLifeTime);

            // Khi bắn đạn ra rồi thì bật biến bool lên để ngăn k cho bắn ra quá nhiều đạn một lúc mà phải đợi fireRate
            isReload = true;

            // Mỗi khi bắn thì lai goi tới file âm thanh và chạy âm thanh chiu chiu
            audioPlayer.PlayShootingClip();

            if (useAI)
            {
                // một cách làm random logic, một cách khác xem ở EnemySpawner
                float fireRateForBots = Random.Range(fireRateBased - fireRateVariance, fireRateMaximum + fireRateVariance);

                // Clamp giá trị random để bảo đảm k có giá trị âm 
                fireRateForBots = Mathf.Clamp(fireRateForBots, fireRateVariance, fireRateMaximum + fireRateVariance);

                // sau khoảng tgian random thì triển khai
            yield return new  WaitForSecondsRealtime(fireRateForBots);

            } 
            // nếu kp AI (là player) thì không cần Random mà sẽ chạy fixed 
            else if (!useAI)
            {
                yield return new WaitForSecondsRealtime(fireRatePlayer);

            }

            isReload = false;   
        }
        while (isFiring);
    }   
}

