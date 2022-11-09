using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    public int height;
    public int width;
    public GameObject cells;
    public GameObject darkCells;
    private GameObject[,] gameGrid;
    GameObject instantiated;
    public int size = 5;
    public int centerWidth = 30;
    public int centerHeight = 50;


    void Start()
    {
    }

    // Update is called once per frame





















    void FirstStart()
    {
        CreateGrid();

    }

    void FirstUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GenerateNextRoad();
        }

    }
    void CreateGrid()
    {
        if (cells == null) return;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y >= 40)
                {

                    instantiated = Instantiate(cells, new Vector3(x, 0, y), Quaternion.identity);

                }
                else
                {
                    instantiated = Instantiate(darkCells, new Vector3(x, 0, y), Quaternion.identity);


                }

                instantiated.transform.parent = this.gameObject.transform;
            }

        }
    }



    // generate first level

    //on up movement next row 
    void GenerateNextRoad()
    {
        for (int x = 0; x < width; x++)
        {
            instantiated = Instantiate(cells, new Vector3(x, 0, 0), Quaternion.identity); // z- next row position

        }
    }
}