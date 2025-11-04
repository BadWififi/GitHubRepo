using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
            Debug.Log("You have shot a bullet");
        }
    }
    void Shoot ()
    {
        // shooting code
    }
}
