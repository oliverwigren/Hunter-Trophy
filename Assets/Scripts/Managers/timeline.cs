using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timeline : MonoBehaviour
{
    public string levelName;
    public PlayableDirector director;

    // Start is called before the first frame update
    void Awake()
    {
        director.played += DirectorPlayed;
        director.stopped += DirectorStopped;
    }

    private void DirectorPlayed(PlayableDirector playable)
    {

    }
    private void DirectorStopped(PlayableDirector playable)
    {
        SceneManager.LoadScene(levelName); //Async
    }

    private void Start()
    {
        director.Play();
    }


}
