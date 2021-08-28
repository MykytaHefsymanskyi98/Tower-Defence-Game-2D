using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //references
    Rigidbody2D rigidBody2D;

    //conf param
    [SerializeField] float damage = 50;
    [SerializeField] float launchBulletX = 5f;
    [SerializeField] float launchBulletY = 0f;

    //states
    float rotationZ = -5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(launchBulletX, launchBulletY);
        transform.Rotate(0f, 0f, rotationZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var attackerHealth = collision.GetComponent<Health>();
            attackerHealth.GetHit(damage);
            Destroy(gameObject);
        }
             
    }
}
