using UnityEngine;

public class Score : MonoBehaviour
{
    public int puntaje;
    public int highscore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LeerScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int x)
    {
        puntaje += x;
    }

    public void CheckScore()
    {
        if(puntaje > highscore)
        {
            highscore = puntaje;
            PlayerPrefs.SetInt("high", highscore);
            PlayerPrefs.Save();
        }
    }

    public void LeerScore()
    {
        highscore = PlayerPrefs.GetInt("high");
    }
}
