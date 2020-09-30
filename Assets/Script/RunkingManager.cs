using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunkingManager : MonoBehaviour
{
    GameObject runking;
    // Start is called before the first frame update
    void Start()
    {
        this.runking = GameObject.Find("Runking");
        this.runking.GetComponent<Text>().text = "1位 : " + StageProperty.first + "p" + "\n" + "2位 : " + StageProperty.second + "p";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
