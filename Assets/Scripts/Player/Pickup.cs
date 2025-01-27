using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Ray ray;
    [SerializeField] private float lengthRay = 2f;
    private Vector3 center = new Vector3(Screen.width / 2f, Screen.height / 2f, 1f);

    private void Update() 
    {
        if (item != null) item.transform.position = Camera.main.ScreenToWorldPoint(center);
        
        if (Input.touches.Length > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began) return;

            ray = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, lengthRay)) 
            {
                if (hit.collider.tag != "Pickable") return;

                if (item != null) Drop();
                else PickUp(hit);
            }
        }
    }

    private void PickUp(RaycastHit hit) 
    {
        item = hit.collider.gameObject;
        item.transform.parent = transform;
        item.transform.rotation = new Quaternion(0f,0f,0f,0f);
        
        item.GetComponent<Rigidbody>().constraints = 
        RigidbodyConstraints.FreezePositionY | 
        RigidbodyConstraints.FreezeRotationX | 
        RigidbodyConstraints.FreezeRotationY | 
        RigidbodyConstraints.FreezeRotationZ;
    }

    private void Drop() 
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction);
    }
}
