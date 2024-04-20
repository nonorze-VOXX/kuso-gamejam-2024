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
    void Start()
    {
        MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
        if(TestStart)
            MessageCenter.PostMessage<GameStartMessage>();
    }
    private void OnDestroy() {
        MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
    }
    void OnGameStart(){
        isStart = true;
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
        float speed = Mathf.Abs(p1.GetForce() - p2.GetForce()) * totalSpeed;
        if (p1.GetForce() > p2.GetForce())
        {
            parentObj.transform.position = originPos + Vector2.right * Time.deltaTime * speed;
        }
        else if (p1.GetForce() < p2.GetForce())
        {
            parentObj.transform.position = originPos + Vector2.left * Time.deltaTime * speed;
        }
        else
        {
            parentObj.transform.position = Vector3.Lerp(originPos, Vector3.zero, Time.deltaTime);
        }
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
