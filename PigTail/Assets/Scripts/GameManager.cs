using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PigController p1;
    public PigController p2;
    public GameObject parentObj;
    public float totalSpeed = 2;
    bool isStart = false;
    [SerializeField]bool TestStart = false;
    
    public Transform endL,endR;
    // Start is called before the first frame update
    private void Awake() {
        MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
        MessageCenter.RegisterMessage<GameEndMessage>(OnGameEnd);
        
    }
    void Start()
    {
        if(TestStart)
            MessageCenter.PostMessage<GameStartMessage>();
    }
    private void OnDestroy() {
        MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
        MessageCenter.UnregisterMessage<GameEndMessage>(OnGameEnd);
    }
    void OnGameStart(){
        isStart = true;
    }
    void OnGameEnd(){
        isStart = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isStart)
        {
            OnUpdatePigsPos();
        }

    }

    private void OnUpdatePigsPos()
    {
        Vector2 originPos = parentObj.transform.position;
        float speed = (p1.GetForce() - p2.GetForce()) * totalSpeed;
        
        parentObj.transform.position = originPos + Vector2.right * Time.deltaTime * speed;
        
        
        float currPos =parentObj.transform.position.x; 
        if(currPos<endL.position.x ){
            //todo: left win
            Debug.Log("Left win");
        }
        if(currPos>endR.position.x){
            //todo: right win
            Debug.Log("Right win");

        }
    }
}
