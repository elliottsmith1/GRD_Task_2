using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    public string death_cause;
    public string sex;
    public string race;

    public float speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RandomMovement();
    }

    void RandomMovement()
    {
        float rot_speed = 5;
        float rand_turn = Random.Range(-rot_speed, rot_speed);

        Quaternion rot = transform.rotation;
        rot.y += rand_turn;

        transform.Rotate(0, rot.y, 0);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
