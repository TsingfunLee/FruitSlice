using UnityEngine;
using System.Collections;

public class KnifeRay : MonoBehaviour
{
    // 刀光的prefab
    public GameObject knifeRay;

    // 刀光的位置
    private Vector3 firstPosition;
    private Vector3 secondPosition;
    public Vector3 rayPosition;

    // 刀光的实例
    private GameObject knifeRayObj;

    // Slash prefab
    public GameObject slash;
    public GameObject slashH;
    public GameObject slashV;

    // Slash Instance
    private GameObject slashObj;
    private GameObject slashHObj;
    private GameObject slashVObj;

    // 被切水果
    [HideInInspector]
    public GameObject fruitSliced;

    // gold fruit
    public GameObject goldFruit;
    GameObject goldFruitObj;

    // Score
    Score score;

    void Start()
    {
        score = GameObject.Find("UI/Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // 鼠标按下
        if (Input.GetMouseButtonDown(0))
        {
            //屏幕坐标转化成空间坐标
            firstPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1));
        }

        // 鼠标提起
        if (Input.GetMouseButtonUp(0))
        {
            secondPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1));

            if (fruitSliced == null)
            {
                rayPosition = (firstPosition + secondPosition) / 2;
            }

            float angle = 0;

            // 计算刀光倾斜的角度
            if (secondPosition.x != firstPosition.x)
            {
                angle = Mathf.Atan((secondPosition.y - firstPosition.y) / (secondPosition.x - firstPosition.x));
            }
            else
            {
                angle = Mathf.PI / 2;
            }
            // 当第一点和第二点不重合的时候
            if (secondPosition.x != firstPosition.x || firstPosition.y != secondPosition.y)
            {
                rayPosition.z = -1;
                // 创建刀光
                knifeRayObj = Instantiate(knifeRay, rayPosition, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward)) as GameObject;

                // 如果水果被切，创建被切的水果
                if (fruitSliced != null)
                {
                    // 创建Slash
                    if (angle > 0 && angle < Mathf.PI / 6 || angle > -Mathf.PI / 6 && angle < 0)
                    {
                        slashHObj = Instantiate(slashH, rayPosition + new Vector3(1f, 0, 0), Quaternion.identity) as GameObject;
                        SetColor(slashHObj);
                        Destroy(slashHObj, 1f);
                    }
                    else if (angle > Mathf.PI / 3 && angle < Mathf.PI / 2 || angle > -Mathf.PI / 2 && angle < -Mathf.PI / 3)
                    {
                        slashVObj = Instantiate(slashV, rayPosition + new Vector3(1f, 0, 0), Quaternion.identity) as GameObject;
                        SetColor(slashVObj);
                        Destroy(slashVObj, 1f);
                    }
                    else
                    {
                        slashObj = Instantiate(slash, rayPosition + new Vector3(1f, 0, 0), Quaternion.identity) as GameObject;
                        SetColor(slashObj);
                        Destroy(slashObj, 1f);
                    }

                    // 如果不是田鼠，加分
                    if (fruitSliced.name != "hamster000(Clone)")
                    {
                        // 如果是金色苹果，创建金色水果
                        if (fruitSliced.name == "goldApple00(Clone)")
                        {
                            goldFruitObj = Instantiate(goldFruit, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

                            Destroy(goldFruitObj, 1f);

                            score.AddGoldScore();
                        }
                        else
                        {
                            score.AddScore();
                        }
                    }


                    // 创建被切的水果
                    fruitSliced.GetComponent<HitByKnife>().isHited = false;
                    fruitSliced.GetComponent<HitByKnife>().SliceFruit();
                }

                // 一秒后销毁刀光
                Destroy(knifeRayObj, 1.0f);
            }
        }
    }

    // set random color for slash
    void SetColor(GameObject slash)
    {
        if (fruitSliced.name == "apple00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if (fruitSliced.name == "banana00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (fruitSliced.name == "goldApple00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (fruitSliced.name == "hamster000(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (fruitSliced.name == "kiwi00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else if (fruitSliced.name == "pear00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (fruitSliced.name == "waterMelon00(Clone)")
        {
            slash.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
