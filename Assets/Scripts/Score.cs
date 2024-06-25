using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text Marble;
    public TMP_Text CatDieTxt;
    private int catDie;
    public int CatDieScore { get { return catDie; } set { catDie = value; } }
    private int fallCount;
    public int FallCount
    {
        get { return fallCount; }
        set { fallCount = value; }
    }
    private int marbleScore;
    public int MarbleScore
    {
        get { return marbleScore; }
        set { marbleScore = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (CatDieTxt != null)
        {
            CatDieTxt.text = "Nests Saved:" + CatDieScore.ToString();
        }
       // else { CatDieTxt.gameObject.SetActive(false); }
        if (ScoreText != null)
        {
            ScoreText.text = "Fall count:" + FallCount.ToString();
        }
       // else { ScoreText.gameObject.SetActive(false); }
        if (Marble != null)
        {
            Marble.text = "Objects used:" + MarbleScore.ToString();
        }
        //else { Marble.gameObject.SetActive(false); }
    }
    public void ScoreUpdate()
    {
        if (CatDieTxt != null)
        {
            CatDieTxt.text = "Nests Saved:" + CatDieScore.ToString();
        }
        if (ScoreText != null)
        {
            ScoreText.text = "Fall count:" + FallCount.ToString();
        }
        if (Marble != null)
        {
            Marble.text = "Objects used:" + MarbleScore.ToString();
        }
    }
}
