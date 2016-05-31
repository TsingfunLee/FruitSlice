using UnityEngine;
using System.Collections;

public class CreateFruits : MonoBehaviour
{
    public GameObject[] fruits;

    private GameObject fruitObj;

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -20, 0);

        InvokeRepeating("Create", 0, 3.0f);
    }

    void Create()
    {
        int index = Random.Range(0, 7);
        float x = Random.Range(-3, 3);

        fruitObj = Instantiate(fruits[index], new Vector3(x, -2f, 0), Quaternion.identity) as GameObject;

        if (x > 0)
        {
            fruitObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-3, 0), 11, 0);
        }
        else
        {
            fruitObj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 3), 11, 0);
        }

        fruitObj.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-120f, 120f));
    }
}
