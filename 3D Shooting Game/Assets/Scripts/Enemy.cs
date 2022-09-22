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
    public int damage = 10;
    public Image imgBar;
    public Enemyspawn enemyspawn;
    public Enemy_Gun gun;

    void Start() 
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(player.position);
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
            Damage();
            Destroy(other.gameObject);
        }
    }
    
    void Damage()
    {
        Enemy_health -= damage;
        imgBar.fillAmount = Enemy_health / 100.0f;
        //imgBar.transform.localScale = new Vector3(Enemy_health / 100.0f, 1, 1);
        //imgBar.transform.position = new Vector3(0.5f, 0, - imgBar.transform.position.x * Enemy_health / 100.0f);

        if(Enemy_health <= 0)
        {
            // nav.SetDestination(transform.position);
            nav.enabled = false;
            Destroy(gameObject, 2);
            gun.shoot = false;
            enemyspawn.enemycount--;
            enemyspawn.kill++;
        }
    }
}
