using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enermy_Controller : MonoBehaviour {

    // Use this for initialization
    public Text[] Array_Number;
    public GameObject Boss;
    public GameObject Player;
    public GameObject[] Array_Plane;
    public GameObject[] Array_Position;
    public GameObject[] sample_enermy;
    public Text Sample_text;
    public float Point_See_Boss;
    public float deltatime_born_enermy;
  
    private float start_born_enermy ;
    private int num_enermy;
    private bool see_boss;
    private int[] array_bit;
	void Start () {
        array_bit = new int[5];
        start_born_enermy = Time.time;
        Array_Plane = new GameObject[5];
        Array_Number = new Text[5];
        see_boss = false;
        Boss.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
            for (int i = 0; i < array_bit.Length; ++i)
            {
                if (array_bit[i] == 1)
                {
                    //Array_Number[i].transform.position = Array_Plane[i].transform.position;
                    //float temp_blood = Array_Plane[i].GetComponent<Plane>().blood;
                   // Array_Number[i].text = temp_blood.ToString();
                }
            }
        
        if(Time.time > start_born_enermy)
        {
            start_born_enermy = Time.time + deltatime_born_enermy;
            born_enermy();
            
        }
        check_see_boss();
	}
    void born_enermy()
    {
        if (!see_boss)
        {
            int temp_enermy = Random.Range(0, 7);
            for (int i = 0; i < 5; ++i)
            {
                array_bit[i] = Random.Range(-1, 2);
                if (array_bit[i] == 1)
                {
                    Array_Plane[i] = Instantiate(sample_enermy[temp_enermy], Array_Position[i].transform.position, Quaternion.identity);

                }
            }
        }
     }
    void check_see_boss()
    {
        if (Player.GetComponent<Player_Controller>().Point_Player >= Point_See_Boss&&!see_boss)
        {
            see_boss = true;
            Boss.SetActive(true);
            Boss.GetComponent<Bosscene1>().Slider_Blood.enabled = true;
        }
    }
}
