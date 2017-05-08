using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Rigidbody myRigidbody;

    public float speed;
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = transform.forward * speed;
		
	}
}
