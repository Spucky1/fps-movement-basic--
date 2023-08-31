using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarastuff : MonoBehaviour
{
   [SerializeField] private float senX;
    [SerializeField] private float senY;
    Camera cam;
    float mouseX;
    float mousey;

    public float multiplier = 0.01f;

    float xRotacion;
    float yRotacion;

    private void Start() 
    {
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
      
    }
    private void Update() 
    {
     MyInput();
     cam.transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);
     transform.rotation = Quaternion.Euler(0, yRotacion, 0);

    }
     void MyInput()
    {
    mouseX = Input.GetAxisRaw("Mouse X");
    mousey = Input.GetAxisRaw("Mouse Y");

    yRotacion += mouseX * senX * multiplier;
    xRotacion -= mousey * senY * multiplier;
      
    xRotacion = Mathf.Clamp(xRotacion, -90f, 90f);
    
 }
}
