using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plane : MonoBehaviour
{

    // Use this for initialization
    public float blood;
    public float speed;
    public GameObject explosion;
    public GameObject target;
    public TextMesh show_blood;
    public float damage;
    void Start()
    {
        blood = Random.Range(3, 8);
        speed = Random.Range(2, 5);
        show_blood.text = blood.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            transform.Translate(new Vector2((-1) * speed * Time.deltaTime, 0));
            if (transform.position.x <= target.transform.position.x)
            {
                Destroy(gameObject, 0.01f);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().Damage(damage);
                Destroy(gameObject, 0.1f);
            }
        }
        
    }
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Destroy(gameObject, 0.01f);
    //    gameObject.GetComponent<Renderer>().material.color = Color.blue;
    //}
    void OnTriggerEnter2D(Collider2D other) {
        if (blood > 0) {
            blood--;
            show_blood.text = blood.ToString();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.a - 0.05f, gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b);
        }
        if(blood == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().get_point(1);
            Destroy(gameObject, 0.1f);
        }
    }
    void OnDestroy() {

        GameObject explosion_ref = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosion_ref, 0.5f);
        Destroy(show_blood, 0.01f);
    }
}
