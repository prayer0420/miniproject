using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public Text levelText;
    public RectTransform levelfront;

    int level;
    int score;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Time.timeScale = 1f;

        InvokeRepeating("MakeCat", 0f, 1f);
    }

    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);
        //레벨에 따라 더 생성해주는 코드
        if (level == 1)
        {
            int p = Random.Range(0, 10);
            if(p<2)
            {
                Instantiate(normalCat);
            }
        }

        else if(level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5)
            {
                Instantiate(normalCat);
            }

        }
        else if(level == 3)
        {
             Instantiate(fatCat);
        }
        else if(level == 4)
        {
            Instantiate(pirateCat);
        }


    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelText.text = level.ToString();
        levelfront.localScale = new Vector3((score - level*5)/5.0f, 1.0f, 1.0f);
    }

}
