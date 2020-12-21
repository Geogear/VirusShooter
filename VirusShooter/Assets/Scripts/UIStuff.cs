using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{
    int score = 0;
    public Text Score;
    public Image[] lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore()
    {
        string tmp = "000" + score.ToString();
        while (tmp.Length > 4)
        {
            tmp.Remove(0);
        }
        Score.text = tmp;
    }

    public void increaseScore()
    { 
        ++score;
        setScore();
    } 

    public int getScore() { return score; }   

    public void updateLives(int curLives)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < curLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }

}
