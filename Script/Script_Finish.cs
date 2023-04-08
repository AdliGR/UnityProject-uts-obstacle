using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Finish : MonoBehaviour
{
    public ParticleSystem particles1;
    public ParticleSystem particles2;

    private bool isParticlesOn = false;

    // Method yang akan dipanggil ketika objek dengan tag "Player" melewati trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            ToggleParticles();
            // Lakukan aksi yang diinginkan, misalnya mengubah skor, memunculkan pesan, dll.
        }
    }

    // Method untuk memeriksa tombol yang ditekan
    private void Update()
    {
        // Tidak perlu lagi menggunakan ToggleParticles() karena partikel system tidak perlu dimatikan
    }

    // Method yang dipanggil saat awal permainan
    private void Start()
    {
        particles1.gameObject.SetActive(false); // Matikan partikel system 1
        particles2.gameObject.SetActive(false); // Matikan partikel system 2
    }

    private void ToggleParticles()
    {
        isParticlesOn = !isParticlesOn;
        particles1.gameObject.SetActive(isParticlesOn);
        particles2.gameObject.SetActive(isParticlesOn);
    }
}
