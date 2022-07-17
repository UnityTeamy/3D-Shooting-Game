using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // make player move
    public float speed = 10f;
    public float jumpForce = 10f;

    float rx;
    float ry;
    public float rotSpeed = 200;
    
    bool isGrounded;

    Rigidbody rigid;

    private void Awake() {
        isGrounded = true;
        rigid = GetComponent<Rigidbody>();
    }

    void Update() {
        Move();
        Rotate();
    }

    void Move() {
        // get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // move player
        Vector3 dir = Vector3.right *x + Vector3.forward * z;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        // jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded) {
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    void Rotate() {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        rx += mx * rotSpeed * Time.deltaTime;
        ry += my * rotSpeed * Time.deltaTime;
        ry = Mathf.Clamp(ry, -90, 90);
        transform.rotation = Quaternion.Euler(0, rx, 0);
        Camera.main.transform.rotation = Quaternion.Euler(-ry, rx, 0);
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
