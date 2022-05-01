using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HandState {
    Upright,
    Platform
}
public class HandScript : MonoBehaviour
{
    public HandState state;
    public MeshRenderer meshRenderer;
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public Vector3 uprightRot;
    public Vector3 platformRot;
    // Start is called before the first frame update
    private void TurnToUpright() {
        rb.rotation = Quaternion.Euler(uprightRot);
        gameObject.layer = LayerMask.NameToLayer("Hand Upright");
        state = HandState.Upright;
    }

    private void TurnToPlatform() {
        rb.rotation = Quaternion.Euler(platformRot);
        gameObject.layer = LayerMask.NameToLayer("Default");
        state = HandState.Platform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!meshRenderer.enabled) return;
        if (state == HandState.Upright && Input.GetMouseButtonDown(1)) {
            TurnToPlatform();
        } else if (state == HandState.Platform && Input.GetMouseButtonDown(0)) {
            TurnToUpright();
        }
    }
}
