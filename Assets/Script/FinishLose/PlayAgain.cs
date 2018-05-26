using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour {

	public void OnPlayAgainClick()
	{
		Application.LoadLevel ("MainMenu");
		Debug.Log ("clicked MainMenu");
	}
}