using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CSVWriter : MonoBehaviour
{

    StreamWriter sw;

    public void WriteFile(string FILENAME, List<Quaternion> data) {
        string filepath = Application.persistentDataPath + "/" + FILENAME + ".csv";
        StreamWriter sw = new StreamWriter(filepath);
        sw.WriteLine("x; y; z; w");
        sw.Close();

        sw = new StreamWriter(filepath, true);

        for (int i = 0; i < data.Count; i++)
        {
            sw.WriteLine(data[i].x + ";" + data[i].y + ";" + data[i].z + ";" + data[i].w);
          
        }
        sw.Close();
    }

    public void WriteData(Quaternion data)
	{
        

    }
}
