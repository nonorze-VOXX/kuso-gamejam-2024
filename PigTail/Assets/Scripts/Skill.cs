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

    public string GetComboKeys()
    {
        string result = "";
        foreach (var key in comboKeys)
        {
            result += key;
        }
        return result;
    }
    public Effect GetEff=>effect;
}

public enum Effect
{
    None,
    Recover,
    Powerup,
    Giveup,
    Tilt,
}
