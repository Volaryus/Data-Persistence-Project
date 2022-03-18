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
    MainManager mainManager;
    MenuManager menuManager;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        Text child = Instantiate(highScoreText, new Vector3(150, 150, 0), highScoreText.transform.rotation);
        child.transform.parent = canvas.transform;


    }
    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainManager.m_Points>highScore)
        {
            highScore = mainManager.m_Points;
        }
        highScoreText.text = "Best Score:"+ menuManager.nickName+"  "+highScore;
    }
    
}
