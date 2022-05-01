using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnDarkObjectScript : ReactNearSphereObjectScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GuideManager guideManager = GuideManager.GetInstance();
        bool isInGuideRange = IsInGuideRange(false);
        objectCollider.isTrigger = isInGuideRange;
        model.SetActive(!isInGuideRange);
    }
}
