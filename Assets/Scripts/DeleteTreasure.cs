using UnityEngine;

public class DeleteTreasure : MonoBehaviour
{
    [SerializeField] private GameObject treasure;

    public void Activate()
    {
        treasure.SetActive(false);
    }
}
