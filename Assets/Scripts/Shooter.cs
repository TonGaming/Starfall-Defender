using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 5f;

    [SerializeField] float fireRate = .5f;

    public bool isFiring;
    bool isReload = false;

    Coroutine firingCoroutine;

    void Start()
    {

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
            Vector3 gunPoint = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);

            // Gán viên đạn đc spawn ra vào một biến 
            GameObject spawnedBullet = Instantiate(playerBullet, gunPoint, Quaternion.identity);

            // Get ra rigidbody của viên đạn vừa spawn
            Rigidbody2D bulletRigidbody = spawnedBullet.GetComponent<Rigidbody2D>();

            // giá trị gốc của transform.up là 1 * với bulletSpeed
            bulletRigidbody.velocity = transform.up * bulletSpeed;

            // hàm Destroy tích hợp thời gian luôn nên k cần dùng Invoke hay Coroutine nữa
            Destroy(spawnedBullet, bulletLifeTime);

            // Khi bắn đạn ra rồi thì bật biến bool lên để ngăn k cho bắn ra quá nhiều đạn một lúc mà phải đợi fireRate
            isReload = true;
            yield return new  WaitForSecondsRealtime(fireRate);

            isReload = false;   
        }
        while (isFiring);
    }   
}

