using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantExistence : MonoBehaviour {

    public static ConstantExistence instance;

    void Awake()
    {
        if (instance == null)
        {
			instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    void Start () {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OffMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void OnMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void OffSoundEffect()
    {
        AudioListener.volume = 0;
        AudioListener.pause = true;
    }

    public void OnSoundEffect()
    {
        AudioListener.volume = 1;
        AudioListener.pause = false;
    }
}
