using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    public bool lampOn = false;
    private bool lampStateSwitched = false;

    public Color myColor;
    
    void Start()
    {
        if (!lampOn)
        {
            GetComponent<Image>().color = Color.black;
        }
    }

    public bool isOn()
    {
        return lampOn;
    }

    void Update()
    {
        if (lampStateSwitched)
        {
            lampStateSwitched = false;

            GetComponent<Image>().color = lampOn ? myColor : Color.black; 
        }
    }

    public void SwitchOnOffState()
    {
        lampOn = !lampOn;
        lampStateSwitched = true;
    }

    public void SwitchOn(bool onOff)
    {
        lampOn = onOff;
        lampStateSwitched = true;
    }
}
