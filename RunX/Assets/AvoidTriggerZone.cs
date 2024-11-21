using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidTriggerZone : MonoBehaviour
{
    public int pointsForAvoiding = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteorite"))
        {
            Debug.Log("Meteorite Avoided! Adding points.");
            GameManager.instance.AddScore(pointsForAvoiding);
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
