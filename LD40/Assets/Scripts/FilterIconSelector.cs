using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterIconSelector : MonoBehaviour {

    private ColorVisionSelector __cvs;
    private Image __image;

    public Sprite neutralFilter;
    public Sprite blueFilter;
    public Sprite redFilter;
    public Sprite yellowFilter;
    public Sprite greenFilter;
    public Sprite purpleFilter;
    public Sprite orangeFilter;




    // Use this for initialization
    void Start () {
        __cvs = GameObject.Find("player").GetComponent<ColorVisionSelector>();
        __image = GetComponent<Image>();
        __image.sprite = neutralFilter;
    }

    // Update is called once per frame
    void Update () {
		
        switch ( __cvs.getColor() )
        {
            case ColorVisionHandler.COLOR.RED:
                __image.sprite = redFilter;
                break;
            case ColorVisionHandler.COLOR.BLUE:
                __image.sprite = blueFilter;
                break;
            case ColorVisionHandler.COLOR.YELLOW:
                __image.sprite = yellowFilter;
                break;
            case ColorVisionHandler.COLOR.GREEN:
                __image.sprite = greenFilter;
                break;
            case ColorVisionHandler.COLOR.PURPLE:
                __image.sprite = purpleFilter;
                break;
            case ColorVisionHandler.COLOR.ORANGE:
                __image.sprite = orangeFilter;
                break;
            case ColorVisionHandler.COLOR.NEUTRAL:
                __image.sprite = neutralFilter;
                break;
            default:
                __image.sprite = neutralFilter;
                break;
        }

    }
}
