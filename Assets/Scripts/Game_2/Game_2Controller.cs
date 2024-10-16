using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_2Controller : MonoBehaviour
{
    public List<Sprite> smallList = new List<Sprite>();
    public List<Sprite> smallBig = new List<Sprite>();

    public List<Image> smallUpList = new List<Image>();

    public int currentElemNomber=0;
    public int chooseType=0;

    //public GameObject  

    public List<int> coinFlipList = new List<int>();
    public void Generation()
    {
        for (int i = 0; i < 9; i++)
        {
            coinFlipList.Add(UnityEngine.Random.Range(0, 2));
        }
    }
    public void choose(int type)
    {
        chooseType = type;
            // StartCoroutine(FadeSprites());
            
            Config.UIController.analizRezultGame_2();
       
    }
    /// <summary>
    /// ///////////////////////////////////////////////////DANIL///////////////////////////////////////////////////
    /// </summary>
    ///
    ///
    
    
    
    
    
    
    
    
    
    
    
    
    
    public void checkRezult()
    {

        if (chooseType == coinFlipList[currentElemNomber])
        {
            if (currentElemNomber == coinFlipList.Count-1)
            {
                currentElemNomber = 0;
                
                Config.UIController.WinFullGame_2();
                coinFlipList.Clear();
                return;
            }
            currentElemNomber++;
            Config.UIController.nextStageGame_2();

        }
        else
        {
            Config.UIController.LoseGame_2();
            coinFlipList.Clear();
            Config.currentActiveStringGame_2 = 0;
            currentElemNomber = 0;
            return;
        }
        
    }



}
