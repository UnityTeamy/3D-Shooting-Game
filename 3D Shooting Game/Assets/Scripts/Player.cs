using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // make player move
    public float speed = 10f;
    public float jumpForce = 10f;

    float rx;
    float ry;
    // public float rotSpeed = 200;

    bool isGrounded;

    Rigidbody rigid;

    // Camera
    public Camera cam;
    public GameObject camInHere;

    [SerializeField]
    public float lookSensitivity;

    [SerializeField]
    float cameraRotateLimit;
    float currentCameraRotationX = 0;

    public bool isDead = false;

    private void Awake()
    {
        isGrounded = true;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isDead)
        {
            Move();
            PlayerRotate();
            CameraRotate();
        }
    }

    void Move()
    {
        // get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // move player
        Vector3 dir = Vector3.right * x + Vector3.forward * z;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    void PlayerRotate()
    {
        // 좌우 플레이어 회전
        // float _xRotation = Input.GetAxis("Mouse Y");
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _playerRotation = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(_playerRotation));
    }

    void CameraRotate()
    {
        // 상하 카메라 회전
        float _xRotation = Input.GetAxis("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotateLimit, cameraRotateLimit);

        camInHere.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0); // rotate camera
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
