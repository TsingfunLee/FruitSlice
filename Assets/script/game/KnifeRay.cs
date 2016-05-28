using UnityEngine;
using System.Collections;

public class KnifeRay : MonoBehaviour
{
    public GameObject myRay;      // 刀光的prefab

    // 刀光的位置
    private Vector3 firstPosition;
    private Vector3 secondPosition;
    public Vector3 rayPosition;

    private GameObject rayGameObject;

    // 水果被切脚本
    HitByKnife hitByKnife;

    void Start()
    {
        hitByKnife = GameObject.Find("Fruit").GetComponent<HitByKnife>();
    }

    // Update is called once per frame
    void Update()
    {
        // 鼠标按下
        if (Input.GetMouseButtonDown(0))
        {
            //屏幕坐标转化成空间坐标
            firstPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2));
        }

        // 鼠标提起
        if (Input.GetMouseButtonUp(0))
        {
            secondPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -2));

            if (!hitByKnife.isHited)
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

            // 创建刀光
            rayGameObject = Instantiate(myRay, rayPosition, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward)) as GameObject;

            // 如果水果被切，创建被切的水果
            if (hitByKnife.isHited)
            {
                hitByKnife.SliceFruit();
                hitByKnife.isHited = false;
            }

            // 一秒后销毁刀光
            Destroy(rayGameObject, 1.0f);
        }
    }
}
