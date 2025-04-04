using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.Translate(movementVector * Time.deltaTime * movementSpeed, Space.Self);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            //rotate camera counterclockwise
            transform.Rotate(Vector3.up, -1 * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //rotate camera clockwise
            transform.Rotate(Vector3.up, 1 * Time.deltaTime * rotationSpeed);
        }
        if(Input.GetMouseButton(1))
        {
            //rotate camera based on mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotationSpeed);
            transform.GetChild(0).Rotate(Vector3.left, mouseY * Time.deltaTime * rotationSpeed);
        }
    }
}
