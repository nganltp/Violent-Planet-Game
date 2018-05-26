using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class Controller : MonoBehaviour {
	[SerializeField]
	private AudioSource  audioSource;
	[SerializeField]
	private AudioClip press;
	// Use this for initialization
	public void StartButton()
	{
		Application.LoadLevel ("scene2");
		Debug.Log ("clicked start");
	}
	public void IntroGame()
	{
		Application.LoadLevel ("IntroGame");
		Debug.Log ("clicked start");
	}
	public void CreditButton()
	{
		
		Application.LoadLevel ("Credit");
		Debug.Log ("clicked Credit");
	}
	public void btExit()
	{
		Application.Quit ();
	}
}
