using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField] float speed = 5.0f;
    private Vector3 look_at = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(look_at);

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, -Vector3.up, speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
}
