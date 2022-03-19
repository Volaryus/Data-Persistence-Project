using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int highScore = 0;
    public Text highScoreText;
    public static BestScore Instance;
    public Canvas canvas;
    public string highName;
    MainManager mainManager;
    MenuManager menuManager;
    private void Awake()
    {
        Text child = Instantiate(highScoreText, new Vector3(1000, 1050, 0), highScoreText.transform.rotation);
        child.transform.parent = canvas.transform;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        


    }
    void Start()
    {
        InvokeRepeating("FindMainManager", 0, 5);
        FindMainManager();
       // mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        if(PlayerPrefs.GetString("HighName")!=null)
        {
            highName = PlayerPrefs.GetString("HighName");
        }
        else
        {
            highName = menuManager.nickName;
        }
      // PlayerPrefs.SetInt("HighScore", 0);

    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log(mainManager.m_Points);
        if(mainManager.m_Points>highScore)
        {
            highName = menuManager.nickName;
            highScore = mainManager.m_Points;
            Debug.Log("HighScore:" + highScore);
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetString("HighName", highName);
        }
        highScoreText.text = "Best Score: "+ highName+"  "+highScore;
    }
    void FindMainManager()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }
    
}
