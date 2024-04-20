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
    private Image pig1Image;
    private Image pig2Image;
    private Image pig3Image;
    
        

    private void Start()
    {
        pig1 = GameObject.Find("Pig1");
        pig2 = GameObject.Find("Pig2");
        pig3 = GameObject.Find("Pig3");
        pig1Image = pig1.GetComponent<Image>();
        pig2Image = pig2.GetComponent<Image>();
        pig3Image = pig3.GetComponent<Image>();
        
        UpdateChooseColor();
    }

    private void UpdateChooseColor()
    {
        switch (choosedPig.pigType)
        {
            case PigType.Pig1:
                pig1Image.color = new Color(1f, 1f, 1f, 1f);
                pig2Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                pig3Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                break;
            case PigType.Pig2:
                pig1Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                pig2Image.color = new Color(1f, 1f, 1f, 1f);
                pig3Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                break;
            case PigType.Pig3:
                pig1Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                pig2Image.color = new Color(0.7f, 0.7f, 0.7f, 1f);
                pig3Image.color = new Color(1f, 1f, 1f, 1f);
                break;
        }
    }


    public void ChoosePig1()
    {
        choosedPig.pigType = PigType.Pig1;
        UpdateChooseColor();
        
    }
    
    public void ChoosePig2()
    {
        choosedPig.pigType = PigType.Pig2;
        UpdateChooseColor();
    }
    
    public void ChoosePig3()
    {
        choosedPig.pigType = PigType.Pig3;
        UpdateChooseColor();
    }
    public void TrangeToGame()
    {
        SceneManager.LoadScene("gameplay");
    }

    private void Update()
    {
    }

}
