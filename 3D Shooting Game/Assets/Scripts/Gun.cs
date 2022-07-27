using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    // 총알 개수
    public int reloadBulletCount = 30;
    public int bulletCount = 30;
    public int handleBulletCount = 100;
    public TextMeshProUGUI bullet_text;
    //https://cholol.tistory.com/445

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

    public GameObject player;

    public Camera myCamera;

    //Reload 여러번 실행 제한
    public bool load = false;

    void Start()
    {

    }

    void Update() {
        // RotateX();
        Fire();
        bullet_text.text = bulletCount.ToString() + " / " + reloadBulletCount.ToString();
    }

    void RotateX() {
        // transform.rotation = Quaternion.Euler(myCamera.gameObject.transform.rotation.x, 0, 0);
    }
    

    void Fire() {
        currentTime += Time.deltaTime;
        if(Input.GetMouseButton(0) && !(load)) {
            if(currentTime > fireDelay) {
                if(bulletCount > 0) {
                    currentTime = 0;
                    bulletCount--;

                    // 총알 생성
                    GameObject bullet = Instantiate(bulletPrefab, firePos.position + transform.forward, firePos.rotation);
                    // 총알 속도 설정
                    bullet.GetComponent<Rigidbody>().velocity = firePos.forward * fireSpeed;
                    Destroy(bullet, bullet_destroytime);
                } /*else {
                    if (Input.GetMouseButton(2))
                        Invoke("Reload", 1f);
                }*/
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && !(load))
        {
            load = true;
            Invoke("Reload", 1f);
            //Reload();
                   
        }
    }

    void Reload() {
        handleBulletCount += bulletCount;
        if (handleBulletCount <= 0) {
            return;
        }
        if (handleBulletCount >= reloadBulletCount)
            {
                bulletCount = reloadBulletCount;
                handleBulletCount -= reloadBulletCount;
            }
            else
            {
                bulletCount = handleBulletCount;
                handleBulletCount = 0;
            }

        load = false;
    }
}
