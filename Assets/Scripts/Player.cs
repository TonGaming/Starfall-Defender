using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;


    Vector2 moveInput;
    Vector3 delta;

    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Fly();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>() ;
        
    }

    void Fly()
    {;
        // Lấy ra giá trị -1 1 của trục X trục Y của input và gán vào delta
        //delta = moveInput * moveSpeed;
        
        //float shipPositionX = transform.position.x;
        //shipPositionX += moveInput.x * moveSpeed;

        //float shipPositionY = transform.position.y;
        //shipPositionY += moveInput.y * moveSpeed;

        // transform.position = new Vector2 (shipPositionX, shipPositionY);

        playerRigidbody.velocity = new Vector2(moveInput.x * moveSpeed , moveInput.y * moveSpeed );

    }
}
