using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //HP
    public TextMeshProUGUI HP;

    public int Player_health = 100;
    public int damage = 10;

    //Damage 판단
    bool bDamage;

    //Damage 효과
    public Image imgDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bDamage)
        {
            imgDamage.color = new Color(1, 0, 0, 0.5f);
        }
        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 2 * Time.deltaTime);
        }

        bDamage = false;
        HP.text = "HP : " + Player_health.ToString() + " / 100";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet_Enemy")
        {
            Damage();
            Destroy(other.gameObject);
        }
    }

    void Damage()
    {
        Player_health -= damage;

        if (Player_health <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
            //Destroy(gameObject, 2);
        }
        bDamage = true;
    }
}
