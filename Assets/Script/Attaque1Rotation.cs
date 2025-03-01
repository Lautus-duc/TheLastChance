using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Attaque1 : MonoBehaviour
{

    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        
        Vector3 mousePosition2 = Input.mousePosition;

        //probleme : Unity concidère la souris en -10, donc nécéssité de changer position;
        mousePosition2.z=50;
        mousePosition2 = Camera.main.ScreenToWorldPoint(mousePosition2);
        Vector3 direction = mousePosition2 - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90);
        
    }
    
}
