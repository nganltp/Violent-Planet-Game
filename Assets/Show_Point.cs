using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Show_Point : MonoBehaviour {

	// Use this for initialization
	public Text Show_point;
	[SerializeField]
	private AudioSource  audioSource;
	[SerializeField]
	private AudioClip lose;
	void Start () {
		audioSource.PlayOneShot(lose);
		Show_point.text = PlayerPrefs.GetFloat ("PlayerX").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
