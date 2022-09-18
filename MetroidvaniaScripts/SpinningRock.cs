using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRock : MonoBehaviour
{
    private float spinSpeed = 1.0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, spinSpeed);
    }
}
