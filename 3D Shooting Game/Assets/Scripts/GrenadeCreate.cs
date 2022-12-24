using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GrenadeCreate : MonoBehaviour
{
    public GameObject grenade;
    public GameObject cameraInHere;
    public GameObject grenadePosition;
    public bool instant;

    public Transform[] point;
    public int Maxgrenade = 3;

    //??????? ??? ????? ????
    public int grenadecount = 0;

    public Player player;
    public float retime;

    //½ò ¼ö ÀÖ´Â ¼ö·ùÅº °³¼ö
    public int count = 0;

    //grenade count
    public TextMeshProUGUI grenadecounting;

    // Start is called before the first frame update
    void Start()
    {
        instant = false;
        InvokeRepeating("Spinning", retime, retime);
    }

    // Update is called once per frame
    void Update()
    {
        grenadecounting.text = "X " + count.ToString();
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
            instantGrenade.GetComponent<Grenade>().isboom = true;
            Rigidbody rigid = instantGrenade.GetComponent<Rigidbody>();

            Vector3 nextVec = new Vector3(transform.forward.x, cameraInHere.transform.forward.y, transform.forward.z);

            rigid.AddForce(nextVec * 20, ForceMode.Impulse);
            // rigid.AddTorque(Vector3.back * 10, ForceMode.Impulse);
            // }
            // instantGrenade.GetComponent<Grenade>().
            count--;
            StartCoroutine("makeInstantTrue");
        }
    }

    IEnumerator makeInstantTrue()
    {
        yield return new WaitForSeconds(0.5f);
        instant = false;
    }

    public void Spinning()
    {
        if (grenadecount >= Maxgrenade)
            return;

        grenadecount++;
        int i = Random.Range(0, point.Length);
        GameObject Grenade_g = Instantiate(grenade).gameObject;
        Grenade_g.transform.position = point[i].position;
        Grenade_g.GetComponent<Grenade>().isboom = false;
        Grenade_g.GetComponent<Grenade>().Create = this;
        Grenade_g.GetComponent<Grenade>().player = player.gameObject.transform;
    }
}
