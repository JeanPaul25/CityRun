using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class DayController : MonoBehaviour
{
    [SerializeField] Animator dayAnimation;
    [SerializeField] Animation[] animations;
    [SerializeField] Values posX;

    [SerializeField] AnimationClip animation;

    // Start is called before the first frame update
    void Start()
    {
        animations = Resources.LoadAll<Animation>("Animations/Builds/Build1");
    }

    // Update is called once per frame
    void Update()
    {
        //StateMachineBehaviour machineBehaviour;
        //if(Input.GetKey(KeyCode.Escape))
        //{

        //    machineBehaviour = dayAnimation.GetBehaviour<StateMachineBehaviour>();
        //    machineBehaviour.
        //}
    }

    //private void FixedUpdate()
    //{
    //    Debug.Log(posX.PoxS);
    //    if (posX.PoxS >= 100)
    //    {
    //        Debug.Log("Night");
    //        dayAnimation.SetBool("day", false);
    //    }
    //    if (posX.PoxS >= 200)
    //    {
    //        Debug.Log("Day");
    //        dayAnimation.SetBool("day", true);
    //    }
    //}
}
