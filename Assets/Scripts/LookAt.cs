using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform followed;
    public bool reverse = false;
    public bool lockY;

    // Start is called before the first frame update
    void Start()
    {
        if(followed == null)
        {
            followed = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lockY)
        {
            transform.LookAt(new Vector3(followed.position.x, transform.position.y, followed.position.z));
        }
        else
        {
            if (reverse)
            {
                transform.LookAt(2 * transform.position - followed.position);
            }
            else
            {
                transform.LookAt(followed);
            }
        }
    }
}
