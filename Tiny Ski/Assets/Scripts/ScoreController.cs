using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private int score;

    private int bestScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            score += 10;

            //score = score + 10;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            score -= 10;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CheckBestScore();
        }
    }

    private void CheckBestScore()
    {


        if (score >= PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", score);
            //bestScore = score;
            PlayerPrefs.DeleteKey("bestScore");
        }
    } 
}
