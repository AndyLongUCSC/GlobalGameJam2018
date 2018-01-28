using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar1 : MonoBehaviour {

    Image myImageComponent;
    public Sprite myFirstImage; //Drag your first sprite here in inspector.
    public Sprite mySecondImage; //Drag your second sprite here in inspector.
    public Sprite myThirdImage;
    public Sprite myFourthImage;
    public Sprite myFifthImage;

    public Sprite myFirstImage2; 
    public Sprite mySecondImage2; 
    public Sprite myThirdImage2;
    public Sprite myFourthImage2;
    public Sprite myFifthImage2;

    public Sprite myFirstImage3;
    public Sprite mySecondImage3;
    public Sprite myThirdImage3;
    public Sprite myFourthImage3;
    public Sprite myFifthImage3;

    public Sprite blank;

    public int count = 4;
    public static int remain = 4;

    private void OnEnable()
    {
        Player.OnPlayerCollision += OnPlayerCollision;
        Player.OnPlayerWin += OnPlayerWin;
    }

    private void OnDisable() {
        Player.OnPlayerCollision -= OnPlayerCollision;
        Player.OnPlayerWin -= OnPlayerWin;
    }
    void OnPlayerCollision()
    {
        count--;
    }
    private void OnPlayerWin()
    {
        remain = count;
        count = 4;
    }
    
    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
    }

    void Update()
    {
        if (count == 3)
        {
            SetImage2();
        }
        else if (count == 2)
        {
            SetImage3();
        }
        else if (count == 1)
        {
            SetImage4();
        }
        else if (count == 0)
        {
            SetImage5();
        }
        if(GameManager.level == 0)
        {
            myImageComponent.sprite = blank;
        }

    }
    public void SetImage1() //method to set our first image
    {
        if (GameManager.level == 1)
        {
            myImageComponent.sprite = myFirstImage;
        }
        if (GameManager.level == 2)
        {
            myImageComponent.sprite = myFirstImage2;
        }
        if (GameManager.level == 3)
        {
            myImageComponent.sprite = myFirstImage3;
        }
    }

    public void SetImage2()
    {
       if (GameManager.level == 1)
        {
            myImageComponent.sprite = mySecondImage;
        }
        if (GameManager.level == 2)
        {
            myImageComponent.sprite = mySecondImage2;
        }
        if (GameManager.level == 3)
        {
            myImageComponent.sprite = mySecondImage3;
        }
    }
    public void SetImage3()
    {
        if (GameManager.level == 1)
        {
            myImageComponent.sprite = myThirdImage;
        }
        if (GameManager.level == 2)
        {
            myImageComponent.sprite = myThirdImage2;
        }
        if (GameManager.level == 3)
        {
            myImageComponent.sprite = myThirdImage3;
        }
    }
    public void SetImage4()
    {
        if (GameManager.level == 1)
        {
            myImageComponent.sprite = myFourthImage;
        }
        if (GameManager.level == 2)
        {
            myImageComponent.sprite = myFourthImage2;
        }
        if (GameManager.level == 3)
        {
            myImageComponent.sprite = myFourthImage3;
        }
    }
    public void SetImage5()
    {
        if (GameManager.level == 1)
        {
            myImageComponent.sprite = myFifthImage;
        }
        if (GameManager.level == 2)
        {
            myImageComponent.sprite = myFifthImage2;
        }
        if (GameManager.level == 3)
        {
            myImageComponent.sprite = myFifthImage3;
        }
        count = 4;
    }
}

