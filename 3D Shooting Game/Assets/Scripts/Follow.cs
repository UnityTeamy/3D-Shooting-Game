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
<<<<<<< HEAD
        rect.position = new Vector3(to_follow.transform.position.x + x, y, to_follow.transform.position.z + z);
=======
        rect.position = new Vector3(x, y, z);
>>>>>>> e1cc1bb17d659ced5b17b37d190190af543beab0
        
    }
}
