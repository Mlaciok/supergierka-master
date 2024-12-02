using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 10f;


    public List<GameObject> zombies;

    void Start()
    {
        zombies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Zombie"));
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            
        }
    }


    void Shoot()
    {
        if (zombies.Count > 0)
        {
            GameObject target = FindClosestZombie();
            if (target != null)
            {
                //Tworzenie pocisku
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

                //Oblicz kierunek do celu
                Vector3 direction = (target.transform.position - spawnPoint.position).normalized;

                //Dodaj sile do pocisku
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = direction * bulletSpeed;

                //zniszcz pocisk po 5 sekundach
                Destroy(bullet, 5f);
            }
        }


    }

    //mistrzowskie szukanie zombie przez skrypt (pewnie niezoptymalizowane, ale dzia³a xD
    GameObject FindClosestZombie()
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        
        foreach (GameObject zombie in zombies)
        {
            float distance = Vector3.Distance(spawnPoint.position, zombie.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = zombie;
            }
        }

        return closest;
    }
}
