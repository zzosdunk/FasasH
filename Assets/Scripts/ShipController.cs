using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipController : MonoBehaviour {

    public float playerSpeed = 10f;
    public GameObject bulletPrefab;
    public float reloadTime = 0.25f;
    public List<GameObject> bullets;

    public GameObject shipExplosion;

    private float elapsedTime = 0f;
    private float xMin = -11.0f;
    private float xMax = 11.0f;
    public int i = 0;
    void Start()
    {
        //StartCoroutine(TextTest());
        StartCoroutine(BulletExists());
        List<GameObject> bullets = new List<GameObject>();
    }
    // Update is called once per frame
    void Update () {
        elapsedTime += Time.deltaTime;

        if (transform.position.x > xMin && transform.position.x < xMax)
        {
            float xMov = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
            float yMov = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
            transform.Translate(xMov, yMov, 0f);
        }
        else if(transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin + 0.01f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax - 0.01f, transform.position.y, transform.position.z);
        }
        
	}
    private IEnumerator BulletExists()
    {
        
        while (GameManager.Instance.isGameOver == false)
        {
            yield return new WaitForSeconds(0.5f);
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(0f, 1.2f, 0f);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity) as GameObject;
            bullets.Add(bullet);
            StartCoroutine(DestroyBullet());
        }  
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(bullets.Last());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.EndGame();
        Destroy(gameObject);
        Instantiate(shipExplosion, transform.position, transform.rotation);

        if (collision.gameObject.CompareTag("Border"))
        {
            Debug.Log("coll");
        }
    }
    
}
