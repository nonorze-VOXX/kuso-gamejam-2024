// using System;
using System.Collections;
using System.Collections.Generic;
using choose;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseController : MonoBehaviour
{
    public ChoosedPig choosedPig;
    private GameObject pig1;
    private GameObject pig2;
    private GameObject pig3;
    private Button pig1Button;
    private Button pig2Button;
    private Button pig3Button;
    
        

    private void Start()
    {
        pig1 = GameObject.Find("Pig1");
        pig2 = GameObject.Find("Pig2");
        pig3 = GameObject.Find("Pig3");
        pig1Button = pig1.GetComponent<Button>();
        pig2Button = pig2.GetComponent<Button>();
        pig3Button = pig3.GetComponent<Button>();
        switch (choosedPig.pigType)
        {
            case PigType.Pig1:
                pig1Button.Select();
                break;
            case PigType.Pig2:
                pig2Button.Select();
                break;
            case PigType.Pig3:
                pig3Button.Select();
                break;
        }
    }


    public void ChoosePig1()
    {
        choosedPig.pigType = PigType.Pig1;
    }
    
    public void ChoosePig2()
    {
        choosedPig.pigType = PigType.Pig2;
    }
    
    public void ChoosePig3()
    {
        choosedPig.pigType = PigType.Pig3;
    }
    public void TrangeToGame()
    {
        SceneManager.LoadScene("gameplay");
    }

    private void Update()
    {
    }

}
