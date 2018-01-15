using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;

using System.Net.Sockets;


public class Client : MonoBehaviour {


    TCPSocket tcpSocket;
	// Use this for initialization
	void Start () {



        //  底层 自动分配一个端口号
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

       // IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 18001);
      
        // client.Bind(endPoint);

        tcpSocket = new TCPSocket(client, 1024,true);
	}


    void OnApplicationQuit()
    {

        if (tcpSocket != null)
            tcpSocket.Dispose();

    }


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            tcpSocket.Connect("127.0.0.1",18002);
        }



        if (Input.GetKeyDown(KeyCode.B))
        {

            byte[] tmpBytes = System.Text.Encoding.Default.GetBytes(" 1707 !!!");
            tcpSocket.Send(tmpBytes);


        }


        if (tcpSocket != null && tcpSocket.Connected())
        {

            tcpSocket.Recive();
              
        }


		
	}
}
