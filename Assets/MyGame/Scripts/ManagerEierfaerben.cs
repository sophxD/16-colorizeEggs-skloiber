using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerEierfaerben : MonoBehaviour
{
    public Lamp[] lamps;

    public TextMeshProUGUI dynOrderValueRed;
    public TextMeshProUGUI dynOrderValueGreen;
    public TextMeshProUGUI dynOrderValueBlue;
    public TextMeshProUGUI dynOrderValueWhite;

    public TextMeshProUGUI dynOrderDoneRed;
    public TextMeshProUGUI dynOrderDoneGreen;
    public TextMeshProUGUI dynOrderDoneBlue;
    public TextMeshProUGUI dynOrderDoneWhite;

    public GameObject parentEggs;
    public Ei prefabEgg;
    public TextMeshProUGUI doneMsg;

    public Image overlay;
    
    public int orderRed, doneRed;
    public int orderBlue, doneBlue;
    public int orderGreen, doneGreen;
    public int orderWhite, doneWhite;

    private int maxOrderEggs = 12;
    private Ei[] eggs;
    
    private int releaseIndex = 0;
    
    private void Start()
    {
        GenerateOrder();
        GenerateEggs(maxOrderEggs, prefabEgg, parentEggs);
        Invoke("ReleaseEgg", 2);
    }

    private void Update()
    {
        if(eggs[maxOrderEggs-1].inBasket)
        {
            overlay.gameObject.SetActive(true);


            if (doneBlue == orderBlue && doneGreen == orderGreen && doneRed == orderRed && doneWhite == orderWhite)
            {
                doneMsg.text = "Juhu, alle Bestellungen erledigt!!";
            }
            else
            {
                doneMsg.text = "Ojeee, Bestellungen leider nicht erledigt!!";
            }

        }
    }
    public void GenerateEggs(int maxVal, Ei prefabEgg, GameObject myParent)
    {
        eggs = new Ei[maxOrderEggs];

        for (int i = 0; i < maxVal; i++)
        {
            eggs[i] = Instantiate(prefabEgg);
            eggs[i].transform.SetParent(myParent.transform);
            eggs[i].transform.localPosition = Vector3.zero;
            eggs[i].transform.localScale = Vector3.one;
        }
    }

    public void SwithLampState(GameObject thisObj)
    {
        thisObj.GetComponent<Lamp>().SwitchOnOffState();
    }

    void ReleaseEgg()
    {
        if (releaseIndex < maxOrderEggs)
        {
            eggs[releaseIndex].Release();
            Invoke("ReleaseEgg", 2);
            releaseIndex++;
        }
    }

    public void TurnOnLamps(bool on)
    {

    }

    public void GenerateOrder()
    {
        orderRed = Random.Range(0,maxOrderEggs);
        orderBlue = Random.Range(0, maxOrderEggs - orderRed);
        orderGreen = Random.Range(0, maxOrderEggs - orderRed - orderBlue);
        orderWhite = maxOrderEggs - orderRed - orderBlue - orderGreen;

        dynOrderValueRed.text = orderRed.ToString();
        dynOrderValueGreen.text = orderGreen.ToString();
        dynOrderValueBlue.text = orderBlue.ToString();
        dynOrderValueWhite.text = orderWhite.ToString();

        dynOrderDoneRed.text = doneRed + "/" + orderRed;
        dynOrderDoneBlue.text = doneBlue + "/" + orderBlue;
        dynOrderDoneGreen.text = doneGreen + "/" + orderGreen;
        dynOrderDoneWhite.text = doneWhite + "/" + orderWhite;
    }

    public void SetRedDoneValue()
    {
        dynOrderDoneRed.text = doneRed + "/" + orderRed;
    }

    public void SetBlueDoneValue()
    {
        dynOrderDoneBlue.text = doneBlue + "/" + orderBlue;
    }

    public void SetGreenDoneValue()
    {
        dynOrderDoneGreen.text = doneGreen + "/" + orderGreen;
    }

    public void SetWhiteDoneValue()
    {
        dynOrderDoneWhite.text = doneWhite + "/" + orderWhite;
    }
}
