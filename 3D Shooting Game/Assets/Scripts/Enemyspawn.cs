using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    //�� ���� ����
    public GameObject Enemyobj;
    public int enemycount;
    public int Maxenemy;
    public float retime;
    public Transform[] point;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Respawn", retime, retime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        if (enemycount >= Maxenemy)
            return;

        enemycount++;
        int i = Random.Range(0, point.Length);
        GameObject enemy = Instantiate(Enemyobj).gameObject;
        enemy.transform.position = point[i].position;
        enemy.GetComponent<Enemy>().player = player.gameObject.transform;
        enemy.GetComponent<Enemy>().enemyspawn = this;
    }
}
