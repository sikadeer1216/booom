using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public Light lightSource;
    public MeshRenderer meshRenderer;
    public Material lightMaterial;
    public Material darkMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            lightSource.enabled ^= true;
            meshRenderer.material = lightSource.enabled ? lightMaterial : darkMaterial;
        }
    }
}
