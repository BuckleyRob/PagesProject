using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAfterKeys : MonoBehaviour {
    public int displayAfter;
    public string textToDisp;
    public Text textBox;
    private int count = 0;
    private void Update()
    {
        if (Input.anyKeyDown) {
            count++;
            if(count > displayAfter) {
                int numToDisp = count - displayAfter;
                textBox.text = textToDisp.Substring(0, numToDisp);
            }
        }
    }
}
