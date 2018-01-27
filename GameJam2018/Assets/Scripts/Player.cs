using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    // Use this for initialization
    //public Vector3 startPos;
    public float tiltSmooth = 5;
    public float topSpeed = 10f;
    public float drag = 0f;
    public float acceleration = 10f;
    private Vector3 velocity;
    public float currentSpeed;
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = forwardRotation;
            drag = (acceleration / topSpeed);
            rigidbody.velocity += (Vector2.up * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
        }
       
      
        if (Input.GetKey(KeyCode.S))
        {
            drag = (acceleration / topSpeed);
            rigidbody.velocity += (-1)*(Vector2.up * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
        else
        {
            rigidbody.AddForce(Vector2.up*0, ForceMode2D.Force);
        }
        // Y axis
        if (transform.position.y <= -4.6f)
        {
            transform.position = new Vector2(transform.position.x, -4.6f);
            currentSpeed = 0;
        }
        else if (transform.position.y >= 4.16f)
        {
            transform.position = new Vector2(transform.position.x, 4.16f);
            currentSpeed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreZone")
        {
            ;
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            rigidbody.simulated = false;
        }
        if(collision.gameObject.tag == "Boundaries")
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}
