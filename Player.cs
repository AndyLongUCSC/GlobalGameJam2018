using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    // Use this for initialization
    public Vector2 startPos;
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerGameOver;
    public static event PlayerDelegate OnPlayerWin;
    public static event PlayerDelegate OnPlayerCollision;
    public float tiltSmooth = 5;
    public float topSpeed = 10f;
    public float drag = 0f;
    public float acceleration = 5f;
    public float letterHealth = 100;
    private Vector3 velocity;
    public float currentSpeed;
    Rigidbody2D rigidbody;

    public float speed = 10;

    Quaternion downRotation;
    Quaternion forwardRotation;
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -60);
        forwardRotation = Quaternion.Euler(0, 0, 25);
	}

    void OnGameStarted()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.simulated = true;

    }

    void OnGameOverConfirmed()
    {
        transform.localPosition = startPos;
        transform.rotation = Quaternion.identity;
    }

    void OnWinConfirmed()
    {

    }
	
	// Update is called once per frame
	void Update () {
        // Y Axis
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = forwardRotation;
            drag = (acceleration / topSpeed);
            rigidbody.velocity += (Vector2.up * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            drag = (acceleration / topSpeed);
            rigidbody.velocity += (-1)*(Vector2.up * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
        else
        {
            rigidbody.velocity += (0) * (Vector2.up * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
        }

        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }
        else if (transform.position.y >= 4.5f)
        {
            transform.position = new Vector2(transform.position.x, 4.5f);
        }

        // X Axis
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity += (Vector2.left * acceleration * Time.fixedDeltaTime);
            currentSpeed = rigidbody.velocity.magnitude;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity += (-1)*(Vector2.left * acceleration * Time.fixedDeltaTime);
            currentSpeed = rigidbody.velocity.magnitude;
        } else
        {
            rigidbody.velocity += (0) * (Vector2.left * acceleration - (drag * rigidbody.velocity)) * Time.fixedDeltaTime;
            currentSpeed = rigidbody.velocity.magnitude;
        }

        if (transform.position.x <= -8f)
        {
            transform.position = new Vector2(-8f, transform.position.y);
        }
        else if (transform.position.x >= 8f)
        {
            transform.position = new Vector2(8f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollisionZone")
        { // indicates where the pidgeon collides with stuff
            letterHealth -= 5;
        }
        if(collision.gameObject.tag == "Boundaries")
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}
