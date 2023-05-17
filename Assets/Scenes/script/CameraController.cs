using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Boule;
    public float offset;
    public float offsetSmoothing;
    private Vector3 BoulePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoulePosition = new Vector3(Boule.transform.position.x, Boule.transform.position.y, transform.position.z);

        if(Boule.transform.localScale.x > 0f)
        {
            BoulePosition = new Vector3(BoulePosition.x + offset, BoulePosition.y, BoulePosition.z);
        }
        else
        {
            BoulePosition = new Vector3(BoulePosition.x - offset, BoulePosition.y, BoulePosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, BoulePosition, offsetSmoothing * Time.deltaTime);
    }
}
