/* Benjamin Lockard ~ Owen Schaffer ~ Honors Independent Research: Game Development ~ 3/23/2025 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private float confirmationScore;
    public string guideSelected;
    public List<string> emailFeaturesSelected;


    public void makeMatch()
    {
        if (guideSelected != null && emailFeaturesSelected != null)
        {
            foreach (string feature in emailFeaturesSelected)
            {
                if (feature == guideSelected)
                {

                    Debug.Log("Match!!!");


                } else {




                }
            }
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
