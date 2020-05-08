using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    private Transform _objectiveUI;

    private void Awake()
    {
        _objectiveUI = transform.Find("Objective_Text");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HideUI");
    }

    IEnumerator HideUI()
    {
        _objectiveUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        _objectiveUI.gameObject.SetActive(false);
    }
}
