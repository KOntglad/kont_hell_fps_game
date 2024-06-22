using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_manager_pro : MonoBehaviour
{

    public interface_manager UI_manager;

    public float time;
    
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open() 
    {
        UI_manager.OpenWindow(0);
        Invoke("close", 3);
    
    }

    public void close() 
    {
        UI_manager.CloseWindow(0);
    
    
    }



}
