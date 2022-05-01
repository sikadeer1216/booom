using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactNearSphereObjectScript : MonoBehaviour
{
    public Collider objectCollider;
    public GameObject model;
    protected bool IsInGuideRange(bool shouldLightBeEnabled) {
        GuideManager guideManager = GuideManager.GetInstance();
        if (guideManager.guideState != GuideState.SPHERE) return false;
        GuideScript guide = guideManager.guide;
        return ((guide.currentGuideRigidBody.position - transform.position).magnitude <= guideManager.lightDistance)
            && guide.sphere.lightSource.enabled == shouldLightBeEnabled;
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
