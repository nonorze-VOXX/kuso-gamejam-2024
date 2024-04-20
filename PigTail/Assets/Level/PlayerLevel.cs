using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "playerLevel", menuName = "playerLevel", order = 0)]
    public class PlayerLevel : ScriptableObject
    {
        public int level;
    }
}