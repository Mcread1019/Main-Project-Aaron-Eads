using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tileBase;

    public GameObject ironMiner;
    public GameObject coalMiner;
    public GameObject ironRefiner;
    public GameObject Power;

    private PlaceableObject objectToPlace;

    #region Unity Methods

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            
            IntializeWithObject(ironMiner);
        
        }
        if(Input.GetKeyDown(KeyCode.W)) {
            IntializeWithObject(coalMiner);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IntializeWithObject(ironRefiner);
        }
        if(Input.GetKeyDown (KeyCode.R))
        {
            IntializeWithObject(Power);
        }




        if (!objectToPlace)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Space)) 
        {
            if(CanBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPositon());
                TakeArea(start, objectToPlace.Size);
            }
            else
            {
                Destroy(objectToPlace.gameObject);
            }

        }
    }



    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }


    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach(var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }


    #endregion

    #region Building Placement

    public void IntializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position,Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }
    
    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPositon());
        area.size = placeableObject.Size;

        TileBase[] baseArray = GetTilesBlock(area, tilemap);

        foreach(var b in baseArray)
        {
            if(b == tileBase)
            {
                return false;
            }
        }
        return true;
    }

    private void TakeArea(Vector3Int start, Vector3Int size)
    {
        tilemap.BoxFill(start, tileBase,start.x, start.y, start.x+start.x, start.y+start.y);
    }
        
    

    #endregion
}
