using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_demon : MonoBehaviour
{
    public float speed;
    public Rigidbody demon_rb;
    
    
    public GameObject demon_projectile;
    public Transform fire_position;
    public float fire_speed;
    
    
    public Transform player_transform;
    public Vector3 follow_transform;

    public enum demon_states
    {
        idle,
        prepare_direction,
        prepare_direction_non_raycast,
        run,
        fire,
        triple_fire,
        hit
    };

    public enum demon_run_states 
    {
        forward,
        left,
        right
    
    };


    public demon_states object_demon_states;
    public demon_run_states object_demon_run_states;

    public int cycle;
    public float demon_player_distance;

    public float damaged_time_now;
    public float damaged_time_max;
       
    public float change_time_now;
    public float change_time_max;

    public float fire_time_now;
    public float fire_time_max;

    public Transform[] raycast_positions;
    public RaycastHit[] raycast_hits;
    public Vector3[] raycastHitsVectors;

    // Start is called before the first frame update
    void Start()
    {
        object_demon_states = demon_states.idle;
        object_demon_run_states = demon_run_states.forward;
    }

    // Update is called once per frame
    void Update()
    {
        switch(object_demon_states)
        {
            case demon_states.idle:
                object_demon_states = demon_states.prepare_direction;
                break;
            ///
            ///
            ///
            ///
            ///
            ///
            
            case demon_states.prepare_direction:
                raycast_hits = new RaycastHit[raycast_positions.Length];
                gameObject.transform.LookAt(new Vector3(player_transform.position.x,gameObject.transform.position.y,player_transform.position.z));

                for (int i = 0; i < raycast_positions.Length; i++)
                {
                    raycastHitsVectors[i] = raycast_positions[i].position - transform.position;//https://discussions.unity.com/t/how-to-raycast-always-in-direction-of-a-object/
                    Physics.Raycast(transform.position, raycastHitsVectors[i], out raycast_hits[i], 3f);
                }



                follow_transform = raycast_hits[Random.Range(0,raycast_positions.Length)].point;

                object_demon_states = demon_states.run;
                break;
            ///
            ///
            ///
            ///
            ///
            ///

            case demon_states.prepare_direction_non_raycast:

                demon_rb.velocity = Vector3.zero;
                gameObject.transform.LookAt(new Vector3(player_transform.position.x, gameObject.transform.position.y, player_transform.position.z));
                follow_transform = raycast_positions[Random.Range(0, raycast_positions.Length)].position;
                object_demon_states = demon_states.run;


                break;
                
                ///
            ///
            ///
            ///

            case demon_states.run:

                change_time_now += Time.deltaTime;
                
                
                if(change_time_now > change_time_max) 
                {
                    if (cycle > 3)
                    {
                        change_time_now = 0f;
                        object_demon_states = demon_states.fire;
                    }
                    change_time_now = 0f;
                    cycle++;
                    if(cycle == 0)
                    object_demon_run_states = demon_run_states.forward;
                    if(cycle == 1)
                    object_demon_run_states = demon_run_states.left;
                    if(cycle == 2)
                    object_demon_run_states = demon_run_states.right;
                }       
                
                
                gameObject.transform.LookAt(new Vector3(player_transform.position.x, gameObject.transform.position.y, player_transform.position.z));
                
                if(object_demon_run_states == demon_run_states.forward)
                demon_rb.velocity =  gameObject.transform.forward * speed *Time.deltaTime;
                
                if(object_demon_run_states == demon_run_states.left)
                demon_rb.velocity =  (gameObject.transform.forward * speed / 2 *Time.deltaTime) - (gameObject.transform.right * speed / 2 * Time.deltaTime);
                
                if(object_demon_run_states == demon_run_states.right)
                 demon_rb.velocity = (gameObject.transform.forward * speed / 2* Time.deltaTime) + (gameObject.transform.right * speed / 2 * Time.deltaTime);

                break;

            ///
            ///
            ///
            ///
            ///
            ///
            
            case demon_states.fire:
                demon_rb.velocity = Vector3.zero;
                demon_rb.constraints = RigidbodyConstraints.FreezePosition;
                cycle = 0;
                gameObject.transform.LookAt(new Vector3(player_transform.position.x, gameObject.transform.position.y, player_transform.position.z));
                fire_position.LookAt(player_transform);
                Debug.Log("FIRE!!");
                fire_time_now += Time.deltaTime;
                if (fire_time_now > fire_time_max)
                {
                    GameObject fire = Instantiate(demon_projectile, fire_position.position, fire_position.rotation);
                    if(fire.TryGetComponent<Rigidbody>(out Rigidbody fire_rb))
                    {
                        fire_rb.velocity = transform.forward * fire_speed * Time.deltaTime;
                    }
                    Destroy(fire, 6f);
                    demon_rb.constraints = RigidbodyConstraints.None;
                    demon_rb.constraints = RigidbodyConstraints.FreezeRotationX;
                    demon_rb.constraints = RigidbodyConstraints.FreezeRotationZ;

                    object_demon_states = demon_states.run;
                }
                    break;
        
        
        }    



    }


    public void die()
    {
        Destroy(gameObject);
    }

}
