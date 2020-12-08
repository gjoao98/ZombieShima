using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWall2 : MonoBehaviour
{
    [SerializeField]
    Transform Target, Obstruction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }
    }
}
