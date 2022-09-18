using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 10;
    
    public float shootDelay = 1.0f;
    public float bulletSpeed = 200.0f;
    public float invincibleTimer = 2.0f;

    public GameObject bullet;

    public AudioClip bulletSound;
    
    private float horizontal;
    private float walkSpeed = 0.1f;
    private float jumpForce = 250.0f;
    private float maxHealth;

    private float tempShootDelay;
    private float tempInvincibleTimer;

    private int metroidScene = 2;

    private Vector2 lookDirection = new Vector2(-1, 0);

    private bool jumpBool = true;
    private bool isInvincible = false;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private AudioSource audioSource;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();

        maxHealth = health;
        tempShootDelay = shootDelay;
        tempInvincibleTimer = invincibleTimer;
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Movement", horizontal);

        tempShootDelay -= Time.deltaTime;
        if (isInvincible)
        {
            tempInvincibleTimer -= Time.deltaTime;
            if (tempInvincibleTimer < 0)
                isInvincible = false;
        }
        if (health <= 0)
            SceneReload();

        PlayerInputs();
        SetDirection();
    }
    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * horizontal * walkSpeed);
    }
    /// <summary>
    /// Modifies player's health
    /// </summary>
    /// <param name="healthModifier"></param>
    public void UpdateHealth(int healthModifier)
    {
        if (isInvincible)
            return;

        isInvincible = true;
        tempInvincibleTimer = invincibleTimer;
        health = (int)Mathf.Clamp(health + healthModifier, 0, maxHealth);
        HealthBarBehavior.Instance.ChangeHealthBar(health / (float)maxHealth);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jumpBool = true;
    }
    /// <summary>
    /// All of the players inputs
    /// </summary>
    private void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpBool)
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce);
            jumpBool = false;
        }
        if (Input.GetButtonDown("Fire1") && tempShootDelay < 0)
            FireBullet();
    }
    /// <summary>
    /// Sets direction the player is facing
    /// </summary>
    private void SetDirection()
    {
        Vector2 move = new Vector2(horizontal, 0);

        if (!Mathf.Approximately(move.x, 0.0f))
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);
    }
    /// <summary>
    /// When the player fires a bullet
    /// </summary>
    private void FireBullet()
    {
        Vector3 offset = new Vector3(0, 0.35f);

        tempShootDelay = shootDelay;
        GameObject otherBullet = Instantiate(bullet, transform.position + offset, Quaternion.identity);
        ProjectileBehavior projectileBehavior = otherBullet.GetComponent<ProjectileBehavior>();
        projectileBehavior.Launch(lookDirection, bulletSpeed);

        audioSource.PlayOneShot(bulletSound);
        animator.SetTrigger("Shoot");
    }
    /// <summary>
    /// Reloads the scene
    /// </summary>
    private void SceneReload()
    {
        SceneManager.LoadScene(metroidScene);
    }
    public void PlayBossMusic(AudioClip music)
    {
        //audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }
    public void PlayVictoryMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(music);
    }
}
