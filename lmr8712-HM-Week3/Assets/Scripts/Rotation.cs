using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject player;

    private float x;

    private float y;

    private float z;

    public bool rotateX;

    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        //x = 0f;
        //y = 0f;
        //z = 1f;
        //rotateX = true;
        //rotationSpeed = 2f;
    }

    private void FixedUpdate()
    {
        transform.Rotate (Vector3.up * Time.deltaTime * 180, Space.Self);
        transform.Rotate (Vector3.left * Time.deltaTime * 180, Space.Self);
        
        // if (rotateX == true)
        // {
        //   x += Time.deltaTime * rotationSpeed;

        /*  if (x > 360f)
          {
              x = 0f;
              rotateX = false;
          }
      }
      else
      {
          z += Time.deltaTime * rotationSpeed;

          if (z > 360f)
          {
              z = 0f;
              rotateX = true;
          }*/
        //   }
         //transform.localRotation = Quaternion.Euler(x,0,z);
    }
/*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        { 
            
            transform.localRotation = UnityEngine.Quaternion.Euler(90, 0f, 0f); 

            //transform.RotateAround(transform.position,Vector3.left, 90);
            //player.transform.Rotate(0, 1 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            transform.RotateAround(transform.position,Vector3.left, 90);
            player.transform.Rotate(0, 1 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            transform.Rotate(0,90,0);
            player.transform.Rotate(0, 1 * Time.deltaTime, 0);
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            transform.Rotate(-90,0,0);
            player.transform.Rotate(0, 1 * Time.deltaTime, 0);
        }
    }*/
}
