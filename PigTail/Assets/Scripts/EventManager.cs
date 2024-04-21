using System;
using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private PigController player;

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
    public void EventTrigger(Effect effect, Action startAction, Action endAction)
    {
        switch (effect)
        {
            case Effect.Recover:
                Recover(startAction, endAction);
                break;
            case Effect.Giveup:
                Giveup(startAction, endAction);
                break;
            case Effect.Powerup:
                Powerup(startAction, endAction);
                break;
            case Effect.Tilt:
                Tilt(startAction, endAction);
                break;
        }
    }

    public void Recover(Action startAction, Action endAction)
    {
        StartCoroutine(RecoverCoroutine(startAction, endAction));
    }

    IEnumerator RecoverCoroutine(Action startAction, Action endAction)
    {
        startAction?.Invoke();

        yield return new WaitForSeconds(4);

        endAction?.Invoke();
    }

    public void Giveup(Action startAction, Action endAction)
    {
        StartCoroutine(GiveupCoroutine(startAction, endAction));
    }

    IEnumerator GiveupCoroutine(Action startAction, Action endAction)
    {
        startAction?.Invoke();

        yield return new WaitForSeconds(1);

        endAction?.Invoke();
    }

    public void Powerup(Action startAction, Action endAction)
    {
        StartCoroutine(PowerupCoroutine(startAction, endAction));
    }

    IEnumerator PowerupCoroutine(Action startAction, Action endAction)
    {
        startAction?.Invoke();

        yield return new WaitForSeconds(0);

        endAction?.Invoke();
    }

    [Header("Tilt Event")]
    [SerializeField]
    private GameObject barGO;

    public void Tilt(Action startAction, Action endAction)
    {
        StartCoroutine(TiltCoroutine(startAction, endAction));
    }

    IEnumerator TiltCoroutine(Action startAction, Action endAction)
    {
        //Start
        barGO.transform.localPosition -= new Vector3(0, 150, 0);
        barGO.transform.rotation = Quaternion.Euler(0, 0, 45);
        startAction?.Invoke();

        yield return new WaitForSeconds(4);

        //End
        barGO.transform.rotation = Quaternion.Euler(0, 0, 0);
        barGO.transform.localPosition += new Vector3(0, 150, 0);
        endAction?.Invoke();
    }
}
