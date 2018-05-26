using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosscene1 : MonoBehaviour {

    // Use this for initialization
    private float oldposition;
    private float highposition;
    private float lowposition;
    private float direction;
    private float start_time_knife;
    private bool move;
    public float delta_oscillate;
    public float speed_high;
    public float delta_time_knife;
    public float damage_amount;
    public float speed;
    public GameObject Knife;
    public GameObject explosion;
    public GameObject point_attack;
    public Slider Slider_Blood;
    public float blood_boss;
    void Start () {
        oldposition = transform.position.y;
        highposition = oldposition + delta_oscillate;
        lowposition = oldposition - delta_oscillate;
        direction = 1;
        start_time_knife = Time.time;
        Slider_Blood.maxValue = blood_boss;
        Slider_Blood.minValue = 0;
        Slider_Blood.value = blood_boss;
        move = true;
        Slider_Blood.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (move && gameObject.transform.position.x >= point_attack.transform.position.x)
        {
            transform.Translate(new Vector2((-1) * Time.deltaTime * speed, 0));
        }
        else
        {
            move = false;
            make_oscillate();
        }
       
	}
    void make_oscillate()
    {
        oldposition += Time.deltaTime * direction * speed_high;
        if (oldposition >= highposition)
        {
            direction *= -1;
            oldposition = highposition;
        }
        else if (oldposition <= lowposition)
        {
            direction *= -1;
            oldposition = lowposition;
        }
        transform.position = new Vector3(transform.position.x, oldposition, transform.position.z);
        if (Time.time > start_time_knife)
        {
            GameObject knife_ref = Instantiate(Knife, gameObject.transform.position, Quaternion.identity);
            start_time_knife = Time.time + delta_oscillate;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            
            if (blood_boss > 0)
            {
                blood_boss -= damage_amount;
                Slider_Blood.value = blood_boss;
            }
            else
            {
                GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject, 0.01f);
                Destroy(exp, 1f);
            }
        }
    }
    
}
