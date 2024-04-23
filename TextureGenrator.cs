using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenrator : MonoBehaviour
{
    public int[] x;
    public int[] y;
    public Sprite dd;
    public int[] tt;

    private void Start()
    {
        dd = texture(x, y,Color.green,tt);
    }


    public Sprite texture(int[] x, int[]y,Color j, int[]map)
    {
        Texture2D tex = new Texture2D(x.Length,y.Length);

        Color[] pixels = tex.GetPixels();


        
        for (int i = 0; i < pixels.Length; i++)
        {

            // pixels[i] = Color.red;
            if (map[i] == 1)
            {
                pixels[i] = j;
            }
            else if (map[i] == 0)
            {
                pixels[i] = Color.white;
            }
        }

        
        tex.SetPixels(pixels);
        tex.Apply();


        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f),100f);
        
        

        return sprite;
    }


    Vector2Int[] GetNeighboringCoordinates(Texture2D texture, Vector2Int originalCoordinate, int size)
    {
        // Calculate the starting and ending coordinates for the cluster
        int startX = Mathf.Max(0, originalCoordinate.x - size / 2);
        int startY = Mathf.Max(0, originalCoordinate.y - size / 2);
        int endX = Mathf.Min(texture.width, originalCoordinate.x + size / 2);
        int endY = Mathf.Min(texture.height, originalCoordinate.y + size / 2);

        // Create a list to store the coordinates of the selected clusters
        var selectedCoordinates = new System.Collections.Generic.List<Vector2Int>();

        // Loop through the cluster area
        for (int x = startX; x < endX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                // Add the coordinate to the list of selected coordinates
                selectedCoordinates.Add(new Vector2Int(x, y));
            }
        }

        // Convert the list to an array and return
        return selectedCoordinates.ToArray();
    }
}
