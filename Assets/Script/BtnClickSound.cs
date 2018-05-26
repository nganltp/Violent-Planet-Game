using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class BtnClickSound : MonoBehaviour {
	//[SerializeField]
	//private AudioSource  audioSource;
	[SerializeField]
	private AudioClip press;

	public void Start(){
		
		GetComponent<Button> ().onClick.AddListener (() => {
			 
			//audioSource.clip = press;
			//audioSource.PlayOneShot(press);			
			GetComponent<AudioSource>().PlayOneShot(press);	
			Debug.Log("credit000000000000000s");
		
		});
	}

}


	
