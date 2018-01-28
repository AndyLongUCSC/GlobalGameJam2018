using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource BGM;
    public AudioClip BGM1;
    public AudioClip BGM2;
    public AudioClip BGM3;
    public AudioClip BGM4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.level == 0)
        {
            ChangeBGM(BGM1);
        }
        if (GameManager.level == 1)
        {
            ChangeBGM(BGM2);
        }
        if (GameManager.level == 2)
        {
            ChangeBGM(BGM3);
        }
        if (GameManager.level == 3)
        {
            ChangeBGM(BGM4);
        }
        if (GameManager.level == 4)
        {
            ChangeBGM(BGM1);
        }
    }
    
    public void ChangeBGM(AudioClip music)
    {
        if(BGM.clip.name == music.name)
        {
            return;
        }
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
