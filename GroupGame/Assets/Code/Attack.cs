using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Shop;

    void Update()
    {
        if (Shop.activeSelf == false)
        {
            if (Input.GetKeyDown("space"))
            {
                Shoot();
                Debug.Log("You have shot a bullet");
            }
        }
    }
    void Shoot ()
    {
        // shooting code
        if (GameObject.FindGameObjectWithTag("Bullet") == null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
