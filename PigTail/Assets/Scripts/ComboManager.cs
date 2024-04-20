using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ComboManager : MonoBehaviour {
    [SerializeField]Skill currentSkill;
    
    int currentIndex;
    private void Awake() {
        currentIndex = 0;
        
    }
    private void Start() {
    }
    public void OnKey(comboKey comboKey){
        Debug.Log(comboKey);
        if(currentIndex>currentSkill.GetComboKeys.Length )
            Debug.Log("ComoboKey out of range");
        if(currentSkill.GetComboKeys[currentIndex] == comboKey){
            currentIndex++;
            if(currentIndex>=currentSkill.GetComboKeys.Length){
                OnSkillActivate();
            }
            
        }
        else{
            currentIndex = 0;
            OnSkillWrong();
        }
    }
    void OnSkillWrong(){
        //todo: reset skill
    }
    void OnSkillActivate(){
        currentIndex = 0;
        //todo: on skill activate
        Debug.Log("On skill!!!!!");

    }
}