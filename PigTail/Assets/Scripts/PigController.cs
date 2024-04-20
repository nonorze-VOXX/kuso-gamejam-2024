using System;
using choose;
using UnityEngine;
using UnityEngine.UI;


public class PigController: MonoBehaviour
{
    public ChoosedPig choosedPig;
        [SerializeField] Slider tiedBar;
        [SerializeField] LevelSettings levelSettings;

        float tiredNum = 100;
        float currTiredNum = 0;
        bool isStart = false;
        private void Awake() {
            MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
            MessageCenter.RegisterMessage<GameEndMessage>(OnGameEnd);
            currTiredNum = tiredNum;
            tiedBar.value = 1;
            
        }
        void Start()
        {
        }
        private void OnDestroy() {
            MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
            MessageCenter.UnregisterMessage<GameEndMessage>(OnGameEnd);
        }
        void OnGameEnd(){
            isStart = false;
        }
        void OnGameStart(){
            isStart = true;
        }
        private void Update() {
            if(isStart){
                tiedBar.value = currTiredNum/tiredNum;
                currTiredNum = Mathf.Max(0,currTiredNum - choosedPig.tiredDecreaceSpeed * Time.deltaTime);
                
            }
        }
        public float GetForce(){
            float tiredSpeed = (currTiredNum/tiredNum)*levelSettings.TiredForceMod;
            return UnityEngine.Random.Range(choosedPig.minForce+tiredSpeed ,choosedPig.maxForce+tiredSpeed);
        }
        
    }
