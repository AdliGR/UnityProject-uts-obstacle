using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_licin : MonoBehaviour
{
    //referensi ke komponen Rigidbody
    private Rigidbody rb;

    //inisialisasi saat script dimulai
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //atur drag dan angular drag menjadi 0
        rb.drag = 0;
        rb.angularDrag = 0;
    }

    //update setiap frame
    void Update()
    {
        
    }

    //ketika objek bersentuhan dengan objek lain
    void OnCollisionEnter(Collision collision)
    {
        //jika objek yang bersentuhan memiliki material
        if(collision.gameObject.GetComponent<Collider>().material != null)
        {
            //atur friction menjadi 0
            collision.gameObject.GetComponent<Collider>().material.staticFriction = 0;
            collision.gameObject.GetComponent<Collider>().material.dynamicFriction = 0;
        }
    }
}
