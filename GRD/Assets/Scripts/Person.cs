﻿using System.Collections;
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
    private Transform spawn_transform;

    [SerializeField] GameObject light;

    float freq;


    // Use this for initialization
    void Start ()
    {
        speed = walk_speed;

        freq = Random.Range(1.0f, 2.0f);
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
        Bob();

        if ((transform.rotation.x != 0) || (transform.rotation.x != 0))
        {
            Quaternion rot = transform.rotation;
            rot.z = 0;
            rot.x = 0;

            transform.rotation = rot;
        }
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

    public void ResetPerson()
    {
        StopSeeking();

        float offset = 70;
        float rand_offset_x = Random.Range(-offset, offset);
        float rand_offset_z = Random.Range(-offset, offset);
        Vector3 spawn = spawn_transform.position;
        spawn.x += rand_offset_x;
        spawn.z += rand_offset_z;
        transform.position = spawn;

        GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public void SetSpawn(Transform _spawn)
    {
        spawn_transform = _spawn;
    }

    public void EnableLight()
    {
        light.SetActive(true);
    }

    public void StopSeeking()
    {
        light.SetActive(false);

        seeking = false;
        speed = walk_speed;        
    }

    void Bob()
    {
        float amp = 0.5f;
        Vector3 tempPos = transform.position;
        tempPos.y = 1;

        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * amp;

        transform.position = tempPos;
    }
}
