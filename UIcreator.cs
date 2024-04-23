using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public  class UIcreator : MonoBehaviour
{

   public Texture dd;

   // public Sprite dd;
     void Start()
    {
       

        CreateToggle(new Vector2(40,40),new Vector3(0,0,0));

    }

    public Canvas Initialize()
    {
        GameObject x = new GameObject();

        x.AddComponent<RectTransform>();
        x.AddComponent<Canvas>();
        x.AddComponent<CanvasScaler>();
        x.AddComponent<GraphicRaycaster>();

        x.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        x.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        x.GetComponent<CanvasScaler>().scaleFactor = 1;
        x.GetComponent<CanvasScaler>().referencePixelsPerUnit = 100;

        x.GetComponent<GraphicRaycaster>().ignoreReversedGraphics = true;
        x.GetComponent<GraphicRaycaster>().blockingObjects = GraphicRaycaster.BlockingObjects.None;
        // x.GetComponent<GraphicRaycaster>().blockingMask =

        var b = Camera.main.pixelWidth;
        var h = Camera.main.pixelHeight;
        x.GetComponent<RectTransform>().sizeDelta = new Vector2(b, h);

        Canvas j = x.GetComponent<Canvas>();
        return j;
    }
    public GameObject CreateButton(Vector2 size,string Text,Vector3 position,   string name = "gg",float tsize = 40, int align = 1)
    {
        

       
        GameObject d = new GameObject();
        d.AddComponent<RectTransform>();
        d.GetComponent<RectTransform>().localPosition = position;
        d.AddComponent<Button>();
        d.AddComponent<Image>();
        d.AddComponent<CanvasRenderer>();
        d.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
        d.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/UISprite"); ;
        d.GetComponent<Button>().targetGraphic = d.GetComponent<Image>();
        d.GetComponent<Image>().type = Image.Type.Sliced;
        d.GetComponent<RectTransform>().sizeDelta = size;


        //Setting and adding components of text
        GameObject c = new GameObject();
        c.transform.parent = d.transform;
        c.AddComponent<RectTransform>();
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.AddComponent<TextMeshProUGUI>();
        c.GetComponent<TextMeshProUGUI>().text = Text;
        c.GetComponent<TextMeshProUGUI>().color = Color.black;
        c.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        c.GetComponent<TextMeshProUGUI>().fontSize = tsize;

        if (align == 0)
        {
            c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
        }
        if (align == 1)
        {
            c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
        }
        if (align == 2)
        {
            c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Right;
        }

            //Adding button to Canvas
         
        d.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        d.GetComponent<RectTransform>().localPosition = position;

         GameObject j = d;
         j.name = name;


        return j;
    }

    public GameObject CreateText(Vector2 size, string Text,Vector3 position,Color color,  string name = "gg", float tsize = 40)
    {
        GameObject c = new GameObject();

        c.AddComponent<RectTransform>();
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.AddComponent<TextMeshProUGUI>();
        c.GetComponent<TextMeshProUGUI>().text = Text;
        c.GetComponent<TextMeshProUGUI>().color = color;
        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<TextMeshProUGUI>().fontSize = tsize;

       // if (align == 0)
        //{
           // c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
       // }
       // if (align == 1)
      //  {//
           // c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
       /// }
      // / if (align == 2)
       // {
           // c.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Right;
        //}

        //Adding button to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;







    }

    public GameObject CreateImage(Vector2 size, Vector3 position, Color color,  string name = "gg",Sprite image = null)
    {
        GameObject c = new GameObject();

        
        c.AddComponent<RectTransform>();
        c.AddComponent<Image>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent <Image>().color = color;
        c.GetComponent<Image>().sprite = image;



        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }

    public GameObject CreateRawImage(Vector2 size, Vector3 position, Texture texture, Material matt = null,string name = "gg")
    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;
        



        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }
    //finished till raw image
    
    
    public GameObject CreateToggle(Vector2 size, Vector3 position, string name = "gg")
    {
        GameObject Parent = new GameObject();
        GameObject Background = new GameObject();
        GameObject Check = new GameObject();


        Parent.AddComponent<RectTransform>();
        Parent.AddComponent<Toggle>();
        Parent.AddComponent<CanvasRenderer>();
        Parent.GetComponent<CanvasRenderer>().cullTransparentMesh = true;

        Background.AddComponent<RectTransform>();
        Background.AddComponent<CanvasRenderer>();
        Background.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
        Background.AddComponent<Image>();
        
        Check.AddComponent<RectTransform>();
        Check.AddComponent<CanvasRenderer>();
        Check.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
        Check.AddComponent<Image>();

        Background.transform.parent = Parent.transform;
        Check.transform.parent = Background.transform;

        Parent.GetComponent<Toggle>().graphic = Background.GetComponent<Graphic>();

        Parent.GetComponent<RectTransform>().localPosition = position;
        Background.GetComponent<RectTransform>().sizeDelta = size;
        Check.GetComponent<RectTransform>().sizeDelta = size;

        Background.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/checkmark");
        Check.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/checkmark"); ;





        //Adding Toggle to Canvas

        Parent.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        Parent.GetComponent<RectTransform>().localPosition = position;

        GameObject j = Parent;
        j.name = name;


        return j;
    }

    public GameObject CreateSlider(Vector2 size, Vector3 position, Texture texture, Material matt = null, string name = "gg")
    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;




        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }

    public GameObject CreateScrollbar(Vector2 size, Vector3 position, Texture texture, Material matt = null, string name = "gg")
    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;




        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }

    public GameObject CreateScrollview(Vector2 size, Vector3 position, Texture texture, Material matt = null, string name = "gg")

    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;




        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }

    public GameObject CreateDropDown(Vector2 size, Vector3 position, Texture texture, Material matt = null, string name = "gg")
    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;




        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }

    public GameObject CreateInputField(Vector2 size, Vector3 position, Texture texture, Material matt = null, string name = "gg")
    {
        GameObject c = new GameObject();


        c.AddComponent<RectTransform>();
        c.AddComponent<RawImage>();
        c.AddComponent<CanvasRenderer>();
        c.GetComponent<CanvasRenderer>().cullTransparentMesh = true;


        c.GetComponent<RectTransform>().localPosition = position;
        c.GetComponent<RectTransform>().sizeDelta = size;
        c.GetComponent<RawImage>().texture = texture;
        c.GetComponent<RawImage>().material = matt;




        //Adding image to Canvas

        c.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        c.GetComponent<RectTransform>().localPosition = position;

        GameObject j = c;
        j.name = name;


        return j;
    }


    
   
}


