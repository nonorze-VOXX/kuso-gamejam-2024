using System;

using UnityEngine;
using UnityEngine.UI;


public class PigController: MonoBehaviour
    {
        [SerializeField] float maxForce = 0;
        [SerializeField] float minForce = 0;
        [SerializeField] float tiredDecreaceSpeed = 1;
        [SerializeField] Slider tiedBar;
        [SerializeField] LevelSettings levelSettings;

        float tiredNum = 100;
        float currTiredNum = 0;
        bool isStart = false;
        private void Awake() {
            MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
            currTiredNum = tiredNum;
            tiedBar.value = 1;
            
        }
        void Start()
        {
        }
        private void OnDestroy() {
            MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
        }
        void OnGameStart(){
            isStart = true;
        }
        private void Update() {
            tiedBar.value = currTiredNum/tiredNum;
            if(isStart){
                currTiredNum = Mathf.Max(0,currTiredNum - tiredDecreaceSpeed * Time.deltaTime);
                
            }
        }
        public float GetForce(){
            float tiredSpeed = (currTiredNum/tiredNum)*levelSettings.TiredForceMod;
            return UnityEngine.Random.Range(minForce+tiredSpeed ,maxForce+tiredSpeed);
        }
        
    }
