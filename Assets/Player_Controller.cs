using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{

    // Use this for initialization
    public Text show_point;
    public GameObject bullet;
    public GameObject point_fire;
    public GameObject frozen_sample;
    public GameObject sample_frozen_explosion;
    public Button button_untimate;
    public Button button_frozen;
    public Slider slider_blood;
    public float time_each_fire;
    public float time_ultimate;
    public float blood_player;
    bool lock_ultimate;
    bool lock_fire_effect;
    bool lock_frozen_effect;
    float start_time_bullet;
    float start_time_ultimate;
    float start_time_end_ultimate;
    GameObject[] enermy;
    GameObject[] frozen;
    float start_time_frozen;
    float[] speed;
    public float time_frozen;
    public float Point_Player;
    public float time_end_ultimate;
    private bool lose_game;
    void Start()
    {
        start_time_bullet = Time.time;
        start_time_frozen = time_frozen;
        lock_ultimate = false;
        start_time_ultimate = time_ultimate;
        lock_fire_effect = false;
        lock_frozen_effect = false;
        start_time_end_ultimate = Time.time;
        button_untimate.animator.enabled = false;
        button_frozen.animator.enabled = false;
        slider_blood.minValue = 0;
        slider_blood.maxValue = blood_player;
        slider_blood.value = blood_player;
        Point_Player = 0;
        lose_game = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > start_time_bullet)
        {
           
            GameObject Bullet = Instantiate(bullet, new Vector2(point_fire.transform.position.x, point_fire.transform.position.y), Quaternion.identity);
            if (lock_ultimate)
            {
                GameObject Bullet1 = Instantiate(bullet, new Vector2(point_fire.transform.position.x, point_fire.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 20)));
                GameObject Bullet2 = Instantiate(bullet, new Vector2(point_fire.transform.position.x, point_fire.transform.position.y), Quaternion.Euler(new Vector3(0, 0, -20)));
                check_End_Ultimate();
            }
            start_time_bullet = Time.time + time_each_fire; //moi giay ban 1 vien
        }
        check_Ultimate();
        check_Frozen();
        check_lose();
        //Ultimate();

    }
    private void Ultimate()
    {
        if (lock_ultimate)
        {
            
        }
    }
    public void Damage(float amount)
    {
        if (blood_player > 0)
        {
            blood_player -= amount;
            slider_blood.value = blood_player;
        }
    }
    public void unlock_Ultimate()
    {
        if (lock_fire_effect) {
            lock_ultimate = true;
            lock_fire_effect = false;
            start_time_ultimate = Time.time + time_ultimate;
            start_time_end_ultimate = Time.time;
            button_untimate.animator.enabled = false;
        }
    }
    public void unlock_Frozen()
    {
        if (lock_frozen_effect)
        {
            Debug.Log("Ahihi");
            lock_frozen_effect = false;
            start_time_frozen = Time.time + time_frozen;
            button_frozen.animator.enabled = false;
            enermy = GameObject.FindGameObjectsWithTag("plane");
            speed = new float[enermy.Length];
            frozen = new GameObject[enermy.Length];
            for (int i = 0;i<enermy.Length;++i)
            {
                
                if (enermy[i].GetComponent<Plane>())
                {
                    speed[i] = enermy[i].GetComponent<Plane>().speed;
                    enermy[i].GetComponent<Plane>().speed = 0;
                }
                else if(enermy[i].GetComponent<Knife>())
                {
                    speed[i] = enermy[i].GetComponent<Knife>().speed;
                    enermy[i].GetComponent<Knife>().speed = 0;
                }
                frozen[i] = Instantiate(frozen_sample, enermy[i].transform.position, Quaternion.identity);
            }

            StartCoroutine(Destroy_frozen());
        }
    }
    IEnumerator Destroy_frozen()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0;i< frozen.Length; ++i)
        {
            if (frozen[i] != null)
            {
                Destroy(frozen[i], 0.01f);
                if (enermy[i].GetComponent<Plane>())
                {
                    enermy[i].GetComponent<Plane>().speed = speed[i];
                }
                else if (enermy[i].GetComponent<Knife>())
                {
                    enermy[i].GetComponent<Knife>().speed = speed[i];
                }
                GameObject exp = Instantiate(sample_frozen_explosion, enermy[i].transform.position, Quaternion.identity);
                Destroy(exp, 0.5f);
            }
        }
    }
    public void check_Ultimate()
    {
        if(start_time_ultimate < Time.time)
        {
            lock_fire_effect = true;
            button_untimate.animator.enabled = true;
            //Phat hieu ung dom lua
        }
    }
    public void check_Frozen()
    {
        if (start_time_frozen < Time.time)
        {
            lock_frozen_effect = true;
            button_frozen.animator.enabled = true;
        }
    }
    public void check_End_Ultimate()
    {
        if ((start_time_end_ultimate + time_end_ultimate < Time.time)&&lock_ultimate)
        {
            lock_ultimate = false;
            
        }
    }
    public void get_point(float point)
    {
        Point_Player += point;
        show_point.text = "Point: " + Point_Player;
    }
    public void check_lose()
    {
        if (blood_player <= 0 && !lose_game)
        {
            lose_game = true;
            Save_Point();
            SceneManager.LoadScene("FinishLose");
        }
    }
    public void Save_Point()
    {
        PlayerPrefs.SetFloat("PlayerX", Point_Player);
    }
   
}
