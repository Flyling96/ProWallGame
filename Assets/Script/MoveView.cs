using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveView : MonoBehaviour {


    float rotationY = 0;
    float rotationX = 0;
    void Start()
    {

    }

    void Update ()  
    {
        rotationX +=Input.GetAxis("Mouse X") * 10;
        rotationX = Mathf.Clamp(rotationX, 120, 240);

        rotationY += Input.GetAxis("Mouse Y") * 10;  
        rotationY = Mathf.Clamp (rotationY, -60, 60);  
          

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);   
    }  
      
}
