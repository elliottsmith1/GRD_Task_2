using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

    public string death_cause;
    public string sex;
    public string race;

    public float walk_speed = 3;
    public float run_speed = 6;
    private float speed;

    public bool seeking = false;

    private Vector3 target_location;

	// Use this for initialization
	void Start ()
    {
        speed = walk_speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!seeking)
        {
            RandomMovement();
        }
        else
        {
            transform.LookAt(target_location);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void RandomMovement()
    {
        float rot_speed = 5;
        float rand_turn = Random.Range(-rot_speed, rot_speed);

        Quaternion rot = transform.rotation;
        rot.y += rand_turn;

        transform.Rotate(0, rot.y, 0);        
    }

    public void SetTarget(Vector3 _target)
    {
        seeking = true;
        target_location = _target;
        speed = run_speed;
    }

    public void Reset()
    {
        seeking = false;
        speed = walk_speed;
    }
}
