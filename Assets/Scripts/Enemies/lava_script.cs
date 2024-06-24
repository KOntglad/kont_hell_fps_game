using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (other.gameObject.TryGetComponent<player_key_move>(out player_key_move player_))
            {
                player_.player_health.takeDamage(11);


            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if(collision.gameObject.TryGetComponent<player_key_move>(out player_key_move player_))
            {
                player_.player_health.takeDamage(11);


            }
        }
    }

}
