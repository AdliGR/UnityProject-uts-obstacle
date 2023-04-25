using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_cabs : MonoBehaviour
{
    public float minSpeed = 1f; // kecepatan minimum pergerakan objek
    public float maxSpeed = 10f; // kecepatan maksimum pergerakan objek
    public float minZ = -14f; // batas bawah posisi z
    public float maxZ = 14f; // batas atas posisi z
    public Vector2 delayTimeRange = new Vector2(1f, 3f); // range waktu delay sebelum objek bergerak kembali

    private bool isMovingUp = true; // variabel untuk menentukan arah pergerakan objek
    private bool isDelayed = false; // variabel untuk menentukan apakah objek sedang delay atau tidak
    private float delayTimer = 0f; // timer untuk menghitung waktu delay
    private float currentSpeed = 0f; // kecepatan pergerakan objek

    void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed); // inisialisasi kecepatan pergerakan objek
    }

    void Update()
    {
        // jika objek sedang delay, kurangi timer dan keluar dari method Update
        if (isDelayed)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0f)
            {
                isDelayed = false;
            }
            return;
        }

        // jika objek berada di posisi z maksimum, ubah arah pergerakan menjadi turun dan mulai delay
        if (transform.position.z >= maxZ)
        {
            isMovingUp = false;
            isDelayed = true;
            delayTimer = Random.Range(delayTimeRange.x, delayTimeRange.y); // atur waktu delay baru setelah delay
            currentSpeed = Random.Range(minSpeed, maxSpeed); // atur kecepatan pergerakan objek baru setelah delay
        }
        // jika objek berada di posisi z minimum, ubah arah pergerakan menjadi naik dan mulai delay
        else if (transform.position.z <= minZ)
        {
            isMovingUp = true;
            isDelayed = true;
            delayTimer = Random.Range(delayTimeRange.x, delayTimeRange.y); // atur waktu delay baru setelah delay
            currentSpeed = Random.Range(minSpeed, maxSpeed); // atur kecepatan pergerakan objek baru setelah delay
        }

        // atur arah pergerakan berdasarkan variabel isMovingUp
        if (isMovingUp)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
    }
}
