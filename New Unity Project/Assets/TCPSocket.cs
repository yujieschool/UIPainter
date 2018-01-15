using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Net;

using System.Net.Sockets;

using System;



public class TCPSocket  {


    Socket myClient;


    bool IsClient;


    byte[] reciveBuffer;
    public TCPSocket(Socket tmpSocket,int  Recivesize)
    {
        myClient = tmpSocket;

        reciveBuffer = new byte[Recivesize];

        IsClient = false;
    }

    public TCPSocket(Socket tmpSocket, int Recivesize,bool  isClient)
    {
        myClient = tmpSocket;

        reciveBuffer = new byte[Recivesize];

        IsClient = isClient;

    }


    #region  发送


    public void Send(byte[] buffer)
    {


        myClient.BeginSend(buffer,0,buffer.Length,SocketFlags.None,new AsyncCallback(SendCallBack),null);
    }


    public void SendCallBack(IAsyncResult  callBack)
    {
        //  发送成功  回调   真正发送的长度
       int   realLenght=    myClient.EndSend(callBack);
          
 
    }

    #endregion


    #region   接受


    public void Recive()
    {

        //t BeginReceive(byte[] buffer, int offset, int size, SocketFlags socket_flags, AsyncCallback callback, object state);
        myClient.BeginReceive(reciveBuffer, 0, reciveBuffer.Length,SocketFlags.None,new AsyncCallback(RecvieCallBack),null);
    }

    public void RecvieCallBack(IAsyncResult   result)
    {

        //  真正接受到的数据长度
        int  realSize =  myClient.EndReceive(result);


        string recvStr = System.Text.Encoding.Default.GetString(reciveBuffer, 0, realSize);


        Debug.Log("recv str =="+  recvStr);


        if (!IsClient)
        {

          

            Debug.Log("  server  recv  client   lenght==" + realSize + " ==" + recvStr);


            string tmpSendStr = recvStr + "牛逼XX!!";


            myClient.Send(System.Text.Encoding.Default.GetBytes(tmpSendStr));
        }
        else
        {


           

            Debug.Log("client  recv =="+  recvStr);
 
        }

      
 
    }


    #endregion



    public bool Connected()
    {

        return myClient.Connected;
 
    }


    #region    Connect 

    public void Connect(string  ip ,int  port )
    {
        IPEndPoint  endPoint = new IPEndPoint(IPAddress.Parse(ip),port);


        myClient.BeginConnect(endPoint, new AsyncCallback(ConnectCallBack),null);
    }

    public void ConnectCallBack(IAsyncResult  result)
    {

        //  表示三次握手 完成
           myClient.EndConnect(result);


           Debug.Log("connect  sucess");
    }
      
    #endregion 

    #region  Dispos

    public void Dispose()
    {

        if (myClient != null && myClient.Connected)
        {

            myClient.Close();
        }
 

    }

    #endregion 

}
