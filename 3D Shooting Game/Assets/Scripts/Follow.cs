using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // this script is for health bar to follow target
    public Transform target;

    void Update()
    {
        transform.position = target.position + new Vector3(0, 1.2f, 0);
    }

    /*
    // public GameObject to_follow;
    // public float x, y, z;
    // public RectTransform rect;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rect = gameObject.GetComponent<RectTransform>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // make health bar follow to_follow
    //     // x = to_follow.transform.position.x;
    //     // y = to_follow.transform.position.y;
    //     // z = to_follow.transform.position.z;
    //     // rect.position = new Vector3(x, y, z);
    //     rect.position = new Vector3(to_follow.transform.position.x, to_follow.transform.position.y + y, to_follow.transform.position.z);
    //     Debug.Log(to_follow.transform.position);
    //     Debug.Log(rect.position);
    // }
    */
}
