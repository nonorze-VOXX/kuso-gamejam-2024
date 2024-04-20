using System;
using UnityEngine;
using UnityEngine.UI;

namespace showCommand
{
    public class CommandQueueShow : MonoBehaviour
    {
        public GameObject[] commandImages;
        public CommandImageObject commandImageObject;

        private void Start()
        {
            ShowCommand(new [] { comboKey.up , comboKey.down, comboKey.left});
        }

        public void ShowCommand(comboKey[] keys){
            for(int i = 0; i < 4; i++){
                if (i < keys.Length)
                {
                commandImages[i].SetActive(true);
                commandImages[i].GetComponent<Image>().sprite = commandImageObject.images[(int)keys[i]];
                }
                else
                {
                commandImages[i].SetActive(false);
                }
                
            }
        }
    }
}