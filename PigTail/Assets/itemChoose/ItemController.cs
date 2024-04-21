using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace itemChoose
{
public class OpenPopPanel:IMessage
{
    
}
public class ClosePopPanel:IMessage
{
    
}
    public class ItemController : MonoBehaviour
    {
        private float timer=0;
        public float keepTime = 4;
        public GameObject popUpPanel;
        private void Start()
        {
            MessageCenter.RegisterMessage<OpenPopPanel>(OnPopShow);
            MessageCenter.RegisterMessage<ClosePopPanel>(OnPopClose);
            popUpPanel.SetActive(false);
            
        }
        public void ClickItem(BattleItem item)
        {
            MessageCenter.PostMessage<OpenPopPanel>();
        }

        private void Update()
        {
            if(popUpPanel.activeSelf)
            {
                timer+=Time.deltaTime;
                var condition = timer > keepTime;
                if (condition)
                {
                    MessageCenter.PostMessage<ClosePopPanel>();
                }
            }
        }

        private void OnDestroy()
        {
            MessageCenter.UnregisterMessage<OpenPopPanel>(OnPopShow);
            MessageCenter.UnregisterMessage<ClosePopPanel>(OnPopClose);
        }
        void OnPopClose()
        {
            Time.timeScale = 1;
            popUpPanel.SetActive(false);
        }
        void OnPopShow()
        {

            timer = 0;
            Time.timeScale = 0;
            popUpPanel.SetActive(true);
        }
    }
}