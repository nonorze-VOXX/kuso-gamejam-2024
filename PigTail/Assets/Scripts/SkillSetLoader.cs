using showCommand;
using UnityEngine;

public class SkillSetLoader : MonoBehaviour {
    [SerializeField]CommandQueueShow commandQueueShow;
    [SerializeField]Skill skill;

    private void Start() {
        
        commandQueueShow.ShowCommand(skill.GetComboKeys());
    }
    
}