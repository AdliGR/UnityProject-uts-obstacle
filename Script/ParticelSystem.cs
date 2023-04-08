using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticelSystem : MonoBehaviour
{
    public Transform playerTransform; // referensi transform pemain
    private Vector3 offset; // jarak antara pemain dan partikel

    void Start()
    {
        offset = transform.position - playerTransform.position; // menghitung jarak awal
    }

    void LateUpdate()
    {
        // mengikuti posisi dan rotasi pemain
        transform.position = playerTransform.position + offset;
        transform.rotation = playerTransform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
