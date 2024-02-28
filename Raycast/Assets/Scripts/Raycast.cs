using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            Debug.Log("Hit forward: " + hit.collider.name);
            ChangeDirection(Vector3.back);

        }

        // Cast ray forward right (45 degrees)
        Vector3 forwardRightDirection = Quaternion.Euler(0, 45, 0) * transform.forward;
        if (Physics.Raycast(transform.position, forwardRightDirection, out hit, 5f))
        {
            Debug.Log("Hit forward right: " + hit.collider.name);
            ChangeDirection(Vector3.left);
        }

        // Cast ray forward left (-45 degrees)
        Vector3 forwardLeftDirection = Quaternion.Euler(0, -45, 0) * transform.forward;
        if (Physics.Raycast(transform.position, forwardLeftDirection, out hit, 5f))
        {
            Debug.Log("Hit forward left: " + hit.collider.name);
            ChangeDirection(Vector3.right);
        }

        // Debug draw 
        Debug.DrawLine(transform.position, transform.position + transform.forward * 4f, Color.red); // Forward
        Debug.DrawLine(transform.position, transform.position + forwardRightDirection * 5f, Color.green); // Forward Right
        Debug.DrawLine(transform.position, transform.position + forwardLeftDirection * 5f, Color.blue); // Forward Left

        void ChangeDirection(Vector3 newDirection)
        {
            // Gradually rotate towards the new direction
            Quaternion targetRotation = Quaternion.LookRotation(newDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,  10000f * Time.deltaTime);
        }
    }
  }

