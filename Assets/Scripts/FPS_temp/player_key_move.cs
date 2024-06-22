using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_key_move : MonoBehaviour
{
    public CharacterController player_char_controller;

    public float speed = 10f;
    public float gravity = -9.81f;

    public Transform groundControl;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;


    public health player_health;

    public float height = 4f;

    Vector3 yAxisSpeed;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundControl.position, groundDistance, groundLayer);

        if (isGrounded && yAxisSpeed.y < 0)
        {
            yAxisSpeed.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 Hareket = transform.forward * z + transform.right * x;

        player_char_controller.Move(speed * Hareket * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yAxisSpeed.y = Mathf.Sqrt(height * -2f * gravity);
        }

        yAxisSpeed.y += gravity * Time.deltaTime;

        player_char_controller.Move(yAxisSpeed * Time.deltaTime);



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7) 
        {
            player_health.takeDamage(1);
        }
    }

}

