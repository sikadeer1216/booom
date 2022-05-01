using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableScript : ClickableScript
{
    public void Break() {
        GuideManager guideManager = GuideManager.GetInstance();
        if (guideManager.guideState == GuideState.SPHERE) return;
        if (guideManager.guide.hand.state == HandState.Upright) Destroy(gameObject); // Animation?
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GuideManager guideManager = GuideManager.GetInstance();
        if (guideManager.guideState == GuideState.SPHERE) return;
        if (guideManager.guide.hand.state == HandState.Upright
            && IsClicked()
            && (guideManager.guide.handRigidBody.position - transform.position).magnitude < 1f
        ) Break();
    }
}
