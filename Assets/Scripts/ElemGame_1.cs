using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElemGame_1 : MonoBehaviour
{

    public bool isGood;
    
    
    public void clickElem()
    {
        if (isGood)
        {
            gameObject.GetComponent<Image>().sprite = Config.UIController.poleSprite[1];

            Config.currentActiveStringGAME_1++;
            print(Config.currentActiveStringGAME_1);
            if (Config.currentActiveStringGAME_1 ==9)
            {
                Config.UIController.FullWinGame_1();
                Config.currentActiveStringGAME_1 = 0;
                return;
                //�� �������
            }
            Config.UIController.NextStringGame_1();
            
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = Config.UIController.poleSprite[0];
            // ����� ������� ���
            Config.currentActiveStringGAME_1 = 0;
            Config.UIController.LoseGame_1();
        }
    }
    public void getType(bool type)
    {
        isGood = type;
    }
}
