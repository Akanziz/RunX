using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
        private void  OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Meteorite"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
