using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MetoriteController : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float fallSpeed = 2f;
        public AudioSource audioSource;
        public AudioClip collisionSound;

    // Update is called once per frame
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyByLaser()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        Destroy(gameObject, audioSource.clip.length);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Laser"))
        {
            if (collisionSound != null)
            {
                AudioSource tempAudioSource = new GameObject("TempAudioSource").AddComponent<AudioSource>();
            tempAudioSource.clip = collisionSound;
            tempAudioSource.Play();
            
            Destroy(tempAudioSource.gameObject, collisionSound.length);
            }

            Destroy(gameObject);
        }
    }
}

