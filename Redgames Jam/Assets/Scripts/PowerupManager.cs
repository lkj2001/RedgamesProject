using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private Dictionary<PowerType, bool> powerUpActiveStates = new Dictionary<PowerType, bool>();

    private void Start()
    {
        foreach (PowerType powerType in System.Enum.GetValues(typeof(PowerType)))
        {
            powerUpActiveStates[powerType] = false;
        }
    }

    public bool IsPowerUpActive(PowerType powerType)
    {
        return powerUpActiveStates[powerType];
    }

    public void SetPowerUpActive(PowerType powerType, bool activeState)
    {
        powerUpActiveStates[powerType] = activeState;
    }
}
