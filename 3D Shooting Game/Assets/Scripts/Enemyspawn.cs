using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemyspawn : MonoBehaviour
{
    //count of kill
    public TextMeshProUGUI Kill;
    public int kill;

    //적 개수 관련
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
        kill = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Kill.text = "Kill X " + kill.ToString();
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
        enemy.GetComponent<Enemy_Gun>().player = player.gameObject.transform;
    }
}
