using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpforce = 7f;
    private const float Gravity = -9.81f;
    private Vector3 velocity;
    private Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        acceleration = new Vector3(0, Gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpforce;
        }

        velocity += acceleration * Time.deltaTime;

        if (transform.position.y < -5f)
        {
            if (velocity.y < 0) velocity = Vector3.zero;
        }
        else if (transform.position.y > 5)
        {
            if (velocity.y > 0) velocity = Vector3.zero;
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌 위험");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("아악");
        Time.timeScale = 0;
    }
}
