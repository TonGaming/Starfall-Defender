using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

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

            // kẻ địch sẽ bị huỷ đi khi chạm vào ng chơi
            damageDealer.Explode();


        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
