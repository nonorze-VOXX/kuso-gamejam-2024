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
            //todo ballance level data
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
            
             var cp = playerLevel.enemyPigs[playerLevel.level % playerLevel.enemyPigs.Count];
             cp.pigType= PigType.Pig1;
             cp.maxForce   *=((int)playerLevel.level / levelData.Count+1);
             cp.minForce   *=((int)playerLevel.level / levelData.Count+1);
             cp.tiredDecreaceSpeed   *=((int)playerLevel.level / levelData.Count+1);
             return cp;
        }
    }
}