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
            CatDieTxt.text = "cat killed:" + CatDieScore.ToString();
        }
        else { CatDieTxt.gameObject.SetActive(false); }
        if (ScoreText != null)
        {
            ScoreText.text = "fall count:" + FallCount.ToString();
        }
        else { ScoreText.gameObject.SetActive(false); }
        if (Marble != null)
        {
            Marble.text = "marble fall:" + MarbleScore.ToString();
        }
        else { Marble.gameObject.SetActive(false); }
    }
    public void ScoreUpdate()
    {
        if (CatDieTxt != null)
        {
            CatDieTxt.text = "cat killed:" + CatDieScore.ToString();
        }
        if (ScoreText != null)
        {
            ScoreText.text = "fall count:" + FallCount.ToString();
        }
        if (Marble != null)
        {
            Marble.text = "marble fall:" + MarbleScore.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
