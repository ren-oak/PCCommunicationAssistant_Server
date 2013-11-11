using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text.RegularExpressions;
 
namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        public bool btnstatu = true;  //开始停止服务按钮状态
        public Thread myThread;       //声明一个线程实例
        public Socket newsock;        //声明一个Socket实例
        public Socket server1;
        public Socket Client;
        public delegate void MyInvoke(string str);
        public IPEndPoint localEP;    
        public int localPort;
        public EndPoint remote;
        public Hashtable _sessionTable;      
        public bool m_Listening;
        private static byte[] result = new byte[1024];
        Socket serial;
        //用来设置服务端监听的端口号
        public int setPort            
        {
            get { return localPort; }
            set { localPort = value; }
        }       
        //用来往richtextbox框中显示消息
        public void showClientMsg(string msg)
        {
            //在线程里以安全方式调用控件
            if (showinfo.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(showClientMsg);
                showinfo.Invoke(_myinvoke, new object[] { msg });               
            }
            else
            {
                showinfo.AppendText(msg);             
            }           
        }
      public void userListOperate(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperate);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Add(msg);
            }
        }
        public void userListOperateR(string msg)
        {
            //在线程里以安全方式调用控件
            if (userList.InvokeRequired)
            {
                MyInvoke _myinvoke = new MyInvoke(userListOperateR);
                userList.Invoke(_myinvoke, new object[] { msg });
            }
            else
            {
                userList.Items.Remove(msg);
            }
        }
        //监听函数
        public void Listen()
        {   //设置端口
            setPort=int.Parse(serverport.Text.Trim());
            //初始化SOCKET实例
            newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //允许SOCKET被绑定在已使用的地址上。
            newsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //初始化终结点实例
            localEP=new IPEndPoint(IPAddress.Any,setPort);
            try
            {
                _sessionTable = new Hashtable(53);
                //绑定
                newsock.Bind(localEP);
                //监听
                newsock.Listen(10);
                Thread myThread = new Thread(ListenClientConnect);
                myThread.Start();
               //开始接受连接，异步。
                //newsock.BeginAccept(new AsyncCallback(OnConnectRequest), newsock);
             }
            catch (Exception ex)
            {
                showClientMsg(ex.Message);
            }
        }
      public void ListenClientConnect()
      {

          string msg_str = "";
          string msg_str1 = "@client@";
          string msg_str2 = "@serialassistant@";
          while (true)
          {
              Socket clientSocket = newsock.Accept();
              DateTimeOffset now = DateTimeOffset.Now;
              string strDateLine = "欢迎登录到服务器"+"\r\n";
              Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
              remote = clientSocket.RemoteEndPoint;
              showClientMsg(remote.ToString() + "连接成功。" + now.ToString("G")+"\r\n");
              clientSocket.Send(byteDateLine, byteDateLine.Length, 0);        
              int receiveNumber = clientSocket.Receive(byteDateLine);
              msg_str = Encoding.UTF8.GetString(byteDateLine);
              if (msg_str.Contains(msg_str1)==true)                                
             {               
                  //把连接成功的客户端的socket实例放到哈希表
                  _sessionTable.Add(clientSocket, remote);               
                  Thread receiveThread = new Thread(ReceiveMessage);
                  receiveThread.Start(clientSocket);                      
              }
              else if (msg_str.Contains(msg_str2) == true)
              {                
                  serial = clientSocket;
                  Thread receiveThread = new Thread(ReceiveMessage);
                  receiveThread.Start(clientSocket);
              }
              else
              {                                
              } 
          }
      }
      public void ReceiveMessage(object clientSocket)
      {
          Socket myClientSocket = (Socket)clientSocket;
          while (true)
          {
              try
              {
                  string strDateLine = "欢迎登录到服务器";
                  Byte[] byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);                 
                  int receiveNumber = myClientSocket.Receive(byteDateLine);                 
                  string stringdata = Encoding.UTF8.GetString(byteDateLine, 0, receiveNumber);
                  string ip = myClientSocket.RemoteEndPoint.ToString();                  
                  if (_sessionTable.Contains(myClientSocket))
                  {
                      
                      showClientMsg("get client mesg"+"("+ip+")"+":" + stringdata + ",will send to:" + serial.RemoteEndPoint.ToString() + "\r\n");       
                      Byte[] sendData = Encoding.UTF8.GetBytes(stringdata);
                      serial.SendTo(sendData, serial.RemoteEndPoint);
                  }
                  else {                      
                        showClientMsg(stringdata);
                       SendBroadMsg(stringdata);                 
                  }               
              }
              catch 
              {
                  myClientSocket.Shutdown(SocketShutdown.Both);
                  myClientSocket.Close();
                  break;
              }             
          }
      }    
   //以下实现发送广播消息
     public void SendBroadMsg(string strDataLine)
      {   
          Byte[] sendData = Encoding.UTF8.GetBytes(strDataLine);
          foreach (DictionaryEntry de in _sessionTable)
          {
              Socket cli = (Socket)de.Key;
              EndPoint temp = (EndPoint)de.Value;           
              cli.SendTo(sendData, temp);             
          }
       
     }  
      //开始停止服务按钮
        private void startService_Click(object sender, EventArgs e)
        {
            //新建一个委托线程
           ThreadStart myThreadDelegate = new ThreadStart(Listen);
            //实例化新线程                                                                                        
            myThread = new Thread(myThreadDelegate);
            if (btnstatu)
            {               
                myThread.Start();
                statuBar.Text = "服务已启动，等待客户端连接";
                btnstatu = false;
                startService.Text = "停止服务";
            }
            else
            {
                //停止服务
                myThread.Interrupt();
                myThread.Abort();                
                btnstatu = true;
                startService.Text = "开始服务";
                statuBar.Text = "服务已停止";                
            }            
        }
        //窗口关闭时中止线程。
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myThread != null)
            {
                myThread.Abort();
            }
        }
        private void send_Click(object sender, EventArgs e)
        {
          //  SendBroadMsg();
        }     
        private void butExit_Click(object sender, EventArgs e)
        {          
            myThread.Abort();
            Application.Exit();
        }
        private void serCle_Click(object sender, EventArgs e)
        {
            showinfo.Text = "";
        }             
    }
}
