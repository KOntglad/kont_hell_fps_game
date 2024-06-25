using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_imp : MonoBehaviour
{
    public Rigidbody enemy_rb;
    public float speed;
    public Transform player_transform;
    public Transform strife_left;
    public Transform strife_right;
    public Vector3 direction_transform;

    public float gravity;

    public float prepare_time_now;
    public float prepare_time_max;
    public float strife_state_exit_distance;
    public float speed_mul = 1f;


    public Animator imp_animator;

    public enum imp_states 
    { 
        idle,
        run,
        dash,
        attack_forward,
        prepare,
        strife,
        death

    };


    public imp_states game_imp_states;

    // Start is called before the first frame update
    void Start()
    {
        game_imp_states = imp_states.run;
        imp_animator.SetBool("prepare", false);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (game_imp_states)
        {
            case imp_states.run:
                follow();
                break;
            case imp_states.prepare:
                if (prepare_time_now <= 0)
                {
                    transform.LookAt(player_transform);
                    enemy_rb.velocity = Vector3.zero;
                    enemy_rb.constraints = RigidbodyConstraints.FreezeAll;
                    imp_animator.SetBool("prepare", true);

                }

                prepare_time_now += Time.deltaTime;

                if (prepare_time_now > prepare_time_max)
                {
                    imp_animator.SetBool("prepare", false);
                    enemy_rb.constraints = RigidbodyConstraints.None;
                    transform.LookAt(new Vector3(direction_transform.x, transform.position.y, direction_transform.z));
                    //enemy_rb.constraints = RigidbodyConstraints.FreezePositionY;
                    enemy_rb.constraints = RigidbodyConstraints.FreezeRotationX;
                    enemy_rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                    prepare_time_now = 0f;

                    if (speed_mul == 1)
                    {
                        changeDirection();
                        game_imp_states = imp_states.strife;

                    }
                    else
                    {
                        direction_transform = player_transform.position;
                        game_imp_states = imp_states.dash;
                    }
                }
                break;
            case imp_states.strife:
                moveDirection(speed_mul);
                if (Vector3.Distance(transform.position, direction_transform) < strife_state_exit_distance)
                    game_imp_states = imp_states.run;
                 break;
            
            case imp_states.death:
                die();
                break;
            
            case imp_states.dash:
                moveDirection(speed_mul);
                if (Vector3.Distance(transform.position, direction_transform) < strife_state_exit_distance)
                {
                    speed_mul = 1f;
                    game_imp_states = imp_states.run;
                }
                    break;
            default:
                break;
        }
        
    
    
    }

    void follow() 
    {
        transform.LookAt(new Vector3(player_transform.position.x, transform.position.y,player_transform.position.z));
        enemy_rb.velocity = (transform.forward * speed * Time.deltaTime) - (transform.up * gravity *Time.deltaTime);
      
    }

    public void die() 
    {
        Destroy(gameObject);
    }

    public void moveDirection(float mul)
    {
        transform.LookAt(new Vector3(direction_transform.x,transform.position.y,direction_transform.z));
        enemy_rb.velocity = (transform.forward * mul *speed * Time.deltaTime) - (transform.up * gravity * Time.deltaTime);
        

    }

    public void changeDirection() 
    {

        Vector3 raycastRight = strife_right.position - transform.position;//https://discussions.unity.com/t/how-to-raycast-always-in-direction-of-a-object/129884
        Vector3 raycastLeft = strife_left.position - transform.position;
        RaycastHit left;
        RaycastHit right;
        Physics.Raycast(transform.position,raycastRight, out right,5f);
        Physics.Raycast(transform.position,raycastLeft, out left,5f);
        if(left.collider != null)
        Debug.Log("left: " + left.collider.name);
        if(right.collider != null)
        Debug.Log("right: "+ right.collider.name);
    
        if(left.collider != null || right.collider != null) 
        {
            direction_transform = right.point;
            game_imp_states = imp_states.strife;
        }
        else
        {
            Debug.Log("dir fail");
            return;
        }
    }

}
