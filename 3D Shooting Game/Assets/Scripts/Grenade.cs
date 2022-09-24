using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public ParticleSystem particle;
    public Rigidbody rigid;
    public GameObject body;

    void Start()
    {
        //Invoke("Explode", 2);
    }

    public void Explode()
    {
        // 폭발
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        body.SetActive(false);
        particle.Play();

        // 데미지        

        Destroy(gameObject, 3);
    }
}
