using UnityEngine;

namespace itemChoose
{
    [CreateAssetMenu(fileName = "popUpContext", menuName = "PopupContext", order = 0)]
    public class PopUpContext : ScriptableObject
    {
        public GameObject sprite;
        public GameObject icon;
        public string text;
        
    }
}