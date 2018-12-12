using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls dialogue positioning onto default speech canvas.
/// Called from PlayerInfo.cs on game start
/// </summary>
public class TextController : MonoBehaviour {
    //delay time between characters being displayed for slow text read
    public float ReadTextSpeedDelay;
    private Text text;
    private int playNextText;
    public GameObject dungeonManager;
    public GameObject displayLeft;
    public GameObject displayRight;
    public GameObject isTalkingLeft;
    public GameObject isTalkingRight;
    public void Awake() {
        text = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<Text>();
    }
    public void SetText(int textPos) {
        //Debug.Log("Setting Text with pos: " + textPos);
        switch (textPos) {
            case 0:
            //reset / close condition
            text.text = "";
            this.gameObject.SetActive(false);
            displayLeft.SetActive(false);
            displayRight.SetActive(false);
            isTalkingLeft.SetActive(false);
            isTalkingRight.SetActive(false);
            break;
            //load characters only condition
            case 1:
            text.text = "Exciting allegedly blank text space.";
            displayLeft.SetActive(true);
            displayRight.SetActive(true);
            isTalkingLeft.SetActive(true);
            isTalkingRight.SetActive(true);
            break;
            case 2: playNextText = 3;
            isTalkingLeft.SetActive(true);
            isTalkingRight.SetActive(false);
            text.text = "MINOTAUR: ";
            StartCoroutine("ReadText", "Do you think we should chase these kids " +
                "into this dark labyrinth Big Scary Enemy?");
            break;
            case 3: playNextText = 4;
            isTalkingLeft.SetActive(false);
            isTalkingRight.SetActive(true);
            text.text = "BSE: ";
            StartCoroutine("ReadText", "Absolutely. You go first.");
            break;
            case 4: playNextText = 0;
            dungeonManager.GetComponent<DungeonManager>().MoveAllEncounters();
            SetText(0);
            break;
        }
    }

    public void PlayNextText() {
        StopCoroutine("ReadText");
        text.text = "";
        SetText(playNextText);
    }

    public IEnumerator ReadText(string inText) {
        int inPos = 0;
        while (true) {
            //stop at end of string
            if (inPos >= inText.Length - 1)
                StopCoroutine("ReadText");
            text.text += inText[inPos];
            inPos++;
            yield return new WaitForSecondsRealtime(ReadTextSpeedDelay);
        }
    }

}
