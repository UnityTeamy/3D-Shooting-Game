using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.tag != "Player" && collision.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }*/
    private void OnColiderEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
