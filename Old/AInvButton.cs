using UnityEngine;
using System.Collections;

public class AInvButton : MonoBehaviour
{
    public AInv myInv;
    public int myID;

    public void press ()
    {
        myInv.selectSlot(myID);
    }
}
