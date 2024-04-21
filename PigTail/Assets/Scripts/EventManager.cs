using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private PigController pig;

    private void Update() { }

    /// <summary>
    /// Recover: 體力增加
    /// Giveup: 對方體力歸零
    /// Powerup; 力氣增加
    /// Tilt: 體力下降加速
    /// /// </summary>
    /// <param name="effect"></param>
    /// <param name="startAction"></param>
    /// <param name="endAction"></param> <summary>
    ///
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="startAction"></param>
    /// <param name="endAction"></param>
    public void EventTrigger(Effect effect, float value, Action endAction = null)
    {
        switch (effect)
        {
            case Effect.Recover:
                Recover(value, endAction);
                break;
            case Effect.Giveup:
                Giveup(value, endAction);
                break;
            case Effect.Powerup:
                Powerup(value, endAction);
                break;
            case Effect.Tilt:
                Tilt(value, endAction);
                break;
        }
    }

    public void Recover(float value, Action endAction)
    {
        StartCoroutine(RecoverCoroutine(value, endAction));
    }

    IEnumerator RecoverCoroutine(float value, Action endAction)
    {
        pig.OnRecover(value);

        yield return new WaitForSeconds(4);

        pig.OnRecoverEnd();
        endAction?.Invoke();
    }

    public void Giveup(float value, Action endAction)
    {
        StartCoroutine(GiveupCoroutine(value, endAction));
    }

    IEnumerator GiveupCoroutine(float value, Action endAction)
    {
        pig.OnGiveup(value);

        yield return new WaitForSeconds(1);

        pig.OnGiveupEnd();
        endAction?.Invoke();
    }

    public void Powerup(float value, Action endAction)
    {
        StartCoroutine(PowerupCoroutine(value, endAction));
    }

    IEnumerator PowerupCoroutine(float value, Action endAction)
    {
        pig.OnPowerup(value);

        yield return new WaitForSeconds(0);

        pig.OnPowerupEnd();
        endAction?.Invoke();
    }

    [Header("Tilt Event")]
    [SerializeField]
    private GameObject barGO;

    public void Tilt(float value, Action endAction)
    {
        StartCoroutine(TiltCoroutine(value, endAction));
    }

    IEnumerator TiltCoroutine(float value, Action endAction)
    {
        //Start
        barGO.transform.localPosition -= new Vector3(0, 150, 0);
        barGO.transform.rotation = Quaternion.Euler(0, 0, -45);
        pig.OnTilt(value);

        yield return new WaitForSeconds(4);

        //End
        barGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        barGO.transform.localPosition += new Vector3(0, 150, 0);
        pig.OnTiltEnd();
        endAction?.Invoke();
    }
}
