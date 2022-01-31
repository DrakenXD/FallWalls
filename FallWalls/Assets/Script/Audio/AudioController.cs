using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioController : MonoBehaviour
{   
    [SerializeField] private string nameAudio = "Audio";          
    [SerializeField] private GameObject audioObject;

    [SerializeField] private Audio[] NewAudio;

    public void PlayAudio(string name){
        
        GameObject clone = Instantiate(audioObject, transform.position, Quaternion.identity);
        
        
        
        for(int i = 0; i < NewAudio.Length; i++){
            if(NewAudio[i].nameAudio == name){
                clone.gameObject.GetComponent<AudioSource>().clip = NewAudio[i].audioClip;
        
                clone.gameObject.GetComponent<AudioSource>().Play();

                if(NewAudio[i].destroy){
                   Destroy(clone,5); 
                }
            }
        }
        
        
    }
    
}
[System.Serializable]
public class Audio{
    public string nameAudio;
    public AudioClip audioClip;
    public bool destroy;
}
