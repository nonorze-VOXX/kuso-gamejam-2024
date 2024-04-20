using UnityEngine;

namespace choose
{
    public enum PigType
    {
        Pig1,
        Pig2,
        Pig3
    }
    [CreateAssetMenu(fileName = "choosedPig", menuName = "pig/choosedPig", order = 0)]
    public class ChoosedPig : ScriptableObject
    {
        public PigType pigType;
    }
}