using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectables : MonoBehaviour
{

    private int gemNumber = 0;
    private Text gemText;

    // Start is called before the first frame update
    void Start()
    {
        gemText=GameObject.FindGameObjectWithTag("GemUI").GetComponent<Text>();
        UpdateText();
    }

    private void UpdateText(){
        gemText.text = gemNumber.ToString();
    }

    public void GemCollected(){
        gemNumber ++;
        UpdateText();
    }
}
