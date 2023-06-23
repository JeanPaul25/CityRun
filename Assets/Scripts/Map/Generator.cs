using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private GameObject[] blocks;
    private int i;

    private void Start()
    {
        blocks = Resources.LoadAll<GameObject>("Prefabs/Map/Blocks");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            i = Random.Range(0, blocks.Length);
            Instantiate(blocks[i], new Vector2(18.5f, 0), Quaternion.identity);
        }
    }
}
