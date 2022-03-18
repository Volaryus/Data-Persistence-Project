using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public InputField input;
    public string nickName;
    // Start is called before the first frame update
    public static MenuManager Instance;

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        nickName = input.text;
        Debug.Log(nickName);
        SceneManager.LoadScene(1);
    }
}
