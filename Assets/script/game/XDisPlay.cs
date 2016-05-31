using UnityEngine;
using System.Collections;

public class XDisPlay : MonoBehaviour
{
    public Color myColor;

    public int life = 5;

    public GameObject[] X;

    // Update is called once per frame
    void Update()
    {
        if (life < 5 && life >= 0)
        {
            for (int i = life; i < 5; i++)
            {
                X[i].GetComponent<SpriteRenderer>().color = myColor;
            }

            if (life == 0)
            {
                Application.LoadLevel(3);
            }
        }

        if (life < 0)
        {
            X[4].GetComponent<SpriteRenderer>().color = myColor;

            Application.LoadLevel(3);
        }
    }
}
