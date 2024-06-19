using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class health : MonoBehaviour
{
    public int max_health, now_health;
    public UnityEvent health_event;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) 
    {
        now_health -= damage;
        if(now_health < 0) 
        {
            health_event.Invoke();
        }
    
    
    }

}
