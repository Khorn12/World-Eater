using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    bool fix = false;
    public Animator playerAnim;
    public RuntimeAnimatorController playerContr;
    public PlayableDirector director;

    // Start is called before the first frame update
    void OnEnable()
    {
        playerContr = playerAnim.runtimeAnimatorController;
        playerAnim.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
          fix = true;
          playerAnim.runtimeAnimatorController = playerContr;
        }
    }
}
