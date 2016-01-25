using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    public int numberOfAngle;
    private int numberOfClickToDestroy;
    private int numberOfClick;
    private RuntimePlatform platform = Application.platform;
	// Use this for initialization
	void Start () 
    {
        numberOfClickToDestroy = numberOfAngle;
        numberOfClick = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    // click detection
		Move ();
        OnClickObject();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ProjectileDestroyer")
        {
            //Debug.Log("crut" + col.gameObject.tag);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("cruts");
    }

    void OnClickObject()
    {
        if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    CheckTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckTouch(Input.mousePosition);
            }
        }
    }

	void Move(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f , -1f);
	}

    void CheckTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPosition = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPosition);

        if (hit != null)
        {
            numberOfClick++;
            Debug.Log("click : " + numberOfClick);
        }

        if (numberOfClick >= numberOfClickToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
