using TMPro;
using UnityEngine;

public class CounterItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP;
    private int count;
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Pickable") 
        {
            GameObject item = collision.gameObject;
            Rigidbody rb = item.GetComponent<Rigidbody>();

            if (rb.constraints == RigidbodyConstraints.None) 
            {
                item.tag = "Untagged";
                count += 1;
                TMP.text = count.ToString() + "/" + "3";
            }
        }
    }
}
