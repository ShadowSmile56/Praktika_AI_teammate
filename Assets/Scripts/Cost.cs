using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    // Start is called before the first frame update
    public int SwordCount = 0;

    public int SwordPrice = 0;

    public int TotalGold = 0;

    void Start()
    {
        TotalGold = SwordCount * SwordPrice;
        Debug.Log(TotalGold);
    }

 
}
