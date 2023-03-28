using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; // kecepatan gerakan
    public float rotationSpeed = 100.0f; // kecepatan rotasi
    public float pushForce = 100.0f; // gaya dorongan saat terkena obstacle
    public float jumpForce = 30.0f; // gaya lompatan

     private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // gerakan maju mundur
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, translation);

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
        }
    }
}
