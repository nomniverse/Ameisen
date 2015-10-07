using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {

    public GameObject mob;

    public float cooldown = 2000f;
    private float cooldownCount = 0;

    private bool spawningEnabled = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (spawningEnabled && cooldownCount > cooldown)
        {
            Vector3 spawnerPosition = new Vector3(GetComponent<BoxCollider2D>().transform.position.x, GetComponent<BoxCollider2D>().transform.position.y, 0);
            Instantiate(mob, spawnerPosition, Quaternion.identity);
            Debug.Log("Spawned");
            cooldownCount = 0;
        }

        cooldownCount += 1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            spawningEnabled = true;
            Debug.Log("Swag");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            spawningEnabled = false;
            Debug.Log("No Swag");
        }
    }
}
