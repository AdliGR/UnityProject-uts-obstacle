using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float pushForce = 100.0f;
    public float jumpForce = 30.0f;

    private Rigidbody rb;
    private GameObject spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint");
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
        else if (collision.gameObject.CompareTag("ObstacleRes"))
        {
            // Teleport player to spawn position
            transform.position = spawnPosition.transform.position;
        }
    }
}
