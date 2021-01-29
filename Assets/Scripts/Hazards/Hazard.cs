using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] CharacterController hazardController;
    [SerializeField] GameObject waypointHolder;
    [SerializeField] int waypointTotal;
    [SerializeField] Transform[] waypoints;
    [SerializeField] int currentWaypointID = 1;
    [SerializeField] Transform currentWapoint;
    private void Start()
    {
        hazardController = GetComponent<CharacterController>();
        waypoints = waypointHolder.GetComponentsInChildren<Transform>();
        currentWapoint = waypoints[currentWaypointID];
        print(waypoints.Length);
    }
    void Update()
    {
        hazardController.Move((currentWapoint.position - transform.position).normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWapoint.position) < 0.2f)
        {
            currentWaypointID++;
            if (currentWaypointID > waypoints.Length - 1) currentWaypointID = 1;
            currentWapoint = waypoints[currentWaypointID];
        }
    }
    private void OnTriggerEnter(Collider Enter) { if (Enter.gameObject.tag == "DinoPlayer") currentWapoint = Enter.gameObject.transform; speed = 2; }
    private void OnTriggerStay(Collider Stay) { if (Stay.gameObject.tag == "DinoPlayer") currentWapoint = Stay.gameObject.transform; speed = 2; }
    private void OnTriggerExit(Collider Exit) { if (Exit.gameObject.tag == "DinoPlayer") currentWapoint = waypoints[currentWaypointID]; speed = 1.5f; }
}
