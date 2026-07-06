using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class ESP32Receiver : MonoBehaviour
{
    public string espIP = "10.166.141.91";
    public int port = 12345;

    TcpClient client;
    StreamReader reader;

    public int flexValue;

    void Start()
    {
        client = new TcpClient(espIP, port);
        reader = new StreamReader(client.GetStream());
    }

    void Update()
    {
        if (client.Available > 0)
        {
            string data = reader.ReadLine();

            if (int.TryParse(data, out flexValue))
            {
                Debug.Log(flexValue);
            }
        }
    }

    void OnApplicationQuit()
    {
        reader.Close();
        client.Close();
    }
}