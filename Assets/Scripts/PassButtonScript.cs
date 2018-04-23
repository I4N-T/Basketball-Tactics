using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PassButtonScript : MonoBehaviour {

    public Button passBtn;
    
    void Awake()
    {
        passBtn.onClick.AddListener(PassBtnAction);
    }

    private void Update()
    {
        //TODO: THIS STUFF WILL ENABLE/DISABLE CONSTANTLY. DOESN'T NEED TO
        if (GameManager.selectedAthlete != null)
        {
            if (!GameManager.selectedAthlete.hasPossesion)
            {
                passBtn.enabled = false;
                passBtn.gameObject.SetActive(false);
            }
            else if (GameManager.selectedAthlete.hasPossesion)
            {
                passBtn.gameObject.SetActive(true);
                passBtn.enabled = true;
            }
        }
        
    }

    public void PassBtnAction()
    {
        GameManager.isPassMode = true;
    }
}
