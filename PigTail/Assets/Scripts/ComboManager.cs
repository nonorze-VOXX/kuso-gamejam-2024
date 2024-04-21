using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using showCommand;
using itemChoose;
public class ComboManager : MonoBehaviour {
    [SerializeField]Skill[] skills;
    [SerializeField]float comboResetTime = 5;
    [SerializeField]CommandQueueShow commandQueueShow;
    [SerializeField]EventManager eventManager;
    string comboKeys = "";
    Queue<comboKey> comboKeysQueue = new Queue<comboKey>();

    int currentIndex;
    float currentTime;
    bool isKeying = false;
    private void Awake() {
        currentIndex = 0;
        
    }
    private void Start() {
        commandQueueShow.ShowCommand(comboKeysQueue.ToArray());
    }
    private void Update() {
        if(isKeying&&Time.time>=currentTime)
            OnResetSkillQueue();
    }
    public void OnKey(comboKey comboKey)
    {
        if(Time.timeScale == 0) return;
        Debug.Log("On key:"+comboKey);
        isKeying = true;
        currentTime = Time.time+comboResetTime;
        //Debug.Log(comboKey);
        comboKeys += comboKey;
        comboKeysQueue.Enqueue(comboKey);
        commandQueueShow.ShowCommand(comboKeysQueue.ToArray());
        CheckSkill();

    }

    private void CheckSkill()
    {
        foreach(var skill in skills){

            if (skill.GetComboKeyStr() == comboKeys)
            {
                
                OnSkillActivate(skill);
            }
        }
    }

    void OnResetSkillQueue(){
        //todo: reset skill
        comboKeysQueue.Clear();
        comboKeys = "";
        currentIndex = 0;
        isKeying = false;
        commandQueueShow.ShowCommand(comboKeysQueue.ToArray());
        Debug.Log("On reset skill");
    }
    void OnSkillActivate(Skill skill){
        
        MessageCenter.PostMessage<OpenPopPanel>(
            new OpenPopPanel(){
                OnClose =()=>{
                    eventManager.EventTrigger(skill.GetEff,skill.GetEffVal);
                },
                skill=skill
            });
        
        Debug.Log("activate skill:"+skill.name);
        OnResetSkillQueue();

    }
}