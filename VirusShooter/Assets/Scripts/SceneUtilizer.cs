using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtilizer : MonoBehaviour
{
    private static SceneUtilizer instance = null;
    public static SceneUtilizer GetInstance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
