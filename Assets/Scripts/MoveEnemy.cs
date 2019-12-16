using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    [Range(0,100)]
    public float speed = 3;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            if (!spr.flipX)
                rb2d.MovePosition((Vector2)transform.position + Vector2.right * speed * Time.fixedDeltaTime);

            else
                rb2d.MovePosition((Vector2)transform.position + Vector2.left * speed * Time.fixedDeltaTime);

        }
    }


}
