using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    //조준 이미지
    public GameObject Frame;

    public float FieldOfView = 60.0f;
    public float NormalFov = 60.0f;
    public float AimingFov = 10.0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        FieldOfView = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView = FieldOfView;
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //Aiming
            Frame.SetActive(true);
            if (FieldOfView <= AimingFov)
            {
                FieldOfView = AimingFov;
            }
            else
            {
                FieldOfView -= Time.deltaTime * speed;
            }
        }
        else
        {
            //not Aiming
            Frame.SetActive(false);
            if (FieldOfView >= NormalFov)
            {
                FieldOfView = NormalFov;
            }
            else
            {
                FieldOfView += Time.deltaTime * speed;
            }
        }
    }
}
