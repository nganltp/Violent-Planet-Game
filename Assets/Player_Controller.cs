using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    // Use this for initialization
    public Text show_point;
    public GameObject bullet;
    public GameObject point_fire;
    public Button button_untimate;
    public Slider slider_blood;
    public float time_each_fire;
    public float time_ultimate;
    public float blood_player;
    bool lock_ultimate;
    bool lock_fire_effect;
    float start_time_bullet;
    float start_time_ultimate;
    float start_time_end_ultimate;
    float start_time_frozen;
    public float time_frozen;
    public float Point_Player;
    public float time_end_ultimate;
    void Start()
    {
        start_time_bullet = Time.time;
        start_time_frozen = time_frozen;
        lock_ultimate = false;
        start_time_ultimate = time_ultimate;
        lock_fire_effect = false;
        start_time_end_ultimate = Time.time;
        button_untimate.animator.enabled = false;
        slider_blood.minValue = 0;
        slider_blood.maxValue = blood_player;
        slider_blood.value = blood_player;
        Point_Player = 0;
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
    public void check_Ultimate()
    {
        if(start_time_ultimate < Time.time)
        {
            lock_fire_effect = true;
            button_untimate.animator.enabled = true;
            //Phat hieu ung dom lua
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
}
