using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool invincible = false;
    public int count = 4;
    Rigidbody2D rigidbody;

    public Sprite my1Image; //Drag your first sprite here in inspector.
    public Sprite my2Image; //Drag your second sprite here in inspector.
    public Sprite my3Image;
    public Sprite my4Image;

    public Sprite my1Image2;
    public Sprite my1Image3;

    public float speed = 10;

    Quaternion downRotation;
    Quaternion forwardRotation;
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        /*downRotation = Quaternion.Euler(0, 0, -60);
        forwardRotation = Quaternion.Euler(0, 0, 25);*/
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = my1Image;
        if (GameManager.level == 1)
        {
            renderer.sprite = my1Image;
        }
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
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (GameManager.level == 2)
        {
            renderer.sprite = my1Image2;
        }
        else if (GameManager.level == 3)
        {
            renderer.sprite = my1Image3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (!invincible)
        {
            if (collision.gameObject.tag == "Enemies")
            { // indicates where the pidgeon collides with stuff
               
                OnPlayerCollision(); //event sent to healthbar1
                invincible = true;
                count--;
                if (count != 0)
                {
                    if(GameManager.level == 1)
                    {
                        if (count == 3) {
                            renderer.sprite = my2Image;
                        }
                        if (count == 2)
                        {
                            renderer.sprite = my3Image;
                        }
                        if (count == 1)
                        {
                            renderer.sprite = my4Image;
                        }
                    }               
                    renderer.color = new Color(0.121f, 1f, 0.039f, 1.0f);
                    Invoke("resetInvul", 2);
                }
                else
                {
                    OnPlayerGameOver();//event sent to gamemanager
                }
            }
        }
        if(collision.gameObject.tag == "Finish")
        {
            OnPlayerWin(); //event sent to gamemanager
            count = 4;
            if(GameManager.level == 3)
            {
                transform.localScale += new Vector3(0.2F, 0.2F, 0);
            }
        }
        if(collision.gameObject.tag == "Boundaries")
        {
            renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
    void resetInvul()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        invincible = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
