using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kipas : MonoBehaviour
{
    public float speed = 2f;
    public float minPauseTime = 0.5f;
    public float maxPauseTime = 1.5f;

    private bool movingUp = true;

    public float pushForce = 10.0f;
    public float pushDirection = -1.0f;

    void Start()
    {
        StartCoroutine(MoveObject());
    }
    

    void Update()
    {
       
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            float newY = transform.position.y + (movingUp ? speed * Time.deltaTime : -speed * Time.deltaTime);

            // Jika gameobject sudah mencapai batas atas atau bawah
            if (newY > 3.5f || newY < -4.5f)
            {
                // Berhenti sebentar dengan waktu yang diacak
                float pauseTime = Random.Range(minPauseTime, maxPauseTime);
                yield return new WaitForSeconds(pauseTime);

                // Mengubah arah gerakan gameobject
                movingUp = !movingUp;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = new Vector3(pushDirection, 0, 0) * pushForce;
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
    }
}
