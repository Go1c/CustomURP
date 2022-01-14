using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool isHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,
            out RaycastHit raycastHit);
        text.color = Color.white;
        if (isHit)
        {
            if (raycastHit.transform.name == "Red")
            {
                text.color = Color.red;
            }
            else if (raycastHit.transform.name == "Blue")
            {
                text.color = Color.blue;
            }
        }
    }
}