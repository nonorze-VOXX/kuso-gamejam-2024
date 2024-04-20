using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private PigController player;

    public void EventTrigger(Effect effect)
    {
        switch (effect)
        {
            case Effect.Recover:
                Recover();
                break;
            case Effect.Giveup:
                Giveup();
                break;
            case Effect.Powerup:
                Powerup();
                break;
            case Effect.Tilt:
                Tilt();
                break;
        }
    }

    public void Recover() { }

    public void Giveup() { }

    public void Powerup() { }

    public void Tilt() { }
}
