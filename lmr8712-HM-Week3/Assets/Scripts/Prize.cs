using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Prize : MonoBehaviour
{
    // Create variables
    public float ballY = 1;           //variable to control the Y position of the object
    public float borderX = 45;        //set border for movement on the X axis
    public float borderZ = 15;        //set border for movement on the Z axis
    
    //Called when entering a collision
    void OnCollisionEnter(Collision other) {
         // Make the object appear at a random new position within the space
         transform.position = new Vector3 (
             Random.Range(-borderX, borderX), ballY, Random.Range(-borderZ, borderZ));
             ballY += 1.5f;                                              //make the ball go up a bit
             GameManager.instance.Score++;                               //change the score variable on the GameManager script
     }
}
