/* Benjamin Lockard ~ Owen Schaffer ~ Honors Independent Research: Game Development ~ 3/23/2025 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public DisplayBar progressBar;
    
    private float confirmationScore;
    public string guideSelected;
    public List<string> emailFeaturesSelected;


    private LineRenderer lineRenderer;
    private Image emailPos, guidePos;

    private Coroutine makeMatchRoutine;

    public void startMakeMatch()
    {
        if (makeMatchRoutine != null)
        {
            StopCoroutine(makeMatchRoutine);
        }

        makeMatchRoutine = StartCoroutine(makeMatch());
    }

    public IEnumerator makeMatch()
    {

        if (guideSelected != null && emailFeaturesSelected != null)
        {
            progressBar.startMatchLoad();
            yield return new WaitForSeconds(1.6f);

            foreach (string feature in emailFeaturesSelected)
            {
                if (feature == guideSelected)
                {

                    Debug.Log("Match!!!");


                } else {




                }
            }

            makeMatchRoutine = null;

        }
    }
    
    public void updateEmailPos (Image ePos)
    {
        emailPos = ePos;
    }
    public void updateGuidePos(Image gPos)
    {
        guidePos = gPos;
    }


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        guideSelected = null;
        emailFeaturesSelected = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Update positions every frame
        if (guidePos == null && emailPos == null)
        {
            lineRenderer.enabled = false;
        } else 
        {
            lineRenderer.enabled = true;
            if (guidePos != null && emailPos != null)
            {
                lineRenderer.SetPosition(0, emailPos.transform.position);
                lineRenderer.SetPosition(1, guidePos.transform.position);
            }
            else
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 5.0f;

                if (guidePos != null)
                {
                    lineRenderer.SetPosition(0, mouseWorldPos);
                    lineRenderer.SetPosition(1, guidePos.transform.position);
                    //Debug.Log(guidePos.transform.position);
                }
                else if (emailPos != null)
                {
                    lineRenderer.SetPosition(0, emailPos.transform.position);
                    lineRenderer.SetPosition(1, mouseWorldPos);
                }
            }
        }

    }
}
