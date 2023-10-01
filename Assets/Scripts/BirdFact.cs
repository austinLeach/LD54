using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BirdFact : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = GlobalVariables.factList[Random.Range(0, GlobalVariables.factList.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
