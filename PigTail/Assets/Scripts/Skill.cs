using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
public class Skill : ScriptableObject {
    
    [SerializeField]comboKey[] comboKeys;
    public string GetComboKeys() {
        string result = "";
        foreach(var key in comboKeys){
            result+=key;
        }
        return result;
    }
    
}
