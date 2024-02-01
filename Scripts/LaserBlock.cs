using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LaserBlock : MonoBehaviour
{
    public bool isHorizontal = false;
    Vector2 origPos;
    Vector2 origScale;
    // Start is called before the first frame update
    void Start()
    {
        origPos = new Vector2(transform.position.x, transform.position.y);
        origScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Box")) {
            /*
            float y = origPos.y;
            float scale = GetComponent<BoxCollider2D>().size.x;
            float topEdge = collider.transform.position.y - collider.GetComponent<BoxCollider2D>().size.y/2 + 0.7f;
            transform.position = new Vector2(transform.position.x, y - (y + scale - topEdge));
            */
            if (!isHorizontal)
            {
                float bottomEdge = origPos.y - ((origScale.y * GetComponent<BoxCollider2D>().size.y) / 2.0f);
                Debug.Log("Bottom Edge: " + bottomEdge);
                float topEdge = collider.transform.position.y - collider.GetComponent<BoxCollider2D>().size.y / 2 + 0.7f;
                Debug.Log("Top Edge: " + topEdge);
                transform.position = new Vector3(transform.position.x, (bottomEdge + topEdge) / 2.0f - 0.1f, transform.position.z);
                float yScale = Math.Abs(topEdge - bottomEdge) / (GetComponent<BoxCollider2D>().size.y * transform.localScale.y);
                Debug.Log("Scale: " + yScale);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * yScale, transform.localScale.z);
            }
            else
            {
                float rightEdge = transform.position.x + (transform.localScale.y * GetComponent<BoxCollider2D>().size.y) / 2.0f;
                float leftEdge = collider.transform.position.x + (collider.GetComponent<BoxCollider2D>().size.x * collider.transform.localScale.x) / 2 - 0.6f;
                transform.position = new Vector3((rightEdge + leftEdge) / 2.0f, transform.position.y, transform.position.z);
                float yScale = Math.Abs(leftEdge - rightEdge) / (GetComponent<BoxCollider2D>().size.y * transform.localScale.y);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * yScale, transform.localScale.z);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Box")) {
            transform.position = origPos;
            transform.localScale = origScale;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrossEnemy"))
        {
            collision.gameObject.GetComponent<Gross>().takeDamage(2.5f);
        }
    }
}
