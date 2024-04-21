using System;
using System.Collections;
using choose;
using UnityEngine;
using UnityEngine.UI;

public class PigController : MonoBehaviour
{
    public ChoosedPig choosedPig;

    [SerializeField]
    Image barBackground;

    [SerializeField]
    Image bar;

    [SerializeField]
    LevelSettings levelSettings;
    [SerializeField]
    PigController otherPig;
    float minForce,maxForce,tiredDecreaceSpeed;
    float tiredNum = 100;
    float currTiredNum = 0;
    bool isStart = false;
    bool isChangeingTired = false;

    private void Awake()
    {
        MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
        MessageCenter.RegisterMessage<GameEndMessage>(OnGameEnd);
        currTiredNum = tiredNum;
        minForce =  choosedPig.minForce;
        maxForce =  choosedPig.maxForce;
        tiredDecreaceSpeed = choosedPig.tiredDecreaceSpeed;
    }

    void Start() { }

    private void OnDestroy()
    {
        MessageCenter.UnregisterMessage<GameStartMessage>(OnGameStart);
        MessageCenter.UnregisterMessage<GameEndMessage>(OnGameEnd);
    }

    void OnGameEnd()
    {
        isStart = false;
    }

    void OnGameStart()
    {
        isStart = true;
    }

    private void Update()
    {
        if (isStart && !isChangeingTired)
        {
            currTiredNum = Mathf.Max(
                0,
                currTiredNum - tiredDecreaceSpeed * Time.deltaTime
            );
            bar.fillAmount  = currTiredNum / tiredNum;
        }
    }

    public float GetForce()
    {
        float tiredSpeed = (currTiredNum / tiredNum) * levelSettings.TiredForceMod;
        return UnityEngine.Random.Range(
            minForce + tiredSpeed,
            maxForce + tiredSpeed
        );
    }

    public void ChangeFill(float targetAmount)
    {
        StartCoroutine(ChangeFillAmountCoroutine(targetAmount));
    }

    private IEnumerator ChangeFillAmountCoroutine(float targetAmount)
    {
        float elapsedTime = 0.0f;
        float startFillAmount = bar.fillAmount;
        float currentFillAmount;
        float fillSpeed = 0.1f;
        isChangeingTired = true;
        while (elapsedTime < fillSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fillSpeed);
            currentFillAmount = Mathf.Lerp(startFillAmount, targetAmount, t);
            bar.fillAmount = currentFillAmount;
            yield return null;
        }

        // Ensure final value is exactly what we want
        bar.fillAmount = targetAmount;
        elapsedTime = 0.0f;

        while (elapsedTime < fillSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fillSpeed);
            currentFillAmount = Mathf.Lerp(startFillAmount, targetAmount, t);
            barBackground.fillAmount = currentFillAmount;
            yield return null;
        }

        // Ensure final value is exactly what we want
        barBackground.fillAmount = targetAmount;
        isChangeingTired = false;
    }

    public void OnRecover(float val)
    {
        Debug.Log("on heal");
        currTiredNum += val;
        ChangeFill(currTiredNum / tiredNum);
    }

    public void OnRecoverEnd() { 

    }
    public void OnPowerLess(float val){
        powerlessForce = val;
        maxForce -= powerlessForce;
        minForce -= powerlessForce;
    }
    public void OnPowerLessEnd(){
        maxForce += powerlessForce;
        minForce += powerlessForce;
    }   
    public void OnGiveup(float val) { 
        otherPig.OnPowerLess(val);
    }

    public void OnGiveupEnd() { 
        otherPig.OnPowerLessEnd();
    }
    
    float powerupForce = 0;
    float powerlessForce = 0;
    public void OnPowerup(float val) { 
        powerupForce = val;
        maxForce += powerupForce;
        minForce += powerupForce;
    }

    public void OnPowerupEnd() { 
        maxForce -= powerupForce;
        minForce -= powerupForce;
        
    }

    public void OnTilt(float val) { 
        tiredDecreaceSpeed = val;
    }

    public void OnTiltEnd() { 
        tiredDecreaceSpeed = choosedPig.tiredDecreaceSpeed;
    }
}
