using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private GameObject[] blocks;
    private int position;

    private void Start()
    {
        blocks = Resources.LoadAll<GameObject>("Prefabs/Map/Blocks");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            position = Random.Range(0, blocks.Length);
            Instantiate(blocks[position], new Vector2(19f, 4), Quaternion.identity);//18.5
        }
    }
}
