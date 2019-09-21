using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutterActivate : MonoBehaviour
{

    public GameObject disc;
    public GameObject discMesh;
    public Transform discMeshTransform;

    public float shrinkSize = 0.75f;

    public Renderer discRenderer;
    public Material putterMat;

    public bool putterGravityActivated;

    // Start is called before the first frame update
    void Start()
    {
        discMeshTransform = discMesh.GetComponent<Transform>();
        putterGravityActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //activates the smaller blue disc, with different physics so that its easier to shoot into the goal when close
        if (other.name == "DriverDisc:SS")
        {
            Debug.Log("disc collided");
            print(other.name);
            discMeshTransform.localScale = new Vector3(discMeshTransform.localScale.x * shrinkSize, discMeshTransform.localScale.y * shrinkSize, discMeshTransform.localScale.z);
            discRenderer.material = putterMat;
            putterGravityActivated = true;
        }
    }
}
