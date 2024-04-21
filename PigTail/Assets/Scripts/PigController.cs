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

    float tiredNum = 100;
    float currTiredNum = 0;
    bool isStart = false;
    bool isChangeingTired = false;
    private void Awake()
    {
        MessageCenter.RegisterMessage<GameStartMessage>(OnGameStart);
        MessageCenter.RegisterMessage<GameEndMessage>(OnGameEnd);
        currTiredNum = tiredNum;
    }

    void Start()
    {
    }

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
            //ChangeFill(currTiredNum / tiredNum);
            currTiredNum = Mathf.Max(
                0,
                currTiredNum - choosedPig.tiredDecreaceSpeed * Time.deltaTime
            );
        }
    }

    public float GetForce()
    {
        float tiredSpeed = (currTiredNum / tiredNum) * levelSettings.TiredForceMod;
        return UnityEngine.Random.Range(
            choosedPig.minForce + tiredSpeed,
            choosedPig.maxForce + tiredSpeed
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
    public void OnRecover(float val){
        Debug.Log("on heal");
        currTiredNum += val;
        ChangeFill(currTiredNum / tiredNum);

    }
    public void OnGiveup(float val){


    }
    public void OnPowerup(float val){


    }
    public void OnTilt(float val){


    }
}
