using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class ComboManager : MonoBehaviour {
    [SerializeField]Skill currentSkill;
    Queue<comboKey> comboKeys = new Queue<comboKey>();
    int currentIndex;
    private void Awake() {
        currentIndex = 0;
        
    }
    private void Start() {
    }
    public void OnKey(comboKey comboKey){
        
        comboKeys.Enqueue(comboKey);
        Debug.Log(comboKey);
    }
}