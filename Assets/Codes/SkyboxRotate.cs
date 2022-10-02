using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed = 1.2f;

    public bool move;
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
