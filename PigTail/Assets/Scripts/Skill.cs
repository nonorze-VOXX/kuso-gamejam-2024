using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
public class Skill : ScriptableObject
{
    [SerializeField]
    comboKey[] comboKeys;

    [SerializeField]
    Effect effect;
    [SerializeField]
    float effectVal;
    [SerializeField]
    [TextAreaAttribute]
    string text;
    [SerializeField]
    GameObject skillIcon;
    [SerializeField]
    GameObject skillAnimation;
    public GameObject SkillIcon => skillIcon;
    public GameObject SkillAnimation => skillAnimation;
    public string Text => text;
    public string GetComboKeyStr()
    {
        string result = "";
        foreach (var key in comboKeys)
        {
            result += key;
        }
        return result;
    }
    public comboKey[] GetComboKeys(){
        return comboKeys;
    }
    public Effect GetEff=>effect;
    public float GetEffVal=>effectVal;
}

public enum Effect
{
    None,
    Recover,
    Powerup,
    Giveup,
    Tilt,
}
