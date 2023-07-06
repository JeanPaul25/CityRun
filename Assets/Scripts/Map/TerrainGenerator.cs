using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private GameObject[] buildBlocks;
    [SerializeField] private GameObject terrainBlock, goalBlock;
    private int arrayPosition, offsetX;
    private GameObject buildBlock;
    private void Start()
    {
        buildBlocks = Resources.LoadAll<GameObject>("Prefabs/Map/Blocks");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            if (globalValues.IsGenerateGoal == false)
            {
                arrayPosition = Random.Range(0, buildBlocks.Length);
                buildBlock = buildBlocks[arrayPosition];
                offsetX = (int.Parse(buildBlock.name.Substring(buildBlock.name.LastIndexOf("_") + 1)) / 2) + 1;
                Instantiate(buildBlock, new Vector2(17.5f + offsetX, 4), Quaternion.identity);//18.5
                Instantiate(terrainBlock, new Vector2(17.5f + offsetX, -7), Quaternion.identity);//18.5
            }
            else
            {
                Instantiate(goalBlock, new Vector2(17.5f + offsetX, 0), Quaternion.identity);//18.5
            }
        }
    }
}
