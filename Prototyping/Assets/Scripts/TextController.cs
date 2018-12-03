using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls dialogue positioning onto default speech canvas.
/// Called from PlayerInfo.cs
/// </summary>
public class TextController : MonoBehaviour {
    //delay time between characters being displayed for slow text read
    public float ReadTextSpeed;
    private Text text;
    public void Start() {
        text = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<Text>();
    }
    public void SetText(int textPos) {
        Debug.Log("Setting Text with pos: " + textPos);
        switch (textPos) {
            case 0: text.text =
                "The Text controller, a controller where the flow of text in the standard" +
                " dialogue canvas is displayed."; break;
            case 1: StartCoroutine("ReadText", "String for ReadText being read.."); break;
        }
    }

    public IEnumerator ReadText(string inText) {
        int inPos = 0;
        while (true) {
            Debug.Log("inText[" + inPos + "]");
            Debug.Log(inText[inPos]);
            text.text += inText[inPos];
            inPos++;
            yield return new WaitForSecondsRealtime(ReadTextSpeed);
        }
    }

}
