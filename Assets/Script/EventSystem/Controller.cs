using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;

public class Controller : MonoBehaviour {
	[SerializeField]
	private AudioSource  audioSource;
	[SerializeField]
	private AudioClip press;
	// Use this for initialization
	public void StartButton()
	{
		SceneManager.LoadScene ("scene2");
		Debug.Log ("clicked start");
	}
	public void IntroGame()
	{
        SceneManager.LoadScene("IntroGame");
		Debug.Log ("clicked start");
	}
	public void CreditButton()
	{

        SceneManager.LoadScene("Credit");
		Debug.Log ("clicked Credit");
	}
	public void btExit()
	{
		Application.Quit ();
	}
}
