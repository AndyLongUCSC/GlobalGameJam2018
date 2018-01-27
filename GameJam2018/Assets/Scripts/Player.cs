using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    // Use this for initialization
    public Vector3 startPos;
    public float tiltSmooth = 5;
    Rigidbody2D rigidbody;

    public float speed = 10;

    Quaternion downRotation;
    Quaternion forwardRotation;
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.AddForce(Vector2.up * speed, ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        /*
        else if (Input.GetKey("KeyCode.S"))
        {
            rigidbody.AddForce(Vector2.up * (-1) * speed, ForceMode2D.Force);
        }*/
       /* else
        {
            rigid
            
       body.AddForce(Vector2.up*0, ForceMode2D.Force);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreZone")
        {

        }
        if (collision.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
        }
    }
}
