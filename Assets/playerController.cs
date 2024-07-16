using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rbBody;
    SpriteRenderer rbSprite;
    public float speed = 1.0f;

     void Start()
    {
        rbSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 movement = new Vector2 (0, 0);

        if (Input.GetKey(KeyCode.D)) {
            movement.x = 1;
            rbSprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            rbSprite.flipX = true;
        }

        rbBody.velocity = new Vector2(movement.x * speed, rbBody.velocity.y);
    }
}
