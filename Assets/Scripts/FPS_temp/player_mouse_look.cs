using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mouse_look : MonoBehaviour
{

    public float mouse_sens = 100f;

    public Transform player;

    float xAxisAngle = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Mouse X") * mouse_sens * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse Y") * mouse_sens * Time.deltaTime;

        xAxisAngle -= yAxis;
        xAxisAngle = Mathf.Clamp(xAxisAngle, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xAxisAngle, 0f, 0f);
        player.Rotate(Vector3.up * xAxis);

    }
}
