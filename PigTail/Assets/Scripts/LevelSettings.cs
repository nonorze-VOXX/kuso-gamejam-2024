using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings", order = 0)]
public class LevelSettings : ScriptableObject 
{
    public float TiredForceMod;
}