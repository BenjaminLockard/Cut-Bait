/* Benjamin Lockard ~ Owen Schaffer ~ Honors Independent Research: Game Development ~ 3/23/2025 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MatchManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public DisplayBar progressBar;
    
    private float confirmationScore;
    public string guideSelected;
    public List<string> emailFeaturesSelected;
    public List<string> emailFeaturesFound;
    
    private LineRenderer lineRenderer;
    private Image emailPos, guidePos;

    public Coroutine makeMatchRoutine;

    public GameObject CFBPanel;
    public TMP_Text CFBText;

    private string CFB;
    private int matchPoints;


    // Match Processing -----------------------------------------------------------

    public void startMakeMatch()
    {
        if (makeMatchRoutine != null)
        {
            StopCoroutine(makeMatchRoutine);
        }

        makeMatchRoutine = StartCoroutine(makeMatch());
    }

    public void stopMakeMatch()
    {
        progressBar.stopMatchLoad();
        if (makeMatchRoutine != null)
            StopCoroutine(makeMatchRoutine);
    }

    public IEnumerator makeMatch()
    {
        bool foundMatch = false;
        bool repeatMatch = false;
        if (guideSelected != null && emailFeaturesSelected != null)
        {
            progressBar.startMatchLoad();
            yield return new WaitForSeconds(1.8f);

            foreach (string feature in emailFeaturesFound)
            {
                if (feature == guideSelected)
                {
                    repeatMatch = true;
                }
            }

            if (!repeatMatch)
            {
                foreach (string feature in emailFeaturesSelected)
                {
                    if (feature == guideSelected)
                    {
                        foundMatch = true;
                        emailFeaturesFound.Add(feature);
                        if (guideSelected == "2C" || guideSelected == "2D" || guideSelected == "2E"
                            || guideSelected == "3C" || guideSelected == "3D" || guideSelected == "4C")
                        {
                            matchPoints++;
                        } else
                        {
                            matchPoints += 2;
                        }
                    }
                }
            }

            if (repeatMatch)
                CFB += "repeat risk\n >>> O <<< \n";
            else if (foundMatch)
            {
                CFB += "risk identified\n >>> O <<< \n";
                StartCoroutine(moneyManager.updateMoney(5));
            }
            else
            {
                CFB += "no correlation\n >>> X <<< \n";
                StartCoroutine(moneyManager.updateMoney(-1));
            }

            if (matchPoints >= 2)
                CFB += "scam confirmed";
            else if (matchPoints >= 1)
                CFB += "scam suspected";
            else
                CFB += "no suspicion";

            CFBPanel.SetActive(true);
            StartCoroutine(Type(CFBPanel, CFBText, CFB, 0.01f));


            CFB = "";
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

    // Visual Prep --------------------------------------------------------

    IEnumerator Type(GameObject panel, TMP_Text dest, string text, float typeSpeed)
    {
        dest.text = "";
        foreach (char letter in text)
        {
            dest.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        for (int i = 0; i < 2; i++)
        {
            panel.SetActive(false);
            yield return new WaitForSeconds(0.04f);
            panel.SetActive(true);
            yield return new WaitForSeconds(0.08f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        guideSelected = null;
        emailFeaturesSelected = null;

        CFB = "";
        matchPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
