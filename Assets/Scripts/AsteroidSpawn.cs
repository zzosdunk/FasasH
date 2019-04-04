using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    public GameObject asteroidPrefab;

    public CameraController camera;
    private Vector3 lastCameraPosition;

    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 2f;

	void Start () {
        camera = FindObjectOfType<CameraController>();
        

        Spawn();
	}
    private void Update()
    {
        lastCameraPosition = camera.transform.position;
    }

    void Spawn()
    {
        Vector3 spawnPos = new Vector2(Random.Range(-6, 6), lastCameraPosition.y + 10f);

        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
