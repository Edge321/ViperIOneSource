using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour
{
    public int health = 3;
    
    public float changeMovement = 3.0f;
    public float moveSpeed = 0.05f;

    private Vector2 moveVector;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveVector = new Vector2(1, 0);
        InvokeRepeating("Movement", 0, changeMovement);
    }
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    // FixedUpdate is called once per fixed frame
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * moveVector * moveSpeed);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
            playerController.UpdateHealth(-1);
    }
    /// <summary>
    /// Change movement of robot
    /// </summary>
    private void Movement()
    {
        if (!spriteRenderer.flipX)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        moveVector = -moveVector;
    }
    /// <summary>
    /// Change health of robot
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHealth(int value)
    {
        health += value;
    }
}
