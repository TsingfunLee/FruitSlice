using UnityEngine;
using System.Collections;

public class HamsterSound : MonoBehaviour {

    [SerializeField] AudioClip hamsterSound;

    void Update()
    {
        if (this.GetComponent<HitByKnife>().isHited)
        {
            PlaySound();
        }
    }
	
	void PlaySound(){
        AudioSource.PlayClipAtPoint(hamsterSound,this.transform.position);
    }
}
