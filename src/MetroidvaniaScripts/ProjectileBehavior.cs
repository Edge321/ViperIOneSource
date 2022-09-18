using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float timeAlive = 3.0f;
    
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive < 0)
            Destroy(gameObject);
    }
    /// <summary>
    /// Launches the projectile based on direction and speed
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="speed"></param>
    public void Launch(Vector2 direction, float speed)
    {
        if (direction.x >= 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        rigidbody2d.AddForce(direction * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BossBehavior behavior = collision.gameObject.GetComponent<BossBehavior>();
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        RobotBehavior robotBehavior = collision.gameObject.GetComponent<RobotBehavior>();
        //Checks which was collided with
        if (behavior != null)
            behavior.UpdateHealth(-1);
        if (playerController != null)
            playerController.UpdateHealth(-1);
        if (robotBehavior != null)
            robotBehavior.ChangeHealth(-1);

        Destroy(gameObject);
    }
}
