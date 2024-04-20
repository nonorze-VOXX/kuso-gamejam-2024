using System;
using UnityEngine;

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
                var condition = Input.GetKeyDown(KeyCode.Escape);
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
            popUpPanel.SetActive(false);
        }
        void OnPopShow()
        {
            popUpPanel.SetActive(true);
        }
    }
}