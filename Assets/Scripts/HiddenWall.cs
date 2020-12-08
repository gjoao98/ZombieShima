using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HiddenWall : MonoBehaviour
{
    [SerializeField]
    CinemachineFreeLook vcam;
    [SerializeField]
    float distanciaRaio = 6;
    int prioridadeOriginal;

    public Transform Target;

    public Transform Obstruction;
    float zoomSpeed = 2f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        prioridadeOriginal = vcam.Priority;
        Obstruction = Target;
    }

    // Update is called once per frame
    void Update()
    {
        ViewObstructed();
    }

    void ViewObstructed()
    {
        RaycastHit hit;


        Debug.DrawRay(cam.transform.position, cam.transform.forward * distanciaRaio, Color.green);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distanciaRaio))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag != "Player")
            {
                vcam.Priority = 0;
            }
            else
            {
                vcam.Priority = prioridadeOriginal;
            }
        }

    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class HiddenWall : MonoBehaviour
//{
//    [SerializeField]
//    CinemachineFreeLook vcam;

//    int prioridadeOriginal;

//    public Transform Target;

//    public Transform Obstruction;
//    float zoomSpeed = 2f;

//    Start is called before the first frame update
//    void Start()
//    {
//        prioridadeOriginal = vcam.Priority;
//        Obstruction = Target;
//    }

//    Update is called once per frame
//    void Update()
//    {
//        ViewObstructed();
//    }

//    void ViewObstructed()
//    {
//        RaycastHit hit;

//        if (Physics.Raycast(transform.position, Target.position, out hit, 4.5f))
//            Debug.DrawRay(transform.forward * -5, transform.position * 30, Color.green);
//        if (Physics.Raycast(transform.forward * -5, transform.position, out hit, 40f))
//        {
//            Debug.Log(hit.collider.gameObject.tag);
//            if(hit.collider.gameObject.tag != "Player")
//            {
//                vcam.Priority = 1000;
//                Obstruction = hit.transform;
//                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
//                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
//                {
//                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
//                }
//            }
//            else
//            {
//                vcam.Priority = prioridadeOriginal;
//                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
//                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
//                {
//                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
//                }
//            }
//        }
//    }
//}

