using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutsceneControl : MonoBehaviour
{
    [SerializeField] private CutsceneQueue queue;
    [SerializeField] private PlayableDirector director;

    // Start is called before the first frame update
    private void Start()
    {
        //you can start the cutscene when LevelStart OR LevelFinish OR PuzzleStart OR PuzzleFinish
        //Enum for state of game cutscene to play
        //Switch() or If() STATEMENTS

        GameManager.Singleton.OnLevelStart.AddListener(PlayCutscene);
    }


    public void PlayCutscene()
    {
        director.Play();
    }

    public virtual void OnCutsceneEnter()
    {
        //Lock player
        
        GameManager.Singleton.LockPlayer(true);
    }

    public virtual void OnCutsceneFinish()
    {
        //Unlock Player
        GameManager.Singleton.OnLevelStart.RemoveListener(PlayCutscene);
        GameManager.Singleton.LockPlayer(false);
        Destroy(gameObject);
    }

    public enum CutsceneQueue
    {
        OnLevelStart, OnLevelFinished, OnPuzzleStart, OnPuzzleFinished
    }

}
