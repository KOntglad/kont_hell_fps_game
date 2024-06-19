using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imp_slot_manager : MonoBehaviour
{
    public GameObject[] imps;
    public GameObject temp_imp;
    public GameObject player;

    public float max_distance_the_player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void decideEvade() 
    {
        foreach(GameObject imp in imps) 
        { 
            if(max_distance_the_player < Vector3.Distance(imp.transform.position, player.transform.position)) 
            {
                max_distance_the_player = Vector3.Distance(imp.transform.position, player.transform.position);
                temp_imp = imp;

            }

        }

        temp_imp.TryGetComponent<enemy_imp>(out enemy_imp imp_entity);
        if (imp_entity != null)
            imp_entity.changeDirection();
    }


}
