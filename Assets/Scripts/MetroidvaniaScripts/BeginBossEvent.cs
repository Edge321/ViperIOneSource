using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBossEvent : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHealth;
    public GameObject bossDoor;

    public AudioClip bossMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        //Initiate boss battle!
        if (playerController != null)
        {
            boss.SetActive(true);
            bossHealth.SetActive(true);
            bossDoor.SetActive(true);

            playerController.PlayBossMusic(bossMusic);

            Destroy(gameObject);
        }
    }
}