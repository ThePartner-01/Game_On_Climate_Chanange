using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamra : MonoBehaviour
{
    public float rotaionSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizantialInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizantialInput * rotaionSpeed * Time.deltaTime);
    }
}
