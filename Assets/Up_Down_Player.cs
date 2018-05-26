using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Up_Down_Player : MonoBehaviour {

    float directionY;
    
    public float MoveSpeed ;
   
	void Start () {
       

	}

    void Update () {
        directionY = CrossPlatformInputManager.GetAxis("Vertical")*MoveSpeed*Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + directionY);
      }
}
