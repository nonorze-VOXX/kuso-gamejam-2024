using randomDialog;
using UnityEngine;

public class BotSkillController : MonoBehaviour {
    [SerializeField] EventManager eventManager;
    [SerializeField] Skill[] skills;
    [SerializeField] float ranTimeoutMin,ranTimeoutMax;
    
    public RandomDialog randomDialog;
    bool isStart;
    public float timeout = 0;
    private void Awake() {
        MessageCenter.RegisterMessage<GameStartMessage>(OnStart);
        MessageCenter.RegisterMessage<GameEndMessage>(OnGameEnd);
        
    }
    private void OnDestroy() {
        MessageCenter.UnregisterMessage<GameStartMessage>(OnStart);
        MessageCenter.UnregisterMessage<GameEndMessage>(OnGameEnd);
    }
    private void Start() {
        OnStart();
    }
    void OnStart()
    {
        isStart = true;
        RanTime();
    }
    void OnGameEnd(){
        isStart = false;
    }

    private void RanTime()
    {
        timeout = Time.time + Random.Range(ranTimeoutMin, ranTimeoutMax);
    }

    private void Update() {
        if(isStart && Time.timeScale!=0 && Time.time >= timeout)
        {
            var skill = skills[Random.Range(0, skills.Length)];
            randomDialog.InteruptDialog($"<b><color='red'>{skill.Text2}</color></b>");
            OnSkillActivate(skill);
        }
    }
    void OnSkillActivate(Skill skill){
        eventManager.EventTrigger(skill.GetEff,skill.GetEffVal);
        Debug.Log("on bot skill");
        RanTime();
    }
}