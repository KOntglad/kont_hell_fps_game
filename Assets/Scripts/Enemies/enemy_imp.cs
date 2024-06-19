using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_imp : MonoBehaviour
{
    public Rigidbody enemy_rb;
    public float speed;
    public Transform player_transform;


    // Start is called before the first frame update
    void Start()
    {
        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void follow() 
    {
        transform.LookAt(player_transform);
        enemy_rb.velocity = transform.forward * speed * Time.deltaTime;
    
    }
    
    public void die() 
    {
        Destroy(gameObject);
    }

    public void changeDirection() 
    {
        RaycastHit left;
        RaycastHit right;
        Physics.Raycast(transform.position, transform.right + (-transform.up / 2), out right,5f);
        Physics.Raycast(transform.position, -transform.right + (-transform.up / 2), out left,5f);
        if(left.collider != null)
        Debug.Log("left: " + left.collider.name);
        if(right.collider != null)
        Debug.Log("right: "+ right.collider.name);
    
    }

}
