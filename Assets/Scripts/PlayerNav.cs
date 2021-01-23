using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script defining a player's movement
public class PlayerNav : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    public CharStats stats;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//&& hit.collider.gameObject.name.Contains("Terrain"))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

}
