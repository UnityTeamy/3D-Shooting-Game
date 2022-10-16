using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //public GameObject ;
    public ParticleSystem particle;
    public Rigidbody rigid;
    public GameObject body;
    public AudioSource sound;

    public bool isboom = true;
    public float spinspeed = 3.0f;
    public GrenadeCreate Create;
    public bool gone;
    public Transform player;
    public float length;

    //grenade count
    //public TextMeshProUGUI grenadecount;
    //public GrenadeCreate grenadecreate;

    void Start()
    {
        if(isboom) Invoke("Explode", 2);
        if (!(isboom))
        {
            gone = false;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().mass = 0;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void Update()
    {
        if(!(isboom))
        Spin();
    }

    public void Explode()
    {
        // 폭발
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        body.SetActive(false);
        particle.Play();
        sound.Play();

        // 데미지        

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, length, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach(RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }    
        Destroy(gameObject, 3);
    }

    public void Spin()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * spinspeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isboom == false && gone == false)
        {
            Create.grenadecount--;
            Create.count++;
            gone = true;
            Destroy(gameObject);
        }
    }
}
