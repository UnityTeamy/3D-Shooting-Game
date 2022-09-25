using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCreate : MonoBehaviour
{
    public GameObject grenade;
    public GameObject cameraInHere;
    public GameObject grenadePosition;
    public bool instant;

    //½ò ¼ö ÀÖ´Â ¼ö·ùÅº °³¼ö
    public int count = 10;
    // Start is called before the first frame update
    void Start()
    {
        instant = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && count > 0 && instant == false)
        {
            instant = true;
        //     Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit rayHit;
        //     if (Physics.Raycast(ray, out rayHit, 100))
        //     {
        //         Vector3 nextVec = rayHit.point - grenadePosition.transform.position;

                GameObject instantGrenade = Instantiate(grenade, grenadePosition.transform.position, transform.rotation);
                Rigidbody rigid = instantGrenade.GetComponent<Rigidbody>();

                Vector3 nextVec = new Vector3(transform.forward.x, cameraInHere.transform.forward.y, transform.forward.z);

                rigid.AddForce(nextVec * 20, ForceMode.Impulse);
            // rigid.AddTorque(Vector3.back * 10, ForceMode.Impulse);
            // }
            // instantGrenade.GetComponent<Grenade>().
            count--;
        }
    }
}
