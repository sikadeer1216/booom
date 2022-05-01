using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GuideState {
    SPHERE, HAND
}
public class GuideManager : MonoBehaviour
{
    private static GuideManager instance;
    private GuideState _guideState;
    public GuideState guideState {
        set {
            _guideState = value;
            if (value == GuideState.SPHERE) {
                guide.hand.meshRenderer.enabled = false;
                guide.hand.boxCollider.enabled = false;
                guide.sphere.meshRenderer.enabled = true;
                guide.sphere.sphereCollider.enabled = true;
                guide.currentGuideRigidBody = guide.sphereRigidBody;
            } else {
                guide.hand.meshRenderer.enabled = true;
                guide.hand.boxCollider.enabled = true;
                guide.sphere.meshRenderer.enabled = false;
                guide.sphere.sphereCollider.enabled = false;
                guide.currentGuideRigidBody = guide.handRigidBody;
            }
        }
        get {
            return _guideState;
        }
    }
    public float lightDistance;

    public GuideScript guide;

    public void SwitchState() {
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
