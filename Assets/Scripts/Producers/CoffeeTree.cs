using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTree : Producer
{
    // Start is called before the first frame update
    void Start()
    {
        productName = "CoffeeBean";
        produceTime = 1;

        Init();
    }
}
