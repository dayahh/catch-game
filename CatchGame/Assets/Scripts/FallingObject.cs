using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioManager>();
        
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        audioManager.PlaySFX(audioManager.glitchPaintSplat);
        Destroy(this.gameObject);
    }


}
