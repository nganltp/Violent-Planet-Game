using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk1 : MonoBehaviour {
	public Text Akatsuki;
	public Text Boss;
	public float now, initTime;
	//public float diff = Time.time - t;
	// Use this for initialization
	void Start () {
		Boss = Boss.GetComponent<Text> ();
		Boss.text = "Hành tinh này đã tràn ngập sự giận dữ đúng như mong đợi của ta";
		Akatsuki = Akatsuki.GetComponent<Text> ();

		//Akatsuki.text = "Akat_1 ";
		initTime = (float)Time.time;
		Debug.Log(initTime);

		StartCoroutine (PlayConv ());
	}

	IEnumerator PlayConv(){
		//yield return new WaitForEndOfFrame ();

		//yield return new WaitForSeconds (0.016f);

		yield return new WaitForSeconds (2.0f);
		Akatsuki.text = "Ông đã làm gì mọi người";
		Boss.text = "";
		yield return new WaitForSeconds(3.0f);
		Boss.text = "Chính sự căng thẳng vì xã hội bận rộn đã làm chúng trở nên thiếu kiểm soát, ";
		Akatsuki.text = "";
		Debug.Log("waited 1 sec");
		yield return new WaitForSeconds(3.0f);
		Boss.text = "Ta chỉ đổ thêm một ít kích động thôi!!";
		Akatsuki.text = "";
		yield return new WaitForSeconds(3.0f);
		Akatsuki.text = "Ta sẽ đánh bại ông và trả lại hòa bình cho nơi này.";
		Boss.text = "";
		yield return new WaitForSeconds (3.0f);

	}
}
