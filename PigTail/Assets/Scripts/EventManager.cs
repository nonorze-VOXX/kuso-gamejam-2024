using System;
using System.Collections;
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
    public void EventTrigger(Effect effect, float value)
    {
        switch (effect)
        {
            case Effect.Recover:
                Recover(value);
                break;
            case Effect.Giveup:
                Giveup(value);
                break;
            case Effect.Powerup:
                Powerup(value);
                break;
            case Effect.Tilt:
                Tilt(value);
                break;
        }
    }

    public void Recover(float value)
    {
        StartCoroutine(RecoverCoroutine(value));
    }

    IEnumerator RecoverCoroutine(float value)
    {
        yield return new WaitForSeconds(4);
    }

    public void Giveup(float value)
    {
        StartCoroutine(GiveupCoroutine(value));
    }

    IEnumerator GiveupCoroutine(float value)
    {
        yield return new WaitForSeconds(1);
    }

    public void Powerup(float value)
    {
        StartCoroutine(PowerupCoroutine(value));
    }

    IEnumerator PowerupCoroutine(float value)
    {
        yield return new WaitForSeconds(0);
    }

    [Header("Tilt Event")]
    [SerializeField]
    private GameObject barGO;

    public void Tilt(float value)
    {
        StartCoroutine(TiltCoroutine(value));
    }

    IEnumerator TiltCoroutine(float value)
    {
        //Start
        barGO.transform.localPosition -= new Vector3(0, 150, 0);
        barGO.transform.rotation = Quaternion.Euler(0, 0, 45);

        yield return new WaitForSeconds(4);

        //End
        barGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        barGO.transform.localPosition += new Vector3(0, 150, 0);
    }
}
