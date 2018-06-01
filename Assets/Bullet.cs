using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public GameObject point_destroy_bullet;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject != null)
        {
            transform.Translate(new Vector2(Time.deltaTime * speed, 0));
            if (transform.position.x >= point_destroy_bullet.transform.position.x)
            {
                Destroy(gameObject, 0.01f);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Plane>())
        {
            speed = 0;
            Destroy(gameObject, 0.01f);
        }
		if (other.GetComponent<Bosscene1> ()) {
			speed = 0;
			Destroy(gameObject, 0.01f);
		}
    }
}
