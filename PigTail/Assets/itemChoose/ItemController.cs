using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace itemChoose
{
public class OpenPopPanel:IMessageWithData
{
    public Action OnClose;
    public Skill skill;
}
public class ClosePopPanel:IMessage
{
    
}
    public class ItemController : MonoBehaviour
    {
        private float timer=0;
        public float keepTime = 4;
        public GameObject popUpPanel;
        Action tmpAction;
        private void Start()
        {
            MessageCenter.RegisterMessage<OpenPopPanel>(OnPopShow);
            MessageCenter.RegisterMessage<ClosePopPanel>(OnPopClose);
            popUpPanel.SetActive(false);
            
        }
        public void ClickItem(BattleItem item)
        {
            MessageCenter.PostMessage<OpenPopPanel>(new OpenPopPanel(){});
        }

        private void Update()
        {
            if(popUpPanel.activeSelf)
            {
                timer+=Time.unscaledDeltaTime;
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
            if(tmpAnimation!=null)
                Destroy(tmpAnimation);
            if (tmpIcon!=null)
                Destroy(tmpIcon);
            if(tmpAction!=null)
                tmpAction();
        }
        GameObject tmpIcon;
        GameObject tmpAnimation;
        void OnPopShow(OpenPopPanel msg)
        {
            tmpIcon = Instantiate(msg.skill.SkillIcon,popUpPanel.transform.GetChild(1).transform);
            
            tmpAnimation = Instantiate(msg.skill.SkillAnimation, popUpPanel.transform.GetChild(0).transform);

            popUpPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = msg.skill.Text;
                
            tmpAction = msg.OnClose;
            timer = 0;
            Time.timeScale = 0;
            popUpPanel.SetActive(true);
        }

    }
}