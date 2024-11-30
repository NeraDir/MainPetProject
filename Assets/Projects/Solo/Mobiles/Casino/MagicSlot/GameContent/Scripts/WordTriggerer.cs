using UnityEngine;

public class WordTriggerer : MonoBehaviour
{
    public WordContainer wordContainer;

    public MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out WordContainer container))
        {
            wordContainer = container;
        }
    }
}
