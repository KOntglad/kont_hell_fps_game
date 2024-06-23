using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imp_slot_manager : MonoBehaviour
{
    public GameObject[] imps;
    public GameObject temp_imp;
    public GameObject player;

    public float max_distance_the_player;

    public float decide_time_now;
    public float decide_time_max;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        decide_time_now += Time.deltaTime;
        
        if(decide_time_now > decide_time_max) 
        {
            decide_time_now = 0f;
            decideTripleEvade();
        }
    }


    void decideTripleEvade()
    {
        int i = 0;
        foreach (GameObject imp in imps)
        {
            if (i < 2)
            {
                if (imp.TryGetComponent<enemy_imp>(out enemy_imp imp_entity))
                {
                    imp_entity.direction_transform = player.transform.position;
                    imp_entity.speed_mul = 1f;
                    imp_entity.game_imp_states = enemy_imp.imp_states.prepare;
                }
                i++;
            }
            else 
            {
                break;
            }
        }

       
    }


    void decideEvade() 
    {
        foreach(GameObject imp in imps) 
        {
            float distance_objs = Vector3.Distance(imp.transform.position, player.transform.position);
            if (max_distance_the_player > distance_objs) 
            {
                max_distance_the_player = distance_objs;
                temp_imp = imp;

            }

        }

        temp_imp.TryGetComponent<enemy_imp>(out enemy_imp imp_entity);
        if (imp_entity != null)
            imp_entity.game_imp_states = enemy_imp.imp_states.prepare;


        max_distance_the_player = 60f; 
    }
    void decideDash() 
    {
        int i = 0;
        foreach (GameObject imp in imps)
        {
            if (i < 2)
            {
                if (imp.TryGetComponent<enemy_imp>(out enemy_imp imp_entity))
                {
                    imp_entity.direction_transform = player.transform.position;
                    imp_entity.speed_mul = 3f;
                    imp_entity.game_imp_states = enemy_imp.imp_states.prepare;
                    i++;
                }
            }
            else
            {
                break;
            }
        }

    }

}
