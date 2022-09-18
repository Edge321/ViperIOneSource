using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float animationTime;
    public float aliveTime = 2.0f;

    private void Awake()
    {
        Invoke("DestroySelf", aliveTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, animationTime);
        Destroy(gameObject);

    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
