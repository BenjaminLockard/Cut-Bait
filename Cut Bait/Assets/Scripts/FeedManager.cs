using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class FeedManager : MonoBehaviour
{
    public MatchManager matchManager;
    public DisplayBar displayBar;
    
    public List<GameObject> fullFeed;
    public List<GameObject> currentFeed;

    public TMP_Text titleText;
    public bool inFeed;

    public GameObject clickMeIndicator;

    public FeedEmail currentEmail;

    public void returnToFeed()
    {
        if (!inFeed)
        {
            clickMeIndicator.SetActive(false);
            
            MatchEmail[] displayedSegments = Object.FindObjectsByType<MatchEmail>(FindObjectsSortMode.None);
            MatchGuide[] allGuides = Object.FindObjectsByType<MatchGuide>(FindObjectsSortMode.None);

            foreach (MatchEmail segment in displayedSegments)
            {
                segment.thisPanel.SetActive(false);
                segment.thisPanelImage.color = new Color(1f, 1f, 1f, 1f);
            }
            foreach (MatchGuide guide in allGuides)
            {
                guide.thisPanelImage.color = new Color(1f, 0.9568627f, 1f, 1f);
                guide.emailImageForLine = null;
            }
            foreach (GameObject email in currentFeed)
            {
                email.SetActive(true);
            }

            inFeed = true;
            titleText.text = "Arnie's Inbox";

            currentEmail.storedMatchPoints = matchManager.matchPoints;
            currentEmail.storedFeaturesFound = matchManager.emailFeaturesFound;

            matchManager.activeSegments = null;
            matchManager.showingFeedback = false;

            matchManager.CFBPanel.SetActive(false);
            matchManager.SFBPanel.SetActive(false);
            matchManager.emailFeaturesSelected = null;
            matchManager.updateEmailPos(null);
            matchManager.guideSelected = null;
            matchManager.updateGuidePos(null);
            displayBar.stopMatchLoad();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
