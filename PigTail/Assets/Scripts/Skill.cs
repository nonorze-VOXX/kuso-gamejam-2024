using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
public class Skill : ScriptableObject {
    [SerializeField]comboKey[] comboKeys;
    public comboKey[] GetComboKeys => comboKeys;
    
}
