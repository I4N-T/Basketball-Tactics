using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTurnButtonScript : MonoBehaviour {

    public Button endTurnBtn;
    public GameObject gameManagerObject;
    GameManager gmScript;
    PlayerControl pcScript;
    public static int turnCount = 0;

    void Awake()
    {
        gmScript = gameManagerObject.GetComponent<GameManager>();  //get gameManagerScript
        endTurnBtn.onClick.AddListener(EndTurnBtnAction);
    }

    public void EndTurnBtnAction()
    {
        foreach (Athlete athlete in gmScript.athleteList)
        {
            pcScript = athlete.gameObject.GetComponent<PlayerControl>();
            pcScript.hasMoved = false;
        }
        turnCount++;
        print(turnCount);
    }
}
