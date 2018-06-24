using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool multiplierAdjusted = true;
    public bool clampToMesh;
    public float angle;

    public float rotateInAirSpeed;

    public float jumpMod;

    Rigidbody rb;
    Collider col;

    float prevAngle;
    float prevY;

    public LayerMask layerMask;

    public GameObject sparks;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (transform.position.y > 2) {
            multiplierAdjusted = false;
        }


        if (clampToMesh)
        {
            sparks.SetActive(true);
        } 
        else
        {
            sparks.SetActive(false);
        }

        transform.position = new Vector3(4, transform.position.y, transform.position.z);

        RaycastHit rayHit;

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out rayHit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(transform.position, rayHit.point, Color.magenta);
            angle = rayHit.normal.x;
        }

        if (clampToMesh)
        {
            transform.position = new Vector3(4, IGameManager.instance.frequency * Mathf.Sin(IGameManager.instance.frequency * transform.position.x + IGameManager.instance.meshTranslation + IGameManager.instance.translationMod), 0);

            if (angle > 0) {
                IGameManager.instance.speed += IGameManager.instance.speedMod * Time.deltaTime;
                if (!multiplierAdjusted) {
                    IScoreCounter.instance.IncrementMultiplier();
                    multiplierAdjusted = true;
                }
            }
            if (angle < 0 && transform.position.y > 0.5f)
            {
                clampToMesh = false;

                Vector3 velocityUp = Vector3.up * IGameManager.instance.speed * jumpMod;
                if (velocityUp.magnitude < 5)
                {
                    velocityUp = Vector3.up * 5;
                }

                rb.velocity = velocityUp;

                IScoreCounter.instance.UpdateScore(Mathf.RoundToInt(IGameManager.instance.speed/5)*10);

                col.enabled = false;
                if (!multiplierAdjusted) {
                    IScoreCounter.instance.DecrementMultiplier();
                    multiplierAdjusted = true;
                }
                
            }

            if (angle < 0)
            {
                if (!multiplierAdjusted && col.enabled == true) {
                    IScoreCounter.instance.ResetMultiplier();
                }
                IGameManager.instance.speed -= IGameManager.instance.speedMod * Time.deltaTime;

                if (IGameManager.instance.speed < 1)
                {
                    IGameManager.instance.speed = 1;
                }
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle * 45);
        }
        else if (transform.eulerAngles.z < 45 || transform.eulerAngles.z > 300)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotateInAirSpeed * Time.deltaTime);
        }

        if (!col.enabled && transform.position.y < prevY)
        {
            col.enabled = true;
        }

        if (!col.enabled && transform.position.y > 2)
        {
            col.enabled = true;
        }

        if (transform.position.y < -2)
        {
            transform.position = new Vector3(transform.position.x, 1, 0);
        }

        prevAngle = angle;
        prevY = transform.position.y;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Collectible")
        {
            RaycastHit rayHit;

            if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out rayHit, Mathf.Infinity, layerMask))
            {
                angle = rayHit.normal.x;

                if (!clampToMesh && angle < 0)
                {
                    IGameManager.instance.speed /= 2;
                }
                clampToMesh = true;
            }
        }
    }
}