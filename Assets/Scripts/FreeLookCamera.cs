using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    [Range(0, 2)] public float sensitivity = 1;
    [Range(1, 5)] public float speed = 2;
    //public GameObject hitMarker;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rotate = Vector3.zero;
            rotate.y = Input.GetAxis("Mouse X");
            rotate.x = Input.GetAxis("Mouse Y");

            transform.eulerAngles += rotate * sensitivity;

            //Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Vector3 translate = Vector3.zero;
        translate.x = Input.GetAxis("Horizontal");
        translate.y = Input.GetAxis("Vertical");

        transform.position += (transform.rotation * (translate * speed * Time.deltaTime));

        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            //hitMarker.transform.position = hitInfo.point;
            //Debug.Log("Hit");
        }
    }
}
