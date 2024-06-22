using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interface_manager : MonoBehaviour
{
    public TMP_Text[] UI_texts;
    public GameObject[] windows;
    public GameObject[] buttons;

    public void printText(int text_no,string text)
    {

        UI_texts[text_no].text = text;
    
    }

    public void OpenWindow(int window_no)
    {
        if (windows[window_no].activeSelf == false)
        {
            windows[window_no].SetActive(true);


        }
    
    }

    public void CloseWindow(int window_no)
    {
        if (windows[window_no].activeSelf != false)
        {
            windows[window_no].SetActive(false);

        }

    }

    public void OpenButton(int button_no) 
    {
        if (buttons[button_no].activeSelf == false)
        {
            buttons[button_no].SetActive(true);

        }


    }

    public void CloseButton(int button_no)
    {
        if (buttons[button_no].activeSelf != false)
        {
            buttons[button_no].SetActive(false);

        }


    }


}
