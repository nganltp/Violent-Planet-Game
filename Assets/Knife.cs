using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public float damage;
    public GameObject target;
    public GameObject explosion;
    void Start()
    {
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            transform.Translate(new Vector2((-1) * Time.deltaTime * speed, 0));
            if (transform.position.x <= target.transform.position.x)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().Damage(damage);
				GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
				Destroy(exp, 0.2f);
				Destroy(gameObject, 0.01f);

            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
            Destroy(exp, 0.5f);
        }
        if (other.gameObject.GetComponent<Player_Controller>())
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().Damage(damage);
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(gameObject, 0.01f);
        }
    }
}
