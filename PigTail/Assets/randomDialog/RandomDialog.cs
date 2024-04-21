using System;
using UnityEngine;
using UnityEngine.UI;

namespace randomDialog
{
    public class RandomDialog : MonoBehaviour
    {
        public TextListObject textListObject;
        public Text dialogBox;
        private float timer=0;
        public float timeBetweenDialog = 5;
        public float dialogShowTime = 5;
        
        private void Start()
        {
            dialogBox.gameObject.transform.parent.gameObject.SetActive(false);
            timer=0;
        }

        private void Update()
        {
            if(dialogBox.gameObject.transform.parent.gameObject.activeSelf)
            {
                timer+=Time.deltaTime;
                if (timer > dialogShowTime)
                {
                    dialogBox.gameObject.transform.parent.gameObject.SetActive(false);
                    timer = 0;
                }
            }
            else
            {
                timer+=Time.deltaTime;
                if (timer > timeBetweenDialog)
                {
                    dialogBox.gameObject.transform.parent.gameObject.SetActive(true);
                    dialogBox.text = textListObject.textList[UnityEngine.Random.Range(0, textListObject.textList.Count)];
                    timer = 0;
                }
            }
        }
        public void InteruptDialog(string newText)
        {
            dialogBox.gameObject.transform.parent.gameObject.SetActive(true);
            dialogBox.text = newText;
            timer = 0;
        }
    }
}