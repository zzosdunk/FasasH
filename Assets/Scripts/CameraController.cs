using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public ShipController theShip;

    private Vector3 lastShipPosition;
    private float distanceToMove;

    private float xMin = -0.1f;
    private float xMax = 0.1f;

	// Use this for initialization
	void Start () {
        theShip = FindObjectOfType<ShipController>();
        lastShipPosition = theShip.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        distanceToMove = theShip.transform.position.y - lastShipPosition.y;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y + distanceToMove, transform.position.z);
        lastShipPosition = theShip.transform.position;
	}
}
