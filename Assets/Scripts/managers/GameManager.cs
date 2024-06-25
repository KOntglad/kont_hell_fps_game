using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public interface_manager game_ui_manager;
    public Animator panel_player_g_over;

    public void win() 
    {

        game_ui_manager.windows[0].SetActive(true);
        Time.timeScale = 0f;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void lose()
    {
        game_ui_manager.UI_texts[3].text = "YOU LOSE";
        Time.timeScale = 0f;
        game_ui_manager.windows[0].SetActive(true);
        panel_player_g_over.SetTrigger("lose");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8) 
        {
            win();   
        }
    }

}
