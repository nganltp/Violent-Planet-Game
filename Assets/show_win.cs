using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_win : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private AudioSource  audioSource;
	[SerializeField]
	private AudioClip win;
	void Start () {
		audioSource.PlayOneShot(win);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
