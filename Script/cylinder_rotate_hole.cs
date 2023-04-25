using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinder_rotate_hole : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
