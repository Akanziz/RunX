using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public GameObject laserPrefab;
    public Transform firePoint;
    public float laserSpeed = 10f;
    public AudioSource shootSound;
    private PlayerHealth playerHealth;
    private bool isTakingDamage = false;
    public float laserCooldown = 0.5f;
    private float lastShotTime = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteorite") && !isTakingDamage)
        {
            isTakingDamage = true;
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            StartCoroutine(ResetDamageFlag());
        }
    }
    private IEnumerator ResetDamageFlag()
    {
        yield return new WaitForSeconds(0.5f);
        isTakingDamage = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.position += movement * speed * Time.deltaTime;

        Vector3 playerPosition = transform.position;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;
        
        playerPosition.x = Math.Clamp(playerPosition.x, -cameraWidth, cameraWidth);
        playerPosition.y = Math.Clamp(playerPosition.y, -cameraHeight, cameraHeight);
        transform.position = playerPosition;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + laserCooldown)
        {
                ShootLaser();
            lastShotTime = Time.time;
        }
    }



    void ShootLaser()
    {
        if (firePoint != null)
        {
            shootSound.Play();
            GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * laserSpeed;
            }

            Destroy(laser, 2f);

        }
        else
        {
            Debug.LogWarning("FirePoint not assigned in the Inspector!");
        }
    }
}
