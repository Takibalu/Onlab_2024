using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlacer : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject arrowPrefab;

    private GameObject currentArrow;
    public float displayDuration = 2f; // A nyíl megjelenésének ideje másodpercekben
    public float delayBetweenDisplays = 1f; // A megjelenések közötti késleltetés másodpercekben


    // Start is called before the first frame update
    void Start()
    {
        PlaceArrow();
    }

    public void PlaceArrow()
    {
        if (startPoint != null && endPoint != null && arrowPrefab != null)
        {
            Vector3 direction = endPoint.position - startPoint.position;
            Vector3 arrowPosition = startPoint.position + direction / 2f;

            Quaternion rotationOffset = Quaternion.Euler(0, 90, 0); 
            Quaternion rotation = Quaternion.LookRotation(direction) * rotationOffset;

            float distance = direction.magnitude;
            Vector3 scale = new Vector3(20f *distance, 60f, 60f);

            arrowPrefab.transform.localScale = scale;

            currentArrow = Instantiate(arrowPrefab, arrowPosition, rotation);


            Destroy(currentArrow, displayDuration);

            Invoke("PlaceArrow", displayDuration + delayBetweenDisplays);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
