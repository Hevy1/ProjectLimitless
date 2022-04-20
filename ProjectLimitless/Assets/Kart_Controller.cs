using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Kart_Controller : MonoBehaviour
{
    List<InputDevice> inputDevices;
    [Tooltip("Input device role (left or right controller)")]
    public InputDeviceRole LdeviceRole;
    [Tooltip("Input device role (left or right controller)")]
    public InputDeviceRole RdeviceRole;
    public bool isEnabled { get; set; } = false;
    public GameObject mainbody;
    public GameObject kartbody;

    // Start is called before the first frame update
    void Awake()
    {
        inputDevices = new List<InputDevice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            InputDevices.GetDevicesWithRole(RdeviceRole, inputDevices);
            float inputValueR = 0f;
            bool exit = false ;
            float m_Angle = 0f;
            for (int i = 0; i < inputDevices.Count; i++)
            {
                inputDevices[i].TryGetFeatureValue(CommonUsages.trigger, out inputValueR);
                if (inputDevices[i].TryGetFeatureValue(CommonUsages.gripButton, out exit) && exit){
                    Debug.Log(exit);
                    isEnabled = false;
                    kartbody.SetActive(false);
                    mainbody.transform.position = new Vector3(kartbody.transform.position.x + 3, kartbody.transform.position.y, kartbody.transform.position.z);
                    mainbody.SetActive(true);
                }
            }
            InputDevices.GetDevicesWithRole(LdeviceRole, inputDevices);
            float inputValueL = 0f;
            Vector2 v2;
            for (int i = 0; i < inputDevices.Count; i++)
            {
                inputDevices[i].TryGetFeatureValue(CommonUsages.trigger, out inputValueL);
                inputDevices[i].TryGetFeatureValue(CommonUsages.primary2DAxis, out v2);
                m_Angle = Vector2.Angle(new Vector2(0f,1f), v2);
                if(v2.x <= 0)
                {
                    m_Angle = -m_Angle;
                }
                if (inputDevices[i].TryGetFeatureValue(CommonUsages.gripButton, out exit) && exit)
                {
                    Debug.Log(exit);
                    isEnabled = false;
                    kartbody.SetActive(false);
                    mainbody.transform.position = new Vector3(kartbody.transform.position.x + 3, kartbody.transform.position.y, kartbody.transform.position.z);
                    mainbody.SetActive(true);
                }

            }
            if (inputValueR >= inputValueL && inputValueR != 0)
            {
                //Forward
                this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * inputValueR * 5;
                this.gameObject.transform.Rotate(0, m_Angle /120 * inputValueR, 0);
            }
            else
            {
                //Backward
                this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * -inputValueL * 2;
                this.gameObject.transform.Rotate(0, m_Angle/120 * inputValueL, 0);
            }
            
        }
    }
}
