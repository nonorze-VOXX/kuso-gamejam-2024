using UnityEngine;

namespace showCommand
{
    [CreateAssetMenu(fileName = "commandImage", menuName = "CommandImage", order = 0)]
    public class CommandImageObject : ScriptableObject
    {
        public Sprite[] images;
    }
}