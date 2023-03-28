using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerTransform;
    public float distance = 10.0f; // jarak antara kamera dan player
    public float height = 5.0f; // ketinggian kamera dari player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // Mengatur posisi kamera
            transform.position = playerTransform.position - playerTransform.forward * distance;
            transform.position += Vector3.up * height;
            // Mengatur rotasi kamera
            transform.rotation = Quaternion.LookRotation(playerTransform.position - transform.position, Vector3.up);
        }
    }
}
