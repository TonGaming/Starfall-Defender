using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Awake()
    {
        // get ra material của background hiện tại
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        // offset của material nằm trong các layer background sẽ được tăng dần lên theo từng frame
        offset = moveSpeed + offset;
        
        // chỉnh phần offset của material thông qua mainTextureOffset
        material.mainTextureOffset = offset;
    }
}
