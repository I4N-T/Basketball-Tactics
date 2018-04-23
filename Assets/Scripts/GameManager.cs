using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    GameObject[] tiles = new GameObject[190];

    public GameObject tilePrefab;
    public GameObject tileHolder;  //just to keep the hierarchy nice and neat
    private GameObject tile;

    public static Athlete selectedAthlete;
    public List<Athlete> athleteList = new List<Athlete>();

    public static int playerScore;
    public static int opponentScore;

    public static bool isPassMode;

    public Button passBtn;


    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        int i = 0;
        for (int x = 0; x < 10; ++x)
        {
            for (int y = 0; y < 19; ++y)
            {
                tile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, tileHolder.transform) as GameObject;
                tiles[i] = tile;
                i++;
            }
        }
    }

    private void Update()
    {
        if (selectedAthlete != null)
        {
            print(selectedAthlete.name);

            //TODO: THIS STUFF WILL ENABLE/DISABLE CONSTANTLY. DOESN'T NEED TO
            //TODO: THIS COULD ALL GO IN A DIFFERENT SCRIPT. UIMANAGER?
            if (GameManager.selectedAthlete != null)
            {
                if (!GameManager.selectedAthlete.hasPossesion || selectedAthlete.gameObject.GetComponent<PlayerControl>().hasMoved)
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
        else if (selectedAthlete == null)
        {
            passBtn.gameObject.SetActive(false);
        }
        
    }

}
