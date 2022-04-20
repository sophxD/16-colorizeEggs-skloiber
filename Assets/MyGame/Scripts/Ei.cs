using UnityEngine;
using UnityEngine.UI;

public class Ei : MonoBehaviour
{
    public bool inBasket;
    public Color myColor;

    private ManagerEierfaerben myManager;

    private void Start()
    {
        myManager = FindObjectOfType<ManagerEierfaerben>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Lamp") && collision.GetComponent<Lamp>().isOn())
        {
            if (collision.name == "LampBlue")
            {
                GetComponent<Image>().color = Color.blue;

            }
            else if (collision.name == "LampGreen")
            {
                GetComponent<Image>().color = Color.green;
 
            }
            else if (collision.name == "LampRed")
            {
                GetComponent<Image>().color = Color.red;
            }
        }
        else if (collision.name == "ImgBasketBottom")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            transform.position = new Vector3(-200,-200,0);
            inBasket = true;

            if (GetComponent<Image>().color == Color.red)
            {
                myManager.doneRed++;
            }
            else if (GetComponent<Image>().color == Color.blue)
            {
                myManager.doneBlue++;
            }
            else if (GetComponent<Image>().color == Color.green)
            {
                myManager.doneGreen++;
            }
            else if (GetComponent<Image>().color == Color.white)
            {
                myManager.doneWhite++;
            }
        }
    }

    public void Release()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;    
    }
}
