using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backbutton : MonoBehaviour {

	public void BackButton()
	{
		Application.LoadLevel ("MainMenu");
		Debug.Log ("clicked start");
	}
}
