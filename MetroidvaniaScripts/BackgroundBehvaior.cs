using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehvaior : MonoBehaviour
{
    private Vector3 correctedVector = new Vector3(0, 0, 10); //Corrects position of background
    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        //Moves the background with the player
        transform.position = Camera.main.transform.position + correctedVector;
    }
}
