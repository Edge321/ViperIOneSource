using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody;
    public float speed = 10.0f;
    public float maxLifetime = 30.0f;
    public float size = 1.0f;
    
    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        //this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value + 360f);
        this.transform.localScale = Vector3.one * this.size;
    }

    public void SetTrajectory(Vector2 direction){

        _rigidbody.AddForce(direction * this.speed);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
        Destroy(this.gameObject, this.maxLifetime);
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Bullet"))
            Destroy(this.gameObject);
        FindObjectOfType<GameManager>().AlienDestroyed();
    }
}

