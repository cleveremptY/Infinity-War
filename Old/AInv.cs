using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AInv : MonoBehaviour
{
    public int width;
    public int height;
    public Transform Panel;
    public AItem[] items;
    public AItem mouseItem;
    public RectTransform mouseItemImage;

    public AItem nul;
    public AItem helm;

	void Start ()
    {
	    for (int i=0; i<width*height; i++)
        {
            GameObject newSlot = Instantiate((GameObject)Resources.Load("Button"));
            newSlot.transform.SetParent(Panel);
            newSlot.GetComponent<AInvButton>().myInv = this;
            newSlot.GetComponent<AInvButton>().myID = i;
        }
        for (int i=0; i<width*height; i++)
        {
            GameObject newItem = new GameObject("Item", typeof (AItem));
            if (Random.Range(0, 2)==0)
            {
                newItem.GetComponent<AItem>().name = "";
                newItem.GetComponent<AItem>().Image = null;
                newItem.GetComponent<AItem>().stack = 0;
                newItem.GetComponent<AItem>().maxStack = 0;
                newItem.GetComponent<AItem>().ID = 0;
            }
            else
            {
                newItem.GetComponent<AItem>().name = helm.name;
                newItem.GetComponent<AItem>().Image = helm.Image;
                newItem.GetComponent<AItem>().stack = Random.Range(5, 13);
                newItem.GetComponent<AItem>().maxStack = 64;
                newItem.GetComponent<AItem>().ID = helm.ID;
            }
            items[i] = newItem.GetComponent<AItem>();
        }
        Redraw();
	}

    public void selectSlot(int ID)
    {
        if (items[ID].ID == mouseItem.ID)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (mouseItem.stack>items[ID].maxStack - items[ID].stack)
                {
                    mouseItem.stack -= items[ID].maxStack - items[ID].stack;
                    items[ID].stack = items[ID].maxStack;
                }
                else
                {
                    items[ID].stack += mouseItem.stack;
                    mouseItem.name = nul.Name;
                    mouseItem.Image = nul.Image;
                    mouseItem.stack = 0;
                    mouseItem.maxStack = 0;
                    mouseItem.ID = 0;
                }
            }
            else
            {
                if (mouseItem.stack>1 & items[ID].stack<items[ID].maxStack)
                {
                    items[ID].stack++;
                    mouseItem.stack--;
                }
            }
        }
        else
        {
            AItem tempItem = items[ID];
            items[ID] = mouseItem;
            mouseItem = tempItem;
        }
        Redraw();
    }

    public void Redraw ()
    {
        for (int i=0; i<width*height; i++)
        {
            Panel.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = items[i].Image;
            if (items[i].stack == 0)
            {
                Panel.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
            }
            else
            {
                Panel.GetChild(i).GetChild(1).GetComponent<Text>().text = items[i].stack + "/" + items[i].maxStack;
            }
        }
        if (mouseItem.Image == null)
        {
            mouseItemImage.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
            mouseItemImage.transform.GetChild(0).GetComponent<Text>().text = "";
        }
        else
        {
            mouseItemImage.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            mouseItemImage.GetComponent<RawImage>().texture = mouseItem.Image;
            mouseItemImage.transform.GetChild(0).GetComponent<Text>().text = mouseItem.stack + "/" + mouseItem.maxStack;
        }
    }
	
	void Update ()
    {
        mouseItemImage.transform.position = Input.mousePosition - new Vector3(0, 100, 0);
	}
}
