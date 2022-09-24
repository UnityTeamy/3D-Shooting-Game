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

    void Start()
    {
        Invoke("Explode", 2);
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

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        foreach(RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }    
        Destroy(gameObject, 3);
    }
}
