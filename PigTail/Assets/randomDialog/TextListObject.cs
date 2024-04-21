using System.Collections.Generic;
using UnityEngine;

namespace randomDialog
{
    [CreateAssetMenu(fileName = "textObj", menuName = "textObj", order = 0)]
    public class TextListObject : ScriptableObject
    {
        public List<string> textList = new List<string>();
    }
}