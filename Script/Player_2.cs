using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{
    public float speed = 5.0f; // kecepatan gerakan
    public float rotationSpeed = 100.0f; // kecepatan rotasi
    public float pushForce = 100.0f; // gaya dorongan saat terkena obstacle
    public float jumpForce = 30.0f; // gaya lompatan
    public ParticleSystem particleSystem; // reference ke particle system yang ingin dikendalikan
    private Rigidbody rb;
    private bool isParticleSystemEnabled = false; // menyimpan status nyala atau mati partikel system

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particleSystem.Stop(); // kondisi awal partikel system dimatikan
    }

    // Update is called once per frame
    void Update()
    {
        // gerakan maju mundur
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, translation);

        if (Input.GetAxis("Vertical") > 0)
        {
            this.GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("run", false);
        }

        // rotasi
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // lompat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // terapkan gaya dorongan ke pemain
            Vector3 pushDirection = transform.position - collision.gameObject.transform.position;
            rb.AddForce(pushDirection * pushForce);

            // mengaktifkan partikel system pada collision
            particleSystem.Play();
            isParticleSystemEnabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // menonaktifkan partikel system pada keluar dari collision
            particleSystem.Stop();
            isParticleSystemEnabled = false;
        }
    }
}
