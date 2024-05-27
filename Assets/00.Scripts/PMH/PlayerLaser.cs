using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private LineRenderer playerLaser;
    [SerializeField] private GameObject mainCam;

    [Header("Values")]
    [SerializeField] private float laserDistance;
    [SerializeField] private LayerMask whatIsObstacle;

    private void Update()
    {
        ShootingLaser();
    }

    private void ShootingLaser()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(mainCam.transform.position, transform.forward, laserDistance, whatIsObstacle))
            {
                Debug.Log("��");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(mainCam.transform.position, transform.forward * laserDistance);
=======
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
>>>>>>> Stashed changes
    }
}
