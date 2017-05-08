using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary {
    public float zMin, zMax, xMin, xMax;
}

public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;
    private float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;
    

    void Start() {
        speed = 0.1f;
        myRigidbody = GetComponent<Rigidbody>();

        // Shot Time
        fireRate = 0.25f;
        nextFire = 0.0f;

    }

    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(myRigidbody.position.x + moveHorizontal * 
            speed, 0.0f, myRigidbody.position.z + moveVertical * speed);
        myRigidbody.MovePosition(movement);

        // Clamping
        float tempX = Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax);
        float tempZ = Mathf.Clamp(myRigidbody.position.z, boundary.zMin, boundary.zMax);
        Vector3 tempPos = new Vector3(tempX, myRigidbody.position.y, tempZ);

        // Rotation
        float tempRot = moveHorizontal * -tilt;
        myRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, tempRot);
    }

    void Update() {
        if(Input.GetMouseButton(0) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;

            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }

 
}
