using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PacmanGame : MonoBehaviour
{
    public GameObject uiIntro;
    public GameObject uiGameOver;
    public GameObject uiGameWin;
    public GameObject uiGameStatus;
    public TextMeshProUGUI uiBeanCount;
    public GameObject beanCollection;

    private int _beanCount;
    private static PacmanGame _instance;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        uiGameStatus.SetActive(true);
        uiIntro.SetActive(false);
        _beanCount = beanCollection.transform.childCount;
        uiBeanCount.text = _beanCount.ToString();
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        uiGameOver.SetActive(true);
    }

    public void OnEatingBean()
    {
        _beanCount--;
        uiBeanCount.text = _beanCount.ToString();
        if(_beanCount <= 0)
        {
            Time.timeScale = 0f;
            uiGameWin.SetActive(true);
        }
    }

    public static PacmanGame instance
    {
        get
        {
            return _instance;
        }
    }
    
}
