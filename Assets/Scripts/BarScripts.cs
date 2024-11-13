using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject badbar1;
    public GameObject badbar2;
    public GameObject midbar1;
    public GameObject midbar2;
    private Vector3 badscale, midscale, goodscale;
    private float gsx, msx, bsx,globy, mpx, bpx;
    void Start()
    {
        gsx = 5;
        msx = 2;
        bsx = 1;
        mpx = 3.5f;
        bpx = 5;
        globy = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp(){
        Debug.Log("Level Up Called!");
        if (gsx != 0.5){
            gsx = gsx-0.5f;
            msx = msx+0.5f;
            bsx = bsx+0.125f;
            bpx = bpx -0.2f;
            mpx = mpx -0.25f;
        }
        goodscale = new Vector3 (gsx, globy,1);
        midscale = new Vector3 (msx,globy,1);
        badscale = new Vector3 (bsx,globy,1);
        transform.localScale = goodscale;
        //midbar1.transform.localScale = midscale;
        midbar1.transform.position = new Vector3 (-mpx,1.5f,0f);
        //midbar2.transform.localScale = midscale;
        midbar2.transform.position = new Vector3 (mpx,1.5f,0f);
        badbar1.transform.localScale = badscale;
        badbar1.transform.position = new Vector3 (bpx,1.5f,0f);
        badbar2.transform.localScale = badscale;
        badbar2.transform.position = new Vector3 (-bpx,1.5f,0f);
        
    }
}
