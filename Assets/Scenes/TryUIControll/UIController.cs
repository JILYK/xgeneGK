using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Game_1")] public List<Text> kefListGame_1 = new List<Text>();

    public GameObject contentGame_1;
    public List<GameObject> setUpGame_ON = new List<GameObject>();
    public List<GameObject> setUpGame_OFF = new List<GameObject>();

    public List<GameObject> startGame_ON = new List<GameObject>();
    public List<GameObject> startGame_OFF = new List<GameObject>();

    public List<GameObject> winALLGame_ON = new List<GameObject>();
    public List<GameObject> winALLGame_OFF = new List<GameObject>();

    public List<GameObject> collectNowGame_ON = new List<GameObject>();
    public List<GameObject> collectNowGame_OFF = new List<GameObject>();


    public List<GameObject> loseGame_ON = new List<GameObject>();
    public List<GameObject> loseGame_OFF = new List<GameObject>();


    public Button stavkaPlusGame_1;
    public Button stavkaMunusGame_1;
    public Button playGame_1;
    public Button TryAgain;
    public Button collectNowGame_1;

    public ScrollRect scrollRectRectGame_1;
    public GameObject loseGame_1;
    public GameObject plashkaGame_1;
    public GameObject plashkaStavkaGame_1;
    //public GameObject plashkaAllWinGame_1;

    public GameObject winAllGame_1;

    public List<GameObject> fullWinGame_1;

    public Game_1Controll Game_1Controll;
    public Text valueStavkaGAME_1;
    public Text valueIfWinGAME_1;
    public Text WinGameValueGAME_1;
    public GameObject startImage;
    public Image selectedLine;
    public Image block;

    public GameObject histoiryPanel;
    public GameObject InfoLinePanel;


    public List<GameObject> AllElemList = new List<GameObject>();

    public List<Sprite> stateDNK = new List<Sprite>();
    public List<Sprite> poleSprite = new List<Sprite>();

    public GameObject dnk;

    public Text infoVirusLine;

    public List<Image> HistoryGame_1;
    public List<Sprite> typeGame_1;

    [Header("Game_2")] public Button collectNowGame_2;
    public Button playGame_2;
    public Button tryagainGame_2;

    public Text finalReward;

    public Image plashka_2;

    public List<Text> kefList = new List<Text>();

    public ScrollRect allElemScroll;

    public GameObject contentGame_2;

    public Game_2Controller Game_2Controller;

    public List<Sprite> smallTypeList;
    public List<Sprite> bigTypeList;

    public List<Image> smallHistory;

    public Button GenomBut;
    public Button VrusBut;

    public Text midLineText;

    public Text infoRound;
    public Text nextValue;
    public Text waitingResult;

    public Image selectedType;
    public Image bigVirus;
    public Image bigGenom;
    public Image bigUnknow;
    public Image Lose;

    public GameObject allWinGame_2;
    public GameObject plashka;


    [Header("������� ����")] public GameObject castleGame;
    public GameObject setUpOrderGame;
    public GameObject orderGame;

    [Header("������� ������� ����")] public GameObject winCastle;
    public GameObject loseCastle;
    public GameObject winORDER;
    public GameObject loseORDER;


    [Header("��������� ���� ����")] public GameObject Menu;

    [Header("������ CASTLE")] public Button plusStavkaCastle;
    public Button minusStavkaCastle;
    public Button playAgain; //-1
    public Button collectNow;
    public Button startCastle;

    [Header("����� CASTLE")] public Text valueStavkaCastle;
    public Text valueIfWinCastle;
    public Text WinGameValueTxt;


    [Header("������ SetUpORDER")] public List<Button> listLine;
    public Button plusStavkaORDER;
    public Button minusStavkaORDER;
    public Button StartGameORDER;

    [Header("����� SetUpORDER")] public Text valueStavkaORDER;
    public Text valueHaveCoinORDER;
    public Text valueIfWinORDER;


    [Header("Buy ������")] public GameObject buyCoins;
    public GameObject buyHearts;


    [Header("��������� ������")] public GridControllCastle GridControllCastle;

    [Header("���������� � �������")] public Text mainWindowCoins;
    public Text OrderSetUpCoins;
    public Text subl;

    [Header("���������� �  �������")] public Text mainWindowHearts;

    [Header("##############")] public bool haveHearth;
    public bool haveCoins;
    public GameObject whitePole;

    void Start()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true);

        foreach (Button button in allButtons)
        {
            button.gameObject.GetComponent<Button>().onClick.AddListener(TestONClick);
        }
    }

    #region Game_1

    public void SetUpGame_1()
    {
        dnk.transform.localPosition = new Vector3(dnk.transform.localPosition.x, 2070f, dnk.transform.localPosition.z);

        // contentGame_1.transform.localPosition = new Vector3(-207f, contentGame_1.transform.localPosition.y,
        //        contentGame_1.transform.localPosition.z);

        foreach (Image item in HistoryGame_1)
        {
            item.GetComponent<Image>().sprite = typeGame_1[3];
        }

        for (int i = 0; i < Config.percentList.Length; i++)
        {
            kefListGame_1[i].text = "x" + Config.percentList[i].ToString();
        }

        foreach (var item in setUpGame_ON)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in setUpGame_OFF)
        {
            item.gameObject.SetActive(false);
        }

        //foreach (GameObject item in fullWinGame_1)
        //{
        //    item.SetActive(false);
        //}
        //histoiryPanel.SetActive(false);
        //InfoLinePanel.SetActive(false);
        //startImage.SetActive(true);
        ////Game_1Controll.GeneratePole();
        //selectedLine.gameObject.SetActive(false);
    }

    public void ReturnGameMethod()
    {
        startGame_1();
        goToMEnu();
        SetUpGame_1();
        DrawLineValueButton1();
    }

    public GameObject PrafabLine;

    public void DrawLineValueButton1()
    {
        for (int i = 0; i < contentGame_1.transform.childCount; i++)
        {
            Destroy(contentGame_1.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject newChild = Instantiate(PrafabLine);
            newChild.transform.SetParent(contentGame_1.transform);
            newChild.transform.GetChild(0).GetComponent<Text>().text = "x" + Config.percentList[i];
            newChild.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void DrawLineValueButton2() /////Retur1Game
    {
        for (int i = 0; i < contentGame_2.transform.childCount; i++)
        {
            Destroy(contentGame_2.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject newChild = Instantiate(PrafabLine);
            newChild.transform.SetParent(contentGame_2.transform);
            newChild.transform.GetChild(0).GetComponent<Text>().text = "x" + Config.percentList[i];
            newChild.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void startGame_1()
    {
        if (Config.currentStavka <= 0 || Config.currentStavka > Config.coins)
        {
            return;
        }

        if (!ControllReserses.isPosibleChangeHearts(-1))
        {
            buyHearts.SetActive(true);
            return;
        }

        if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
        {
            buyCoins.SetActive(true);
            return;
        }


        Destroy(contentGame_1.gameObject.transform.GetChild(0).gameObject);

        foreach (Image item in HistoryGame_1)
        {
            item.GetComponent<Image>().sprite = typeGame_1[3];
        }

        dnk.transform.localPosition = new Vector3(dnk.transform.localPosition.x, 2070f, dnk.transform.localPosition.z);
        foreach (var item in startGame_ON)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in startGame_OFF)
        {
            item.gameObject.SetActive(false);
        }

        //startImage.SetActive(false);
        //histoiryPanel.SetActive(true);
        //InfoLinePanel.SetActive(true);
        //selectedLine.gameObject.SetActive(true);
        //foreach (GameObject item in fullWinGame_1)
        //{
        //    item.SetActive(false);
        //}
        for (int i = 0; i < smallHistory.Count; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = typeGame_1[3];
        }

        HistoryGame_1[Config.currentActiveStringGAME_1].GetComponent<Image>().sprite = typeGame_1[2];

        infoVirusLine.text = Game_1Controll.sing.valueBadElemInLine[Config.currentActiveStringGAME_1].ToString();

        Config.posibleWin = Config.currentStavka * Config.percentList[0];
        updateText();
        ControllReserses.changeHeartsValue(-1);
        ControllReserses.changeCoinsValue(-Config.currentStavka);

        foreach (Image item in HistoryGame_1)
        {
            item.GetComponent<Image>().sprite = typeGame_1[3];
        }

        Game_1Controll.GeneratePole();
    }

    IEnumerator MoveDown(Transform target, float distance, float duration)
    {
        // Начальная позиция
        Vector3 startPosition = target.localPosition;
        // Конечная позиция
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y - distance, startPosition.z);
        // Пройденное время
        float elapsedTime = 0;

        // Пока время не истечет
        while (elapsedTime < duration)
        {
            // Обновляем позицию объекта
            target.localPosition = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
            // Увеличиваем время
            elapsedTime += Time.deltaTime;
            // Ждем следующего кадра
            yield return null;
        }

        // Убедимся, что объект достиг конечной позиции
        target.localPosition = endPosition;
    }

    public void NextStringGame_1()
    {
        StartCoroutine(MoveDown(dnk.transform, 216.22f, 0.5f));

        HistoryGame_1[Config.currentActiveStringGAME_1 - 1].GetComponent<Image>().sprite = typeGame_1[1];
        //if (Config.currentActiveStringGAME_1 < 9)
        //{
        HistoryGame_1[Config.currentActiveStringGAME_1].GetComponent<Image>().sprite = typeGame_1[2];
        infoVirusLine.text = Game_1Controll.sing.valueBadElemInLine[Config.currentActiveStringGAME_1].ToString();


        Destroy(contentGame_1.gameObject.transform.GetChild(0).gameObject);
        //}


        //for (int i = 0; i < HistoryGame_1.Count; i++)
        //{
        //    HistoryGame_1[i].GetComponent<Image>().sprite = typeGame_1[1];
        //}
        //for (int i = 0; i < Game_2Controller.currentElemNomber; i++)
        //{
        //    smallHistory[i].GetComponent<Image>().sprite = smallTypeList[Game_2Controller.coinFlipList[i]];
        //}
        //if (Game_2Controller.currentElemNomber < 9)
        //{
        //    print(Game_2Controller.currentElemNomber);
        //    smallHistory[Game_2Controller.currentElemNomber].GetComponent<Image>().sprite = smallTypeList[3];
        //}
        Config.posibleWin = Config.currentStavka * Config.percentList[Config.currentActiveStringGAME_1];
        if (Config.currentActiveStringGAME_1 == 7)
        {
            dnk.GetComponent<Image>().enabled = true;
            dnk.GetComponent<Image>().sprite = stateDNK[0];
        }

        updateText();
    }

    public void collectNowGame_1_1()
    {
        if (Config.currentActiveStringGAME_1 == 0)
        {
            return;
        }

        ControllReserses.changeCoinsValue(Config.posibleWin);
        Config.posibleWin = Config.currentStavka;
        Config.currentActiveStringGAME_1 = 0;
        updateText();
        SetUpGame_1();
        foreach (var item in collectNowGame_ON)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in collectNowGame_OFF)
        {
            item.gameObject.SetActive(false);
        }

        DrawLineValueButton1();
    }

    public void LoseGame_1()
    {
        //loseGame_1.SetActive(true);
        //plashkaGame_1.SetActive(false);
        //plashkaStavkaGame_1.SetActive(false);


        //foreach (Image item in HistoryGame_1)
        //{
        //    item.GetComponent<Image>().sprite = typeGame_1[3];
        //}

        foreach (var item in loseGame_ON)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in loseGame_OFF)
        {
            item.gameObject.SetActive(false);
        }

        HistoryGame_1[Config.currentActiveStringGAME_1].GetComponent<Image>().sprite = typeGame_1[0];
    }

    public void FullWinGame_1()
    {
        foreach (var item in winALLGame_ON)
        {
            item.gameObject.SetActive(true);
        }

        foreach (var item in winALLGame_OFF)
        {
            item.gameObject.SetActive(false);
        }

        ControllReserses.changeCoinsValue(Config.posibleWin);
        Config.posibleWin = 0;
        updateText();

        dnk.GetComponent<Image>().sprite = stateDNK[1];
        scrollRectRectGame_1.gameObject.SetActive(false);
        TryAgain.gameObject.SetActive(false);
        playGame_1.gameObject.SetActive(false);


        foreach (GameObject item in fullWinGame_1)
        {
            item.SetActive(true);
        }

        print(123123123123);
    }

    #endregion

    #region Game_2


    public GameObject FilterFolder;
    public void setUpGame_2()
    {
        //Destroy(contentGame_2.gameObject.transform.GetChild(0).gameObject);

        RectTransform rectTransform = contentGame_2.GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            rectTransform.offsetMin = new Vector2(5.5f, 0);  // Left and Bottom
            rectTransform.offsetMax = new Vector2(-33.5f, -1); // Right and Top (negative values because Unity uses offsets)
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, 0);  // Pos Z
        }
        else
        {
            Debug.LogError("RectTransform component not found!");
        }
    
            
        bigUnknow.GetComponent<Image>().sprite = bigTypeList[2];

        allWinGame_2.gameObject.SetActive(false);
        playGame_2.gameObject.SetActive(true);
        plashka_2.gameObject.SetActive(true);

        //scrollbarGame_2.value = 0f;
        for (int i = 0; i < Config.percentList.Length; i++)
        {
            kefList[i].text = "x" + Config.percentList[i].ToString();
        }

        for (int i = 0; i < smallHistory.Count; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = smallTypeList[2];
        }

        infoRound.gameObject.SetActive(false);
        waitingResult.gameObject.SetActive(false);

        allElemScroll.gameObject.SetActive(true);
        plashka.gameObject.SetActive(true);

        bigUnknow.gameObject.SetActive(true);
        midLineText.text = "Press “Play” for start game";
        bigVirus.gameObject.SetActive(true);
        bigGenom.gameObject.SetActive(true);


        selectedType.gameObject.SetActive(false);
        GenomBut.gameObject.SetActive(false);
        VrusBut.gameObject.SetActive(false);
        Lose.gameObject.SetActive(false);

        plusStavkaCastle.gameObject.SetActive(true);
        minusStavkaCastle.gameObject.SetActive(true);
        valueStavkaCastle.gameObject.SetActive(true);
    }

    public void ReturnGame_2()
    {
        allWinGame_2.gameObject.SetActive(false);

        collectNowGame_2.gameObject.SetActive(false);
        playGame_2.gameObject.SetActive(true);
        //ControllReserses.changeCoinsValue(Config.posibleWin);


        Config.posibleWin = Config.currentStavka;
        updateText();

        Config.SaveGame();
        setUpGame_2();
        DrawLineValueButton2();
    }

    public void startGame_2()
    {
        if (Config.currentStavka <= 0 || Config.currentStavka > Config.coins)
        {
            return;
        }

        if (!ControllReserses.isPosibleChangeHearts(-1))
        {
            buyHearts.SetActive(true);
            return;
        }

        if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
        {
            buyCoins.SetActive(true);
            return;
        }

        bigUnknow.GetComponent<Image>().sprite = bigTypeList[2];
        stavkaPlusGame_1.gameObject.SetActive(false);
        stavkaMunusGame_1.gameObject.SetActive(false);
        playGame_1.gameObject.SetActive(false);
        TryAgain.gameObject.SetActive(false);

        collectNowGame_1.gameObject.SetActive(true);

        Lose.gameObject.SetActive(false);
        bigGenom.gameObject.SetActive(true);
        bigVirus.gameObject.SetActive(true);
        waitingResult.gameObject.SetActive(false);
        selectedType.gameObject.SetActive(false);

        for (int i = 0; i < smallHistory.Count; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = smallTypeList[2];
        }
        

        smallHistory[Game_2Controller.currentElemNomber].GetComponent<Image>().sprite = smallTypeList[3];
       // contentGame_2.transform.localPosition = new Vector3(-207f, contentGame_2.transform.localPosition.y,
        //    contentGame_2.transform.localPosition.z);
        bigUnknow.GetComponent<Image>().sprite = bigTypeList[2];
        allElemScroll.gameObject.SetActive(true);
        plashka.gameObject.SetActive(true);

        Config.posibleWin = Config.currentStavka;
        updateText();
        ControllReserses.changeHeartsValue(-1);
        ControllReserses.changeCoinsValue(-Config.currentStavka);

        valueIfWinCastle.gameObject.SetActive(true);
        collectNow.gameObject.SetActive(true);

        Game_2Controller.Generation();
        //GridControllCastle.startGame();// заменить на скрипт для игры 2
        startCastle.gameObject.SetActive(false);
        //valueStavkaCastle.gameObject.SetActive(false);
        plusStavkaCastle.gameObject.SetActive(false);
        minusStavkaCastle.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);

        collectNow.gameObject.SetActive(true);

        startCastle.gameObject.SetActive(false);

        GenomBut.gameObject.SetActive(true);
        VrusBut.gameObject.SetActive(true);

        infoRound.gameObject.SetActive(true);
        infoRound.text = $"Round {Game_2Controller.currentElemNomber + 1} /9";
        midLineText.text = "What is it?";
    }

    public void analizRezultGame_2()
    {
        GenomBut.gameObject.SetActive(false);
        VrusBut.gameObject.SetActive(false);
        bigVirus.gameObject.SetActive(false);
        bigGenom.gameObject.SetActive(false);


        selectedType.gameObject.SetActive(true);


        StartCoroutine(waitRezult());
    }

    [Header(
        "][[]][][][][][][][][][[][][][ANIMATIOM-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=-=--=-=-=--")]
    public Image image; // Прикрепите ваш Image компонент здесь через Inspector

    public Sprite sprite1; // Первый спрайт для смены
    public Sprite sprite2; // Второй спрайт для смены

    private IEnumerator waitRezult()
    {
        waitingResult.gameObject.SetActive(true);
        waitingResult.text = "Waiting result...";
        selectedType.GetComponent<Image>().sprite = bigTypeList[Game_2Controller.chooseType];

        yield return FadeSprites();

        image.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); // Reset alpha to opaque
        bigUnknow.GetComponent<Image>().sprite =
            bigTypeList[Game_2Controller.coinFlipList[Game_2Controller.currentElemNomber]];
        yield return new WaitForSeconds(1f);

        bigUnknow.GetComponent<Image>().sprite = bigTypeList[Game_2Controller.coinFlipList[2]];
        Game_2Controller.checkRezult();
        yield return null;
    }

    private IEnumerator FadeSprites()
    {
        int blinkCount = 5;
        float totalDuration = 3f;
        float singleBlinkDuration = totalDuration / blinkCount;
        float halfBlinkDuration = singleBlinkDuration / 2f;

        for (int i = 0; i < blinkCount; i++)
        {
            image.sprite = (i % 2 == 0) ? sprite1 : sprite2; // Toggle between sprite1 and sprite2
            for (float timer = 0; timer < halfBlinkDuration; timer += Time.deltaTime)
            {
                float alpha = Mathf.Lerp(0f, 1f, timer / halfBlinkDuration);
                image.color = new Color(1f, 1f, 1f, alpha);
                yield return null;
            }

            for (float timer = 0; timer < halfBlinkDuration; timer += Time.deltaTime)
            {
                float alpha = Mathf.Lerp(1f, 0f, timer / halfBlinkDuration);
                image.color = new Color(1f, 1f, 1f, alpha);
                yield return null;
            }
        }

        // Ensure sprite and alpha are reset at the end
        image.sprite = sprite2;
        image.color = new Color(1f, 1f, 1f, 1f);
    }


    public void nextStageGame_2()
    {
        Config.currentActiveStringGame_2++;
        if (Config.currentActiveStringGame_2 > 0)
        {
            Config.posibleWin = Config.currentStavka * Config.percentList[Config.currentActiveStringGame_2 - 1];
            Config.UIController.updateText();
        }
        else
        {
            Config.posibleWin = Config.currentStavka;
        }

        bigUnknow.GetComponent<Image>().sprite = bigTypeList[2];
        Destroy(contentGame_2.gameObject.transform.GetChild(0).gameObject);
        selectedType.gameObject.SetActive(false);

        GenomBut.gameObject.SetActive(true);
        VrusBut.gameObject.SetActive(true);
        bigVirus.gameObject.SetActive(true);
        bigGenom.gameObject.SetActive(true);
        infoRound.text = $"Round {Game_2Controller.currentElemNomber + 1} /9";
        waitingResult.gameObject.SetActive(false);

        for (int i = 0; i < smallHistory.Count; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = smallTypeList[2];
        }

        for (int i = 0; i < Game_2Controller.currentElemNomber; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = smallTypeList[Game_2Controller.coinFlipList[i]];
        }

        if (Game_2Controller.currentElemNomber < 9)
        {
            print(Game_2Controller.currentElemNomber);
            smallHistory[Game_2Controller.currentElemNomber].GetComponent<Image>().sprite = smallTypeList[3];
        }
    }

    public void fullWinGame_2()
    {
        allWinGame_2.gameObject.SetActive(false);

        collectNowGame_2.gameObject.SetActive(false);
        playGame_2.gameObject.SetActive(true);
        setUpGame_2();
        //ControllReserses.changeCoinsValue(Config.posibleWin);


        Config.posibleWin = Config.currentStavka;
        updateText();
        Game_2Controller.coinFlipList.Clear();
        Game_2Controller.currentElemNomber = 0;


        //winCastle.SetActive(true);

        Config.posibleWin = 0;

        if (Config.IsWonGame_2 == false)
        {
            Config.AchivmentsControll.upAchivka(1);
        }

        Config.IsWonGame_2 = true;
        Config.SaveGame();
    }

    public void collectCoinsGame_2()
    {
        if (Config.currentActiveStringGame_2 == 0)
        {
            return;
        }

        allWinGame_2.gameObject.SetActive(false);

        collectNowGame_2.gameObject.SetActive(false);
        playGame_2.gameObject.SetActive(true);
        setUpGame_2();
        ControllReserses.changeCoinsValue(Config.posibleWin);


        Config.posibleWin = Config.currentStavka;
        updateText();
        Game_2Controller.coinFlipList.Clear();
        Game_2Controller.currentElemNomber = 0;


        //winCastle.SetActive(true);

        Config.posibleWin = 0;

        if (Config.IsWonGame_2 == false)
        {
            Config.AchivmentsControll.upAchivka(1);
        }

        Config.IsWonGame_2 = true;
        Config.SaveGame();
        DrawLineValueButton2();

    }


    public void LoseGame_2()
    {
        //allElemScroll.gameObject.SetActive(false);

        bigUnknow.GetComponent<Image>().sprite =
            bigTypeList[Game_2Controller.coinFlipList[Game_2Controller.currentElemNomber]];
        plashka.gameObject.SetActive(false);
        Lose.gameObject.SetActive(true);
        waitingResult.text = "Not a coincidence";

        playAgain.gameObject.SetActive(true);
        collectNow.gameObject.SetActive(false);

        plusStavkaCastle.gameObject.SetActive(true);
        minusStavkaCastle.gameObject.SetActive(true);
        //allElemScroll.gameObject.SetActive(false);
    }


    public void WinFullGame_2()
    {
        print("!!!!!!!!!!!!!");
        plashka_2.gameObject.SetActive(false);
        plashka.SetActive(false);
        allWinGame_2.gameObject.SetActive(true);

        playAgain.gameObject.SetActive(false);
        collectNow.gameObject.SetActive(false);

        plusStavkaCastle.gameObject.SetActive(false);
        minusStavkaCastle.gameObject.SetActive(false);
        waitingResult.gameObject.SetActive(false);
        allElemScroll.gameObject.SetActive(false);

        smallHistory[8].GetComponent<Image>().sprite = smallTypeList[Game_2Controller.coinFlipList[8]];
        bigUnknow.GetComponent<Image>().sprite = bigTypeList[Game_2Controller.coinFlipList[8]];


        print(Config.currentActiveStringGame_2 + "!!!");
        Config.posibleWin = Config.currentStavka * Config.percentList[Config.currentActiveStringGame_2 - 1];

        Config.currentActiveStringGame_2 = 0;
        updateText();
        infoRound.text = $"Round {Game_2Controller.currentElemNomber + 1} /9";

        for (int i = 0; i < Game_2Controller.currentElemNomber + 1; i++)
        {
            smallHistory[i].GetComponent<Image>().sprite = smallTypeList[ /*Game_2Controller.coinFlipList[i]*/ 1];
        }

        finalReward.text = Config.posibleWin.ToString();
        ControllReserses.changeCoinsValue(Config.posibleWin);
        updateText();
    }

    #endregion


    public void TestONClick()
    {
        Config.AudioSource.GetComponent<AudioSource>().Play();
    }

    public void goToMEnu()
    {
        castleGame.SetActive(false);
        setUpOrderGame.SetActive(false);
        orderGame.SetActive(false);
        winCastle.SetActive(false);
        loseCastle.SetActive(false);
        winORDER.SetActive(false);
        loseORDER.SetActive(false);

        Menu.SetActive(true);
    }

    public void needBuyCoins()
    {
        buyCoins.SetActive(true);
    }

    public void needBuyHearts()
    {
        buyHearts.SetActive(true);
    }

    #region CASTLE

    public void setUpCastle(bool freeVhod)
    {
        if (Config.currentStavka > Config.coins)
        {
            Config.currentStavka = Config.coins;
        }

        if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
        {
            buyCoins.SetActive(true);
            return;
        }

        updateText();
        whitePole.SetActive(true);
        if (freeVhod)
        {
            startCastle.gameObject.SetActive(true);
            playAgain.gameObject.SetActive(false);
        }
        else
        {
            if (!ControllReserses.isPosibleChangeHearts(-1))
            {
                buyHearts.SetActive(true);
                return;
            }

            startCastle.gameObject.SetActive(true);
            playAgain.gameObject.SetActive(false);
            ControllReserses.changeHeartsValue(-1);
        }

        plusStavkaCastle.gameObject.SetActive(true);
        minusStavkaCastle.gameObject.SetActive(true);
        valueStavkaCastle.gameObject.SetActive(true);

        collectNow.gameObject.SetActive(false);
        valueIfWinCastle.gameObject.SetActive(false);

        winCastle.SetActive(false);
        loseCastle.SetActive(false);
    }

    public GameObject fonKastl;

    public void startGameCastle(bool isNeedToPay)
    {
        if (Config.currentStavka <= 0 || Config.currentStavka > Config.coins)
        {
            return;
        }

        fonKastl.GetComponent<ImageKost>().StartGame(fonKastl);
        Config.posibleWin = Config.currentStavka;
        updateText();
        if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
        {
            buyCoins.SetActive(true);
            return;
        }

        if (isNeedToPay)
        {
            if (!ControllReserses.isPosibleChangeHearts(-1))
            {
                buyHearts.SetActive(true);
                return;
            }

            if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
            {
                buyCoins.SetActive(true);
                return;
            }

            ControllReserses.changeHeartsValue(-1);


            //print(Config.coins);
            //print(Config.hearts);
        }


        ControllReserses.changeCoinsValue(-Config.currentStavka);

        whitePole.SetActive(false);
        collectNow.gameObject.SetActive(true);
        GridControllCastle.startGame();


        //collectNow.gameObject.SetActive(true);////!!!! ������ �����
        valueIfWinCastle.gameObject.SetActive(true);


        playAgain.gameObject.SetActive(false);
        startCastle.gameObject.SetActive(false);
        valueStavkaCastle.gameObject.SetActive(false);
        plusStavkaCastle.gameObject.SetActive(false);
        minusStavkaCastle.gameObject.SetActive(false);
        valueStavkaCastle.gameObject.SetActive(false);
    }


    public void backAnim()
    {
        Config.gridAnimator.GetComponent<Animator>().SetBool("BackUp", true);
    }


    public void loseCastleGame()
    {
        updateText();
        loseCastle.SetActive(true);
    }

    public void changeStavka(int i)
    {
        if (Config.currentStavka > Config.coins)
        {
            Config.currentStavka = Config.coins;
        }

        if (Config.currentStavka + (10 * i) < 0 || Config.currentStavka + (10 * i) > Config.coins)
        {
            return;
        }
        //if (ControllReserses.isPosibleChangeCoins(StaticConfig.currentStavka +(10*i), 1))
        //{

        //}
        Config.currentStavka += 10 * i;
        //print(Config.currentStavka + (10 * i));

        updateText();
    }

    public void changeStavka_2(int i)
    {
        if (Config.currentStavka > Config.coins)
        {
            Config.currentStavka = Config.coins;
        }

        if (Config.currentStavka + (10 * i) <= 0 || Config.currentStavka + (10 * i) > Config.coins)
        {
            return;
        }
        //if (ControllReserses.isPosibleChangeCoins(StaticConfig.currentStavka +(10*i), 1))
        //{

        //}
        Config.currentStavka += 10 * i;
        //print(Config.currentStavka + (10 * i));
        Config.posibleWin = 2 * (Config.diffictly + 1) * Config.currentStavka;
        updateText();
    }

    #endregion

    #region ORDER

    public void setUpORDERGame()
    {
        if (Config.currentStavka > Config.coins)
        {
            Config.currentStavka = Config.coins;
        }

        updateText();
        setUpOrderGame.SetActive(true);

        Menu.SetActive(false);
        orderGame.SetActive(false);
        loseORDER.SetActive(false);
        winORDER.SetActive(false);
    }

    public void startGameOrder()
    {
        if (Config.currentStavka <= 0)
        {
            return;
        }

        updateText();
        if (!ControllReserses.isPosibleChangeHearts(-1))
        {
            buyHearts.SetActive(true);
            return;
        }

        if (!ControllReserses.isPosibleChangeCoins(Config.currentStavka))
        {
            buyCoins.SetActive(true);
            return;
        }

        ControllReserses.changeHeartsValue(-1);
        ControllReserses.changeCoinsValue(-Config.currentStavka);
        Config.gridOrderScript.startGame(Config.diffictly + 1);
        Menu.SetActive(false);
        setUpOrderGame.SetActive(false);
        orderGame.SetActive(true);
    }


    public void loseORDEReGame()
    {
        loseORDER.SetActive(true);
    }

    public void winORDERGame()
    {
        ControllReserses.changeCoinsValue(Config.posibleWin);
        updateText();

        winORDER.SetActive(true);
        Config.posibleWin = 0;

        if (Config.IsWonOrderGame == false)
        {
            Config.AchivmentsControll.upAchivka(1);
        }

        Config.IsWonOrderGame = true;
        Config.SaveGame();
    }

    #endregion

    public void BuyCoin(int valueByuCoin)
    {
        ControllReserses.changeCoinsValue(valueByuCoin);
        Config.AchivmentsControll.upAchivka(2);
    }

    public void BuyHearth(int valueByuHearth)
    {
        ControllReserses.changeHeartsValue(valueByuHearth);
    }

    public void BuyFiveHearth()
    {
        if (ControllReserses.isPosibleChangeCoins(-100))
        {
            ControllReserses.changeCoinsValue(-100);
            ControllReserses.changeHeartsValue(5);
        }
    }

    public void updateText()
    {
        subl.text = "+ " + Config.posibleWin.ToString();
        valueIfWinCastle.text = Config.posibleWin.ToString();


        valueStavkaGAME_1.text = Config.currentStavka.ToString();


        valueStavkaORDER.text = Config.currentStavka.ToString();


        valueStavkaCastle.text = Config.currentStavka.ToString();
        WinGameValueTxt.text = Config.posibleWin.ToString();
        valueIfWinORDER.text = Config.posibleWin.ToString();

        valueIfWinGAME_1.text = Config.posibleWin.ToString();

        OrderSetUpCoins.text = "In stock " + Config.coins.ToString();

        mainWindowCoins.text = Config.coins.ToString();
        mainWindowHearts.text = Config.hearts.ToString();
    }

    public void updateValueResurses()
    {
        mainWindowCoins.text = Config.coins.ToString();
        mainWindowHearts.text = Config.hearts.ToString();
    }
}