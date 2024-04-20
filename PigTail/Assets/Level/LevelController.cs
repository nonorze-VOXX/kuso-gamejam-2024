using choose;
using UnityEngine;

namespace Level
{
    public class LevelController:MonoBehaviour
    {
        public PlayerLevel playerLevel;

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
             cp.pigType= PigType.Pig1;
             cp.maxForce = 0;
             cp.minForce = 1 ;
             cp.tiredDecreaceSpeed = 2;
             return cp;
        }
    }
}