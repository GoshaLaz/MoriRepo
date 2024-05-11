using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public static float speed = 8;
    private Rigidbody2D rb;

    public Sprite[] SpritePlayer;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.sprite = SpritePlayer[0];
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            spriteRenderer.sprite = SpritePlayer[1];
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = SpritePlayer[2];
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = SpritePlayer[3];
        }
    }
}