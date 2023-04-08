using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallP_push2 : MonoBehaviour
{
    public float speed = 5f; // kecepatan gerakan objek
    public float distance = 10f; // jarak yang ingin ditempuh
    public float returnSpeed = 2f; // kecepatan ketika kembali ke posisi awal
    public float minDelay = 0.5f; // waktu delay minimal sebelum bergerak
    public float maxDelay = 1.5f; // waktu delay maksimal sebelum bergerak

    private float traveledDistance = 0f; // jarak yang sudah ditempuh oleh objek
    private Vector3 initialPosition; // posisi awal objek
    private bool returning = false; // status objek sedang kembali atau tidak
    private float currentDelay = 0f; // waktu delay sebelum bergerak

    void Start()
    {
        initialPosition = transform.position; // menyimpan posisi awal objek
        currentDelay = Random.Range(minDelay, maxDelay); // mengatur waktu delay awal secara random
    }

    void Update()
    {
        if (!returning)
        {
            if (currentDelay <= 0f)
            {
                // menggerakkan objek ke arah sumbu z
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                traveledDistance += speed * Time.deltaTime;

                if (traveledDistance >= distance)
                {
                    // objek telah menempuh jarak yang ditentukan
                    returning = true; // set status objek sedang kembali
                    traveledDistance = 0f; // reset jarak yang sudah ditempuh
                }
            }
            else
            {
                // mengurangi waktu delay
                currentDelay -= Time.deltaTime;
            }
        }
        else
        {
            // menggerakkan objek kembali ke posisi awal dengan pergerakan yang halus
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            traveledDistance += returnSpeed * Time.deltaTime;

            if (transform.position == initialPosition)
            {
                // objek sudah kembali ke posisi awal
                returning = false; // set status objek tidak sedang kembali
                traveledDistance = 0f; // reset jarak yang sudah ditempuh
                currentDelay = Random.Range(minDelay, maxDelay); // mengatur waktu delay secara random untuk pergerakan selanjutnya
            }
        }
    }
}
