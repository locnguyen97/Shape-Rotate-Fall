using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchPoint : MonoBehaviour
{
    private bool isSelected = false;
    [SerializeField] List<GameObject> particleVFXs;
    private Vector3 startPos;
    public int id = 0;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void Move()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(Move(new Vector3(transform.position.x,-2000) ));
    }

    IEnumerator Move(Vector3 target)
    {
        yield return new WaitForSeconds(1.25f);
        gameObject.SetActive(false);
        GameManager.Instance.EnableDrag();
        GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
    }
}