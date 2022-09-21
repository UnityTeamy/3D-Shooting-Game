using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gun : MonoBehaviour
{
    //�� ������Ʈ
    public Transform gun;

    //�÷��̾� ������Ʈ
    public Transform player;

    // �߻� ������
    public float fireDelay = 0.5f;
    float currentTime;

    // �Ѿ� ������Ʈ
    public GameObject bulletPrefab;

    // �Ѿ� �߻� ��ġ
    public Transform firePos;

    // �Ѿ� �߻� �ӵ�
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

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, firePos.position + transform.forward, firePos.rotation);
            // �Ѿ� �ӵ� ����
            bullet.GetComponent<Rigidbody>().velocity = firePos.forward * fireSpeed;
            Destroy(bullet, bullet_destroytime);
            /*else {
               if (Input.GetMouseButton(2))
                   Invoke("Reload", 1f);
           }*/
        }
    }
}
