using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scrollMe : MonoBehaviour
{
    [SerializeField] RectTransform rTransform;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scrollUp()
    {
        rTransform.position = new Vector3(rTransform.position.x, rTransform.position.y + speed * Time.deltaTime, rTransform.position.z);
    }
    public void scrollDown()
    {
        rTransform.position = new Vector3(rTransform.position.x, rTransform.position.y - speed * Time.deltaTime, rTransform.position.z);

    }
}
