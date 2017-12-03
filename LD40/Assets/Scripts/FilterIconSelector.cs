using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterIconSelector : MonoBehaviour {

    private ColorVisionSelector __cvs;
    private List<GameObject> __imageList;

    public Sprite neutralFilter;
    public Sprite blueFilter;
    public Sprite redFilter;
    public Sprite yellowFilter;
    public Sprite greenFilter;
    public Sprite purpleFilter;
    public Sprite orangeFilter;

    int Base = 400;
    int SpriteSize = 35;

    public GameObject ImageInstance;


    // Use this for initialization
    void Start () {
        __cvs = GameObject.Find("player").GetComponent<ColorVisionSelector>();
        __imageList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update () {
        int imageNumber = __cvs.getActiveColors().Count;
        Debug.Log(imageNumber);
        Debug.Log(__imageList.Count);
        if ( __imageList.Count != imageNumber )
        {
            foreach (GameObject go in __imageList)
            {
                Destroy(go);
            }
            __imageList.Clear();

            GameObject ui = GameObject.Find("UI");
            for (int i=0; i< imageNumber; ++i)
            {
                // Create new image
                GameObject image_go = Image.Instantiate(ImageInstance);
                Image image = image_go.GetComponent<Image>();
                // Make UI parent
                image.transform.SetParent(ui.transform);
                image.rectTransform.position = new Vector3(Base + SpriteSize*i, 400, 0);
                __imageList.Add(image_go);
            }

            if( imageNumber > 1)
            {
                // Create new image
                GameObject image_go = Image.Instantiate(ImageInstance);
                Image image = image_go.GetComponent<Image>();
                // Make UI parent
                image.transform.SetParent(ui.transform);
                image.rectTransform.position = new Vector3(Base, 300, 0);
                __imageList.Add(image_go);
            }
        }

        for (int i = 0; i < imageNumber; ++i)
        {
            ColorVisionHandler.COLOR c = __cvs.getActiveColors()[i];
            switch (c)
            {
                case ColorVisionHandler.COLOR.RED:
                    __imageList[i].GetComponent<Image>().sprite = redFilter;
                    break;
                case ColorVisionHandler.COLOR.BLUE:
                    __imageList[i].GetComponent<Image>().sprite = blueFilter;
                    break;
                case ColorVisionHandler.COLOR.YELLOW:
                    __imageList[i].GetComponent<Image>().sprite = yellowFilter;
                    break;
                case ColorVisionHandler.COLOR.GREEN:
                    __imageList[i].GetComponent<Image>().sprite = greenFilter;
                    break;
                case ColorVisionHandler.COLOR.PURPLE:
                    __imageList[i].GetComponent<Image>().sprite = purpleFilter;
                    break;
                case ColorVisionHandler.COLOR.ORANGE:
                    __imageList[i].GetComponent<Image>().sprite = orangeFilter;
                    break;
                case ColorVisionHandler.COLOR.NEUTRAL:
                    __imageList[i].GetComponent<Image>().sprite = neutralFilter;
                    break;
                default:
                    __imageList[i].GetComponent<Image>().sprite = neutralFilter;
                    break;
            }
        }

        if (imageNumber > 1)
        {
            ColorVisionHandler.COLOR c = __cvs.getColor();
            switch (c)
            {
                case ColorVisionHandler.COLOR.RED:
                    __imageList[imageNumber].GetComponent<Image>().sprite = redFilter;
                    break;
                case ColorVisionHandler.COLOR.BLUE:
                    __imageList[imageNumber].GetComponent<Image>().sprite = blueFilter;
                    break;
                case ColorVisionHandler.COLOR.YELLOW:
                    __imageList[imageNumber].GetComponent<Image>().sprite = yellowFilter;
                    break;
                case ColorVisionHandler.COLOR.GREEN:
                    __imageList[imageNumber].GetComponent<Image>().sprite = greenFilter;
                    break;
                case ColorVisionHandler.COLOR.PURPLE:
                    __imageList[imageNumber].GetComponent<Image>().sprite = purpleFilter;
                    break;
                case ColorVisionHandler.COLOR.ORANGE:
                    __imageList[imageNumber].GetComponent<Image>().sprite = orangeFilter;
                    break;
                case ColorVisionHandler.COLOR.NEUTRAL:
                    __imageList[imageNumber].GetComponent<Image>().sprite = neutralFilter;
                    break;
                default:
                    __imageList[imageNumber].GetComponent<Image>().sprite = neutralFilter;
                    break;
            }
        }
    }
}
