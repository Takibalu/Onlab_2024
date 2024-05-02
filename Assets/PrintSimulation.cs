using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintSimulation : MonoBehaviour
{
    public ArrowPlacer arrowPlacer;
    public float downloadDuration = 2f;
    public float waitDuration = 2f;
    public float printDuration = 2f;
    public Transform PCPoint;
    public Transform PrinterPoint;
    public Transform RouterPoint;
    public GameObject Paper;

    void Start()
    {
        InvokeRepeating("PrintProcess", 0f, downloadDuration + printDuration+waitDuration);
    }

    void PrintProcess()
    {
        StartCoroutine(DownloadAndPrint());
    }

    IEnumerator DownloadAndPrint()
    {

        Paper.SetActive(false);

        arrowPlacer.startPoint = RouterPoint;
        arrowPlacer.endPoint = PCPoint;
        arrowPlacer.gameObject.SetActive(true);
        yield return new WaitForSeconds(downloadDuration);

        arrowPlacer.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitDuration); 

        arrowPlacer.startPoint = PCPoint;
        arrowPlacer.endPoint = PrinterPoint;
        arrowPlacer.gameObject.SetActive(true);
        yield return new WaitForSeconds(printDuration);

        arrowPlacer.gameObject.SetActive(false);


        yield return new WaitForSeconds(waitDuration);
        Paper.SetActive(true);
        yield return new WaitForSeconds(waitDuration);
        Paper.SetActive(false);
     
    }
}

