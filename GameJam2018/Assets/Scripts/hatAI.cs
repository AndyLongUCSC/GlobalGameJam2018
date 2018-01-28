using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatAI : MonoBehaviour {
    Rigidbody2D rigidbody;
    public float speed = 10f;

    private Vector2 startPosition;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y >= 4.5)
        {
            moveDown();
        }
        if(transform.position.y <= -4.4)
        {
            moveUp();
        }
        transform.Translate(0, speed*Time.fixedDeltaTime, 0);
    }
    void moveDown()
    {
        speed = -speed;
    }
    void moveUp()
    {
        speed = -speed;
    }
}
