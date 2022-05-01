using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsClicked() {
        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit[] hits = Physics.RaycastAll(ray);  
            foreach (RaycastHit hit in hits) {
                print("found hit");
                if (hit.collider.gameObject == gameObject) {
                    return true;
                }
            }
        }
        return false;
    }
}
