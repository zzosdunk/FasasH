using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;

    public GameObject explosion;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        HitTarget();
        GameManager.Instance.AddScore();
        Destroy(gameObject);
        
    }
    void HitTarget()
    {
        GameObject bulletEffect = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        Destroy(bulletEffect, 3f);
    }
}
