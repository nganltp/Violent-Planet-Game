using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject Slider_temp;
    public Slider Slider_Blood;
    public float blood_boss;
	bool win_game;
    void Start () {
        //Slider_Blood.enabled = false;
        //Debug.Log("ahihi");
        Slider_temp.SetActive(false);
        oldposition = transform.position.y;
        highposition = oldposition + delta_oscillate;
        lowposition = oldposition - delta_oscillate;
        direction = 1;
        start_time_knife = Time.time;
        Slider_Blood.maxValue = blood_boss;
        Slider_Blood.minValue = 0;
        Slider_Blood.value = blood_boss;
        move = true;
		win_game = false;
        

    }
	
	// Update is called once per frame
	void Update () {
        if (move && gameObject.transform.position.x >= point_attack.transform.position.x)
        {
            transform.Translate(new Vector2((-1) * Time.deltaTime * speed, 0));
        }
        else
        {
            move = false;Slider_temp.SetActive(true);
            make_oscillate();
        }
		check_win ();
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
		if (Time.time > start_time_knife && !win_game)
        {
            GameObject knife_ref = Instantiate(Knife, gameObject.transform.position, Quaternion.identity);
			start_time_knife = Time.time + delta_time_knife;
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
                //gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
                //gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
                //StartCoroutine(change_color_boss());
				GameObject exp = Instantiate(explosion, new Vector2(transform.position.x-2,transform.position.y), Quaternion.identity);
                Destroy(exp, 0.2f);
            }
            else
            {
				//GameObject exp = Instantiate(explosion,new Vector2(transform.position.x-2,transform.position.y), Quaternion.identity);
                
                //Destroy(exp, 1f);
            }
        }
    }
	void check_win(){
		if (blood_boss <= 0 && !win_game) {
			//GameObject.FindGameObjectWithTag ("Player").GetComponents<Player_Controller> ();
			win_game = true;
			speed_high = 0;
			//Destroy(gameObject, 1f);
			GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(exp, 4f);
			StartCoroutine (Win_Game ());
			//gameObject.SetActive (false);
		}
	}
	IEnumerator Win_Game(){
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene ("FinishWin");

	}
    //IEnumerator change_color_boss()
    //{
    //    yield return new WaitForSeconds(1f);
    //    gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
    //    yield return new WaitForSeconds(1f);
    //    gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
    //}
    
    
}
