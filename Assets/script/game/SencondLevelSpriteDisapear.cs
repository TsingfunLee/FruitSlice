using UnityEngine;
using System.Collections;

public class SencondLevelSpriteDisapear : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.4f);

        this.gameObject.SetActive(false);
    }
}
