using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_drop : MonoBehaviour
{

    private Vector3 initialPosition;
    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 4f); // membuat platform jatuh
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("StartFalling", 1.0f); // menjalankan fungsi StartFalling setelah 1.5 detik
        }
    }

    private void StartFalling()
    {
        isFalling = true;
        Invoke("ResetPlatformPosition", 5f); // menjalankan fungsi ResetPlatformPosition setelah 3 detik
    }

    private void ResetPlatformPosition()
    {
        transform.position = initialPosition; // mengembalikan posisi platform ke posisi awal
        isFalling = false;
    }
}
