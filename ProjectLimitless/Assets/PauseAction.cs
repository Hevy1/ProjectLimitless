using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class PauseAction : MonoBehaviour
{
    List<InputDevice> inputDevices;
    [Tooltip("Input device role (left or right controller)")]
    public InputDeviceRole RdeviceRole;
    public GameObject canvas;

    void Awake()
    {
        inputDevices = new List<InputDevice>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithRole(RdeviceRole, inputDevices);
        bool pause = false;
        for (int i = 0; i < inputDevices.Count; i++)
        {
            if (inputDevices[i].TryGetFeatureValue(CommonUsages.primary2DAxisClick, out pause) && pause)
            {
                canvas.SetActive(true);
            }
        }
    }
}
