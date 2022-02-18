using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    public float rotateSpeed = 1;
    public Vector3 axisToRotate;
    void Update()
    {
        transform.Rotate(axisToRotate * Time.deltaTime * rotateSpeed); //rotates 50 degrees per second around z axis
    }
}
