using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject to_follow;
    public float x, y, z;
    public RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.position = new Vector3(to_follow.transform.position.x + x, to_follow.transform.position.y + y, to_follow.transform.position.z + z);
        
    }
}
