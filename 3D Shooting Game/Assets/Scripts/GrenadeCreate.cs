using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCreate : MonoBehaviour
{
    public GameObject grenade;
    public Camera myCamera;
    public GameObject grenadePosition;

    //½ò ¼ö ÀÖ´Â ¼ö·ùÅº °³¼ö
    public int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            // RaycastHit rayHit;
            // if (Physics.Raycast(ray, out rayHit, 100))
            // {
            //     Vector3 nextVec = rayHit.point - grenadePosition.transform.position;
                // nextVec.y = 2;

            GameObject instantGrenade = Instantiate(grenade, grenadePosition.transform.position, transform.rotation);
            Rigidbody rigid = instantGrenade.GetComponent<Rigidbody>();
            rigid.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rigid.AddTorque(Vector3.back * 10, ForceMode.Impulse);
            
            // instantGrenade.GetComponent<Grenade>().
        }
    }
}
