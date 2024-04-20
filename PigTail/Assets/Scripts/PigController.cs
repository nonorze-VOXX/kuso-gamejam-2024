using System;

using UnityEngine;


    public class PigController: MonoBehaviour
    {
        //[SerializeField] Rigidbody2D rigidbody;
        [SerializeField] float maxForce = 0;
        [SerializeField] float minForce = 0;
        [SerializeField] float tiredDecreaceSpeed = 1;
        [SerializeField] float tiredDecreaceMod = 0.01f;
        float tiredNum = 100;
        float currTiredNum = 0;
        bool isStart = false;
        void Start()
        {
            MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);

        }
        private void OnDestroy() {
            MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
        }
        void OnGameStart(){
            currTiredNum = tiredNum;
        }
        private void Update() {
            if(isStart){
                currTiredNum = Mathf.Min(0,currTiredNum - tiredDecreaceSpeed * Time.deltaTime);
            }
        }
        public float GetForce(){
            return UnityEngine.Random.Range(minForce+currTiredNum*tiredDecreaceMod ,maxForce+currTiredNum*tiredDecreaceMod );
        }
        
    }
