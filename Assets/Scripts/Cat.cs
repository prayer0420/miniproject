using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public RectTransform front;
    public GameObject hungryCat;
    public GameObject fullCat;
    
    bool isFull = false;

    float full;
    float energy = 0.0f;
    float speed = 0.05f;

    public int type; //1일때 노멀, 2일때 팻

    void Start()
    {
        float x = Random.RandomRange(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector3(x, y, 0);

        if(type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if(type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if(type==3)
        {
            speed = 0.1f;
            full = 10f;
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
        
    }

    void Update()
    {
        if(energy < full)
        {
            transform.position += Vector3.down * speed;
            if (transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if(transform.position.x >0)
            {
                transform.position += Vector3.right * speed;

            }
            else
            {
                transform.position += Vector3.left * speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if(energy<full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy/full, 1.0f, 1.0f);
                Destroy(collision.gameObject);
                if(energy == full)
                {
                    if(!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager.Instance.AddScore();
                    }
                }
            }
        }
    }
}
