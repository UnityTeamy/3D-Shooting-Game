using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    NavMeshAgent nav;
    public int Enemy_health = 100;
    public int fullhealth = 100;
    public int damage = 10;
    public Image imgBar;
    public Enemyspawn enemyspawn;
    public Enemy_Gun gun;
    Rigidbody rigid;
    bool dead = false;

    void Start() 
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(player.position);
        rigid = GetComponent<Rigidbody>();
        fullhealth = Enemy_health;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy_health > 0) nav.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Damage(fullhealth/3+1);
            Destroy(other.gameObject);
        }
    }
    
    void Damage(int damagesize)
    {
        Enemy_health -= damagesize;
        imgBar.fillAmount = (float) Enemy_health / (float) fullhealth;
        //imgBar.transform.localScale = new Vector3(Enemy_health / 100.0f, 1, 1);
        //imgBar.transform.position = new Vector3(0.5f, 0, - imgBar.transform.position.x * Enemy_health / 100.0f);

        if(Enemy_health <= 0 && !(dead))
        {
            // dead

            dead = true;
            // nav.SetDestination(transform.position);
            nav.enabled = false;
            gun.shoot = false;
            enemyspawn.enemycount--;
            enemyspawn.kill++;
            
            Destroy(gameObject, 2);
        }
    }

    public void HitByGrenade(Vector3 explosionPos)
    {
        Damage(fullhealth);
        Debug.Log(Enemy_health);
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec));
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        yield return new WaitForSeconds(0.1f);

        //gameObject.layer = 14;

        reactVec = reactVec.normalized;
        //reactVec += Vector3.up;
        //rigid.AddForce(reactVec * 5, ForceMode.Impulse);
    }

}
