using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ComboManager : MonoBehaviour {
    [SerializeField]Skill[] skills;
    [SerializeField]float comboResetTime = 5;
    string comboKeys = "";
    Queue<comboKey> comboKeysQueue = new Queue<comboKey>();
    int currentIndex;
    float currentTime;
    bool isKeying = false;
    private void Awake() {
        currentIndex = 0;
        
    }
    private void Start() {
    }
    private void Update() {
        if(isKeying&&Time.time>=currentTime)
            OnResetSkillQueue();
    }
    public void OnKey(comboKey comboKey)
    {
        isKeying = true;
        currentTime = Time.time+comboResetTime;
        Debug.Log(comboKey);
        comboKeys += comboKey;
        comboKeysQueue.Enqueue(comboKey);
        CheckSkill();

    }

    private void CheckSkill()
    {
        foreach(var skill in skills){

            if (skill.GetComboKeys() == comboKeys)
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
        Debug.Log("On reset skill");
    }
    void OnSkillActivate(Skill skill){
        //todo: on skill activate
        Debug.Log("activate skill:"+skill.name);
        OnResetSkillQueue();

    }
}