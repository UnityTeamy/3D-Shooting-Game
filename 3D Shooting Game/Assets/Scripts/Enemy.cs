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

    //적 개수 관련
    public GameObject Enemyobj;
    public int enemycount;
    public int Maxenemy;
    public float retime;
    public Transform[] point;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Respawn", retime, retime);
        nav = GetComponent <NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            Damage();
        
        
        if(Enemy_health <= 0)
        {
            nav.SetDestination(transform.position);
            Destroy(gameObject, 2);
        }
    }
    
    void Damage()
    {
        Enemy_health -= damage;
        imgBar.fillAmount = Enemy_health / 100.0f;
        //imgBar.transform.localScale = new Vector3(Enemy_health / 100.0f, 1, 1);
        //imgBar.transform.position = new Vector3(0.5f, 0, - imgBar.transform.position.x * Enemy_health / 100.0f);
    }

    public void Respawn()
    {
        if (enemycount >= Maxenemy)
            return;

        enemycount++;
        int i = Random.Range(0, point.Length);
        Instantiate(Enemyobj, point[i]);
    }
}
