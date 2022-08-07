using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
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
        Instantiate(Enemyobj, point[i]);
    }
}
