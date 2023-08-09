using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public STATE currentState;
    public InputField inputNama;
    public Button addSkorBTN, subSkorBTN;
    public Button submitBTN;
    public Text skorTeks;
    public int skor;
    #region subscription
    private void OnEnable()
    {
        Actions.OnResultGet += (resultTeks) =>
        {
            skorTeks.text = resultTeks;
        };
    }
    private void OnDisable()
    {
        Actions.OnResultGet -= (resultTeks) =>
        {
            skorTeks.text = resultTeks;
        };
    }
    #endregion
    private void Start()
    {
        switch (currentState)
        {
            case STATE.CREATE:
                submitBTN.onClick.AddListener(AddData);
                break;
            case STATE.READ:
                inputNama.gameObject.SetActive(false);
                addSkorBTN.gameObject.SetActive(false);
                subSkorBTN.gameObject.SetActive(false);
                skorTeks.text = "";
                submitBTN.onClick.AddListener(ReadData);
                break;
            case STATE.UPDATE:
                submitBTN.onClick.AddListener(UpdateData);
                break;
            case STATE.DELETE:
                submitBTN.onClick.AddListener(DeleteData);
                break;
            default:
                break;
        }
        addSkorBTN.onClick.AddListener(AddSkor);
        subSkorBTN.onClick.AddListener(SubSkor);
    }

    private void UpdateData()
    {
        if (!string.IsNullOrEmpty(inputNama.text))
        {
            StartCoroutine(DatabaseManager.UpdateData(inputNama.text,skor));
        }
    }

    private void ReadData()
    {
        StartCoroutine(DatabaseManager.GetData());
    }

    private void DeleteData()
    {
        if (!string.IsNullOrEmpty(inputNama.text))
        {
            StartCoroutine(DatabaseManager.DeleteData(inputNama.text));
        }
    }
    private void AddData()
    {
        if (!string.IsNullOrEmpty(inputNama.text))
        {
            StartCoroutine(DatabaseManager.InsertData(inputNama.text, skor));
        }
    }

    private void AddSkor()
    {
        skor++;
        skorTeks.text = skor.ToString();
    }
    private void SubSkor()
    {
        skor--;
        skorTeks.text = skor.ToString();
    }

    public enum STATE
    {
        CREATE,
        READ,
        UPDATE,
        DELETE
    }
}