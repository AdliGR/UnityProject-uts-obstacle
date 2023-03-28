using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Disc : MonoBehaviour
{
    public Transform[] targets;
    public float speed = 5f;
    private int currentTargetIndex = 0;
    public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cek apakah target sudah diatur
        if (targets == null || targets.Length == 0)
        {
            Debug.LogError("Targets not set.");
            return;
        }

        // Menghitung arah ke target
        Vector3 direction = (targets[currentTargetIndex].position - transform.position).normalized;

        // Menggerakkan game object ke arah target
        transform.position += direction * speed * Time.deltaTime;

        // Jika game object sudah mencapai target saat ini
        if (Vector3.Distance(transform.position, targets[currentTargetIndex].position) < 0.1f)
        {
            // Pindah ke target selanjutnya
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        // Membuat game object berputar pada sumbu Y
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * 100f);
    }

}
