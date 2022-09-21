using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gun : MonoBehaviour
{
    //총 오브젝트
    public Transform gun;

    //플레이어 오브젝트
    public Transform player;

    // 발사 딜레이
    public float fireDelay = 0.5f;
    float currentTime;

    // 총알 오브젝트
    public GameObject bulletPrefab;

    // 총알 발사 위치
    public Transform firePos;

    // 총알 발사 속도
    public float fireSpeed = 10.0f;

    //bullet destroy
    public float bullet_destroytime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (currentTime > fireDelay)
        {
            currentTime = 0;

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, firePos.position + transform.forward, firePos.rotation);
            // 총알 속도 설정
            bullet.GetComponent<Rigidbody>().velocity = firePos.forward * fireSpeed;
            Destroy(bullet, bullet_destroytime);
            /*else {
               if (Input.GetMouseButton(2))
                   Invoke("Reload", 1f);
           }*/
        }
    }
}
