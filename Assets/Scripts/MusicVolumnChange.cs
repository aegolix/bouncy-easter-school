﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumnChange : MonoBehaviour
{
	private AudioSource audioSrc;
	private float musicVolumn = 1.0f;

	// Start is called before the first frame update
    void Start()
    {
		audioSrc = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		audioSrc.volume = musicVolumn;
    }

	public void SetVolumn(float vol)
	{
		musicVolumn = vol;
	}
}
