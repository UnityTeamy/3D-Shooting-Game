using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // make player move
    public float speed = 10f;
    public float jumpForce = 10f;
    
    bool isGrounded;

    Rigidbody rigid;

    private void Awake() {
        isGrounded = true;
        rigid = GetComponent<Rigidbody>();
    }

    void Update() {
        Move();
    }

    void Move() {
        // get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // move player
        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();
        transform.position += move * speed * Time.deltaTime;
        // jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded) {
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
