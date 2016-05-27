using UnityEngine;
using System.Collections;

public class KnifeRay : MonoBehaviour {

    //选择颜色
    //public Color mycolor;

    public GameObject myRay;  //这个是刀光的prefab

    private Vector3 firstPosition;
    private Vector3 secondPosition;
    private Vector3 middlePosition;

    private bool isClicked = false;

    private LineRenderer lineRenderer;

    private GameObject rayGameObject;

     //Use this for initialization
        //void Start () {
        //    lineRenderer = gameObject.AddComponent<LineRenderer>();//添加一个划线的组件
        //    //设置颜色和宽度
        //    lineRenderer.material.color = mycolor;
        //    lineRenderer.SetWidth(0.1f, 0.1f);
        //}

    // Update is called once per frame
    void Update()
    {

        bool isMouseDown = Input.GetMouseButton(0);//判断鼠标是否左击

        if (isMouseDown && !isClicked)
        {
            //屏幕坐标转化成空间坐标
            firstPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            //lineRenderer.SetVertexCount(1);

            //lineRenderer.enabled = true;
            //lineRenderer.SetPosition(0, firstPosition);

            isClicked = true;
        }

        else if (isMouseDown)
        {
            secondPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            //lineRenderer.SetVertexCount(2);

            //lineRenderer.SetPosition(1, secondPosition);
        }

        //鼠标提起
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;

            secondPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            //lineRenderer.SetVertexCount(2);

            //lineRenderer.SetPosition(1, secondPosition);


            middlePosition = (firstPosition + secondPosition) / 2;

            float angle = Mathf.Atan((secondPosition.y - firstPosition.y) / (secondPosition.x - firstPosition.x));
            //创建划痕,这里旋转的是幅度
            rayGameObject = Instantiate(myRay, middlePosition, Quaternion.AngleAxis(angle * 180 / Mathf.PI, Vector3.forward)) as GameObject;

            Destroy(rayGameObject, 1.0f);//一秒钟就去掉
        }
    }
}
