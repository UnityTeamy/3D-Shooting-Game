using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gun : MonoBehaviour
{
    //ÃÑ¾Ë ¹ß»ç ¸ØÃã
    public bool shoot;

    //ÃÑ ¿ÀºêÁ§Æ®
    public Transform gun;

    //ÇÃ·¹ÀÌ¾î ¿ÀºêÁ§Æ®
    public Transform player;

    // ¹ß»ç µô·¹ÀÌ
    public float fireDelay = 0.5f;
    float currentTime;

    // ÃÑ¾Ë ¿ÀºêÁ§Æ®
    public GameObject bulletPrefab;

    // ÃÑ¾Ë ¹ß»ç À§Ä¡
    public Transform firePos;

    // ÃÑ¾Ë ¹ß»ç ¼Óµµ
    public float fireSpeed = 10.0f;

    //bullet destroy
    public float bullet_destroytime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        shoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        gun.transform.LookAt(player.transform.position);
    }
    void Fire()
    {
        currentTime += Time.deltaTime;
        if (currentTime > fireDelay && shoot)
        {
            currentTime = 0;

            // ÃÑ¾Ë »ý¼º
            GameObject bullet = Instantiate(bulletPrefab, firePos.position + transform.forward, firePos.rotation);
            // ÃÑ¾Ë ¼Óµµ ¼³Á¤
            bullet.GetComponent<Rigidbody>().velocity = firePos.forward * fireSpeed;
            Destroy(bullet, bullet_destroytime);
            /*else {
               if (Input.GetMouseButton(2))
                   Invoke("Reload", 1f);
           }*/
        }
    }
}
