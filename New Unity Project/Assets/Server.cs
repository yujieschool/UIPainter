using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;

using System.Net.Sockets;


using System.Threading;
using System;



public class Server : MonoBehaviour {


    Socket server;

    List<TCPSocket> allClient;


	// Use this for initialization
	void Start () {

      server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

      IPEndPoint endPoint = new IPEndPoint(IPAddress.Any,18002);
      server.Bind(endPoint);


        //  最大可以接受 100 个连接
      server.Listen(100);


      Thread tmpThread = new Thread(RecvAccpt);


      tmpThread.IsBackground = true;

      tmpThread.Start();


      allClient = new List<TCPSocket>();
		
	}


    bool IsRunningAccpt = true;
    public void RecvAccpt()
    {

  
            while (IsRunningAccpt)
              {

                  try
                  {

                      //  接受客户端的连接请求   异步 
                      server.BeginAccept(AcceptClient, null);
                  }
                  catch (Exception e)
                  {

                      Debug.Log(e.Message);
                  }
         


                  Thread.Sleep(100);

              }
        
 
    }

    // 有连接请求 会回调 到这
    public void AcceptClient(IAsyncResult callBack)
    {

     //   callBack.AsyncState

        //  结束 接受socket    client  就客户端
         Socket   client =  server.EndAccept(callBack);


         Debug.Log(" server  accpet  client  connect !!");

         TCPSocket tmpClient = new TCPSocket(client,1024);
         allClient.Add(tmpClient);



 
    }

    void OnApplicationQuit()
    {


        

        IsRunningAccpt = false;


        if (server != null)
        server.Close();
          
    }




	// Update is called once per frame
	void Update () {



        if (allClient != null)
        {
            for (int i = 0; i < allClient.Count; i++)
            {
                 if(allClient[i].Connected())
                allClient[i].Recive();

            }

        }




		
	}
}
