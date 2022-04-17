using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GuideState {
    SPHERE, HAND
}
public class GuideManager : MonoBehaviour
{
    private static GuideManager instance;
    public static GuideState guideState;
    public float lightDistance;

    public GuideScript guide;

    public static void SwitchState() {
        guideState = guideState == GuideState.SPHERE ? GuideState.HAND : GuideState.SPHERE;
    }

    public static GuideManager GetInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
