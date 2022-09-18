using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior : MonoBehaviour
{
    public int health = 5;

    public float jumpTime = 2;
    public float jumpLaunch = 300.0f;
    public float shootDelay = 1.0f;
    public float lowBulletSpeed = 75.0f;
    public float highBulletSpeed = 125.0f;

    public GameObject bullet;
    public GameObject youWinText;

    public PlayerController playerController;
    public AudioClip victorySound;

    private float tempJumpTime;
    private float tempShootDelay;
    private float maxHealth;

    private int titleScreen = 0;

    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        tempJumpTime = jumpTime;
        tempShootDelay = shootDelay;

        maxHealth = health;
    }
    // Update is called once per frame
    void Update()
    {
        tempJumpTime -= Time.deltaTime;
        tempShootDelay -= Time.deltaTime;

        if (health <= 0)
            Win();
        if (tempJumpTime < 0)
            Jump();
        if (tempShootDelay < 0)
            Shoot();
    }
    /// <summary>
    /// When the boss jumps
    /// </summary>
    private void Jump()
    {
        rigidbody2d.AddForce(Vector2.up * jumpLaunch);

        tempJumpTime = jumpTime;
    }
    /// <summary>
    /// When the boss shoots at the player
    /// </summary>
    private void Shoot()
    {
        float bulletSpeed = Random.Range(lowBulletSpeed, highBulletSpeed);
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        ProjectileBehavior projectileBehavior = currentBullet.GetComponent<ProjectileBehavior>();
        projectileBehavior.Launch(Vector2.one, bulletSpeed);

        tempShootDelay = shootDelay;
    }
    /// <summary>
    /// Activates event for winning the game
    /// </summary>
    private void Win()
    {
        youWinText.SetActive(true);
        gameObject.SetActive(false);

        playerController.PlayVictoryMusic(victorySound);

        Invoke("SwitchScene", 5.0f);
    }
    private void SwitchScene()
    {
        SceneManager.LoadScene(titleScreen);
    }
    /// <summary>
    /// Modifies health bar of the boss
    /// </summary>
    /// <param name="healthModifier"></param>
    public void UpdateHealth(int healthModifier)
    {
        health = (int)Mathf.Clamp(health + healthModifier, 0, maxHealth);
        BossBarBehavior.Instance.ChangeHealthBar(health / (float)maxHealth);
    }
}
