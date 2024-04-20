using System;
using System.Collections.Generic;
using choose;
using UnityEngine;

namespace Level
{
    public class LevelController:MonoBehaviour
    {
        public PlayerLevel playerLevel;
        public List<List<float>> levelData;

        private void Awake()
        {
            levelData = new List<List<float>>()
            {
                new List<float>(){10,5,1},
                new List<float>(){20,10,2},
                new List<float>(){30,10,3},
                new List<float>(){40,20,4},
                new List<float>(){50,20,5},
            };
        }

        void Win()
        {
            playerLevel.level++;
        }

        void Lose()
        {
            playerLevel.level = 0;
        }

        public ChoosedPig GetNowLevelPig()
        {
             var cp = ScriptableObject.CreateInstance<ChoosedPig>();
             var data=levelData[playerLevel.level % levelData.Count];
             cp.pigType= PigType.Pig1;
             cp.maxForce = data[0] *((float)playerLevel.level / levelData.Count);
             cp.minForce = data[1] *((float)playerLevel.level / levelData.Count);
             cp.tiredDecreaceSpeed = data[2] *((float)playerLevel.level / levelData.Count);
             return cp;
        }
    }
}