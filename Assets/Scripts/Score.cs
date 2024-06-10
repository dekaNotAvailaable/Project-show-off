using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public int scoreInt = 10;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
