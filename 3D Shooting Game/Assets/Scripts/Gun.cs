using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // 총알 개수
    public int reloadBulletCount = 30;
    public int bulletCount = 30;
    public int handleBulletCount = 100;

    // 발사 딜레이
    public float fireDelay = 0.5f;
    float currentTime;

    // 총알 오브젝트
    public GameObject bulletPrefab;

    // 총알 발사 위치
    public Transform firePos;

    // 총알 발사 속도
    public float fireSpeed = 10.0f;

    public GameObject player;

    public Camera myCamera;

    void Start()
    {

    }

    void Update() {
        // RotateX();
        Fire();
    }

    void RotateX() {
        // transform.rotation = Quaternion.Euler(myCamera.gameObject.transform.rotation.x, 0, 0);
    }
    

    void Fire() {
        currentTime += Time.deltaTime;
        if(Input.GetMouseButton(0)) {
            if(currentTime > fireDelay) {
                if(bulletCount > 0) {
                    currentTime = 0;
                    bulletCount--;

                    // 총알 생성
                    GameObject bullet = Instantiate(bulletPrefab, firePos.position + transform.forward, firePos.rotation);
                    // 총알 속도 설정
                    bullet.GetComponent<Rigidbody>().velocity = firePos.forward * fireSpeed;
                    Destroy(bullet, 2f);
                } else {
                    Reload();
                }
            }
        }
    }

    void Reload() {
        if(handleBulletCount <= 0) {
            return;
        }
        bulletCount = reloadBulletCount;
        handleBulletCount--;
    }
}
