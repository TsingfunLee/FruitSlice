using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class Score : MonoBehaviour
{
    // total score
    int totalScore = 0;
    // common fruit score
    const int score = 1;
    // gold apple score
    const int goldScore = 20;

    // num image color
    public Color myColor;
    // num image scale
    public float scale;

    // numbers images
    public Texture[] numImage;

    // total score string
    string totalScoreString;

    void Update()
    {
        if (totalScore >= 100)
        {
            if (EditorSceneManager.loadedSceneCount == 1)
            {
                EditorSceneManager.LoadScene(2);
            }
        }
    }

    public void AddScore()
    {
        totalScore += score;
    }

    public void AddGoldScore()
    {
        totalScore += goldScore;
    }

    void NumToImage()
    {
        totalScoreString = totalScore.ToString();
        int length = totalScoreString.Length;
        GUI.color = myColor;
        for (int i = 0; i < length; i++)
        {
            int index = int.Parse(totalScoreString.Substring(i, 1));
            GUI.DrawTexture(new Rect(75 + i * numImage[index].width*scale, 28, numImage[index].width * scale, numImage[index].height * scale), numImage[index]);
        }
    }

    void OnGUI()
    {
        NumToImage();
    }
}
