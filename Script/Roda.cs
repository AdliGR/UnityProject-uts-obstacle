using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roda : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosZ = 10.0f;
    public float endPosZ = -10.0f;
    public Vector2 stopTimeRange = new Vector2(0.5f, 2.0f); // rentang waktu berhenti (dalam detik)
    
    private bool movingForward = true;
    private bool stopping = false;
    private float stopTime = 0.0f;
    private float stopTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        stopTime = Random.Range(stopTimeRange.x, stopTimeRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopping) {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopTime) {
                stopping = false;
                stopTimer = 0.0f;
                stopTime = Random.Range(stopTimeRange.x, stopTimeRange.y);
            }
            return;
        }
        
        if (transform.position.z >= startPosZ && movingForward) {
            movingForward = false;
            stopping = true;
        } else if (transform.position.z <= endPosZ && !movingForward) {
            movingForward = true;
            stopping = true;
        }
        
        float direction = movingForward ? 1 : -1;
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
    }

}
