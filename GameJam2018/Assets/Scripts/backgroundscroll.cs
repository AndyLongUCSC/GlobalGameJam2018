using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundscroll : MonoBehaviour {
    Rigidbody2D rigidbody;

    private Vector2 startPosition;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(GameManager.Instance.scrollSpeed, 0);
    }

    void Update()
    {
        if(GameManager.Instance.GameOver == true)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
