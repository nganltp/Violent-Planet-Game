using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_point : MonoBehaviour {

    // Use this for initialization
    public Text Text_show_point;
	void Start () {
        Text_show_point.text = PlayerPrefs.GetFloat("PlayerX").ToString();
        //Debug.Log("ahihi" +PlayerPrefs.HasKey("PlayerX"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
