using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.IO;

public class AttitudeManager : MonoBehaviour
{
    public GyroscopeSensor initializing;
    public TextMeshProUGUI dataAttitude;
    public CSVWriter csv;
    public GameObject button;
    public float duration = 2.5f;
    int fileNumber = 0;
    bool buttonPressed = false;

    public TextMeshProUGUI listLength;

    List<Quaternion> dataList = new List<Quaternion>();
  
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dataAttitude.text = initializing.Accelerometer().ToString();

    }

	private void Update()
	{
        if (buttonPressed)
        {
            dataList.Add(initializing.Accelerometer());
            listLength.text = dataList.Count.ToString();
        } 
    }

	public void ButtonPress() {
        if (!buttonPressed)
        {
            buttonPressed = true;
            button.SetActive(false);
        }
    }

    public void StartRecording()
	{
        StartCoroutine(MeasureTime());
    }

    IEnumerator MeasureTime()
	{
        yield return new WaitForSeconds(duration);
        buttonPressed = false;
        button.SetActive(true);
        csv.WriteFile("Experiment" + fileNumber, dataList);
        dataList.Clear();
        fileNumber++;
	}
}
