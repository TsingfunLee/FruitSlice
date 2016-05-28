using UnityEngine;
using System.Collections;

public class HitByKnife : MonoBehaviour
{
    // 被切水果的prefab
    public GameObject fruitSliced1;
    public GameObject fruitSliced2;
    // 被切水果的实例
    GameObject fruitSlicedObj1;
    GameObject fruitSlicedObj2;

    // 刀光脚本
    KnifeRay knifeRay;

    // 是否被切
    [HideInInspector] public bool isHited = false;

    // Use this for initialization
    void Start()
    {
        knifeRay = GameObject.Find("KnifeRay").GetComponent<KnifeRay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // 用射线判断是否被切，被切后将切点位置赋给刀光的位置
            if (Physics.Raycast(ray, out hit))
            {
                isHited = true;
                knifeRay.rayPosition = hit.transform.position;
            }
        }
    }

    // 被切后飞出的水果
    public void SliceFruit()
    {
        fruitSlicedObj1 = Instantiate(fruitSliced1, this.transform.position, Quaternion.AngleAxis(Random.Range(0, 50), Vector3.forward)) as GameObject;
        fruitSlicedObj2 = Instantiate(fruitSliced2, this.transform.position, Quaternion.AngleAxis(Random.Range(-50, 0), Vector3.forward)) as GameObject;

        // 使水果被切后飞出的位置有些变化
        if (Random.Range(0, 10) < 5)
        {
            fruitSlicedObj1.GetComponent<Rigidbody>().velocity = new Vector2(-5, 10);
            fruitSlicedObj2.GetComponent<Rigidbody>().velocity = new Vector2(8, 10);
        }
        else
        {
            fruitSlicedObj1.GetComponent<Rigidbody>().velocity = new Vector2(8, 10);
            fruitSlicedObj2.GetComponent<Rigidbody>().velocity = new Vector2(-5, 10);
        }

        // 销毁
        Destroy(fruitSlicedObj1, 2f);
        Destroy(fruitSlicedObj2, 2f);

        DestroyImmediate(this.gameObject);
    }
}
