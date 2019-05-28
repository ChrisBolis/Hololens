using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoarding : MonoBehaviour
{
    public float rotx = -0.5f;
    public float roty = 130;
    public float rotz = 0;

    void Start()
    {

    }

    void Update()
    {

        this.transform.LookAt(Camera.main.transform);
        this.transform.localRotation *= Quaternion.Euler(rotx, roty, rotz);

    }

}