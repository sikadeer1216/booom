using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public Rigidbody currentGuideRigidBody;
    public SphereScript sphere;
    public HandScript hand;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GuideManager guideManager = GuideManager.GetInstance();
        if (Input.GetKeyDown(KeyCode.F)) {
            GuideManager.SwitchState();
            if (GuideManager.guideState == GuideState.SPHERE) {
                hand.gameObject.SetActive(false);
                sphere.gameObject.SetActive(true);
                currentGuideRigidBody = sphere.GetComponent<Rigidbody>();
            } else {
                sphere.gameObject.SetActive(false);
                hand.gameObject.SetActive(true);
                currentGuideRigidBody = hand.GetComponent<Rigidbody>();
            }
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePosition.z = transform.position.z;
        currentGuideRigidBody.position = Vector3.MoveTowards(currentGuideRigidBody.position, mousePosition, speed * Time.deltaTime);
    }
}
