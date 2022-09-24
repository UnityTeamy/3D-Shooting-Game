using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Transform player;
    public GameObject grenade;

    //½ò ¼ö ÀÖ´Â ¼ö·ùÅº °³¼ö
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            grenade.transform.position = player.transform.position;
        }
    }
}
