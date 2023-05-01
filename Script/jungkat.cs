using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jungkat : MonoBehaviour
{
    public float speed = 5f; // kecepatan jungkat-jungkit saat bergerak
    public float rotateSpeed = 10f; // kecepatan rotasi jungkat-jungkit saat bergerak
    public float maxHeight = 3f; // ketinggian maksimum jungkat-jungkit saat bergerak
    public float minHeight = 0.5f; // ketinggian minimum jungkat-jungkit saat bergerak
    public float groundCheckDistance = 0.1f; // jarak deteksi terhadap permukaan untuk menentukan apakah jungkat-jungkit berada di atas tanah

    private bool isMoving = false; // status pergerakan jungkat-jungkit
    private bool isOnGround = false; // status apakah jungkat-jungkit berada di atas tanah
    private Vector3 startPos; // posisi awal jungkat-jungkit
    private Vector3 targetPos; // posisi target jungkat-jungkit saat bergerak

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // pergerakan jungkat-jungkit ke arah target posisi dengan kecepatan dan rotasi yang sudah ditentukan
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), rotateSpeed * Time.fixedDeltaTime);

            // mengubah target posisi jika jungkat-jungkit sudah mencapai posisi target atau sudah melewati target posisi
            if (transform.position == targetPos || Vector3.Dot(targetPos - transform.position, targetPos - startPos) < 0f)
            {
                targetPos = isOnGround ? startPos : startPos + Vector3.up * maxHeight;
            }
        }
        else
        {
            // deteksi apakah jungkat-jungkit berada di atas tanah atau tidak
            isOnGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // mengaktifkan pergerakan jungkat-jungkit jika pemain menginjak gameobject ini
        if (other.gameObject.tag == "Player")
        {
            isMoving = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        // menonaktifkan pergerakan jungkat-jungkit jika pemain meninggalkan gameobject ini
        if (other.gameObject.tag == "Player")
        {
            isMoving = false;
        }
    }
}
