using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource audioSource;
    Coroutine playingRoutine = null;
    AudioClip interruptedClip = null;
    float interruptedClipTime = 0;

    // Plays the provided audio clip
    public void Play(AudioClip clip)
    {
      audioSource.Stop();
      audioSource.clip = clip;
      audioSource.Play();
    }

    // Plays the clip once and then resumes what was being played before
    public void PlayOneShot(AudioClip clip)
    {
      if (playingRoutine != null) {
        StopCoroutine(playingRoutine);
      }
      playingRoutine = StartCoroutine(_playOneShot(clip));
    }

    IEnumerator _playOneShot(AudioClip clip)
    {
      if (interruptedClip == null) {
        interruptedClip = audioSource.clip;
        interruptedClipTime = audioSource.time;
      }

      audioSource.Stop();
      audioSource.clip = clip;
      audioSource.Play();
      yield return new WaitWhile(() => audioSource.isPlaying);
      interruptedClip = null;
      playingRoutine = null;

      audioSource.clip = interruptedClip;
      audioSource.time = interruptedClipTime;
      audioSource.Play();
    }

    public static GameObject instance = null;
    // singleton
    void Awake()
    {
     GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioController");
     // note: will seppuku all if there are >1 in first game scene!
     if (objs.Length > 1 && instance != this.gameObject) {
       Destroy(this.gameObject); // seppuku
       return;
     }

     DontDestroyOnLoad(this.gameObject);
     instance = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}   
