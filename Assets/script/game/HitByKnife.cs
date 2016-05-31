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

    // fallSound audio
    AudioClip fallSound;

    // 刀光脚本
    KnifeRay knifeRay;

    // 是否被切
    [HideInInspector]
    public bool isHited = false;

    // Xred Prefab
    public GameObject Xred;
    // Xred Instance
    GameObject XredObj;

    // XDisPlay Script
    XDisPlay xDisPlay;

    // Use this for initialization
    void Start()
    {
        knifeRay = GameObject.Find("KnifeRay").GetComponent<KnifeRay>();

        fallSound = this.GetComponent<AudioSource>().clip;

        xDisPlay = GameObject.Find("UI/Score/Life").GetComponent<XDisPlay>();
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
                if (hit.collider.name == this.gameObject.name)
                {
                    isHited = true;
                    knifeRay.rayPosition = hit.transform.position;
                    knifeRay.fruitSliced = this.gameObject;
                }
            }
        }

        PlaySound();
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

    void PlaySound()
    {
        if (this.transform.position.y < -2 && this.gameObject.name != "hamster000(Clone)")
        {
            AudioSource.PlayClipAtPoint(fallSound, this.transform.position);

            // display red X leftdown
            XRed();

            // life - 1
            xDisPlay.life--;

            DestroyImmediate(this.gameObject);
        }
    }

    void XRed()
    {
        XredObj = Instantiate(Xred, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(XredObj, 1f);
    }
}
