using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private GameObject[] blocks;
    private int arrayPosition, offsetX;
    private GameObject block;
    private void Start()
    {
        blocks = Resources.LoadAll<GameObject>("Prefabs/Map/Blocks");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            arrayPosition = Random.Range(0, blocks.Length);
            block = blocks[arrayPosition];
            offsetX = (int.Parse(block.name.Substring(block.name.LastIndexOf("_") + 1)) / 2) + 1;
            Instantiate(block, new Vector2(17.5f + offsetX, 4), Quaternion.identity);//18.5
        }
    }
}
