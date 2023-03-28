using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palu : MonoBehaviour
{
    public float swingSpeed = 2f;   // Kecepatan ayunan
    public float swingAngle = 90f;  // Besar sudut maksimum ayunan
    private float currentAngle;     // Sudut saat ini
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Menghitung sudut berikutnya menggunakan sin dan waktu
        float nextAngle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        
        // Menghitung perbedaan sudut dengan sudut saat ini
        float angleDiff = nextAngle - currentAngle;
        
        // Memutar game object sebesar perbedaan sudut
        transform.Rotate(Vector3.forward, angleDiff);
        
        // Memperbarui sudut saat ini
        currentAngle = nextAngle;
    }
}
