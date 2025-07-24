using Objects;
using UnityEngine;

public class DialogSpawner : MonoBehaviour
{
    [SerializeField] private GameObject correctDialog;
    [SerializeField] private GameObject wrongDialog;
    
    public void SpawnCorrectDialog() => Instantiate(correctDialog).GetComponent<StartDialogObject>().enabled = true;
    
    public void SpawnWrongDialog() => Instantiate(wrongDialog).GetComponent<StartDialogObject>().enabled = true;
}
