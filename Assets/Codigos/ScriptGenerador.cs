using UnityEngine;

public class ScriptGenerador : MonoBehaviour
{
    public GameObject rojos;
    public GameObject azules;
    public int instanciaEnemigo = 3;

    // Start is called before the first frame update
    void Start()
    {
        float x;
        float y = 0;
        float z;

        for (int i = 0; i < instanciaEnemigo; ++i)
        {
            x = Random.Range(-56.3f, 134.9f);
            z = Random.Range(-84.4f, 229.7f);

            Instantiate(rojos, new Vector3(x, y, z), rojos.transform.rotation);

            x = Random.Range(-56.3f, 134.9f);
            z = Random.Range(-84.4f, 229.7f);

            Instantiate(azules, new Vector3(x, y, z), azules.transform.rotation);
        }
        



    }
}
