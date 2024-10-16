using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_1Controll : MonoBehaviour
{
    public static Game_1Controll sing;

    public Button Item;
    private Button currentElemGrid;
    public GameObject grid;
    [SerializeField] private ElemGame_1[,] allElemList_1 = new ElemGame_1[4, 9];
    private int typeElemGrid;
    [Range(0,3)]
    public List<int> valueBadElemInLine = new List<int>();


    private void Awake()
    {
        if(sing == null)
        {
            sing = this;
        }
    }
    public void Start()
    {
        //GeneratePole();
    }
    public void GeneratePole()
    {

        while (grid.transform.childCount > 0)
        {
            DestroyImmediate(grid.transform.GetChild(0).gameObject);
        }
        for (int i = 0; i < 9; i++)
        {

            for (int k = 0; k < 4; k++)
            {
                currentElemGrid = Instantiate(Item, grid.transform);
                //currentElemGrid.GetComponent<ElemScripts>().nomberElem = new Vector2Int(k, i);
                allElemList_1[k, i] = currentElemGrid.GetComponent<ElemGame_1>();
                allElemList_1[k, i].getType(true);
                //allElemList_1[k, i].currentPercent.text = "x" + StaticConfig.percentList[i];
            }

            for (int h = 0; h < valueBadElemInLine[i]; h++)
            {
                typeElemGrid = Random.Range(0, 4);

                if (allElemList_1[typeElemGrid, i].isGood== false)
                {
                    h--;
                }
                else
                {
                    allElemList_1[typeElemGrid, i].getType(false);
                }
                
            }
            
            
        }
        Config.allGame_1List = allElemList_1;


        //ControllCastlePlay.nextString();
    }
}
