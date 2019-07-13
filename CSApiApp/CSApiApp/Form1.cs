using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSApiApp
{
    public partial class Form1 : Form
    {
        
        private string token;
        private string user_id;
        private string message;

        

        public string getToken() => token;
        public void setToken(string value) => value = token;

        public string getUserId() => user_id;
        public void setUserId(string value) => value = user_id;

        public string getMessage() => message;
        public void setMessage(string value) => value = message;

        public Form1()
        { 
            InitializeComponent();
            token = null;
            user_id = null;
            message = null;
        }

        private string tokenTextBoxToString() => this.textBox1.Text; //returns string access_token

        private string userIdTextBoxToString() => this.textBox2.Text; // returns string user_id

        private string messageTextBoxToString() => this.textBox3.Text; // returns string message

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tokenTextBoxToString()))
            {
                setToken(tokenTextBoxToString());
                Console.WriteLine(textBox1.Text);
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userIdTextBoxToString()))
            {
                setUserId(userIdTextBoxToString());
                Console.WriteLine(textBox2.Text);
            }
        }

        private void Button3_MouseClick(object sender, MouseEventArgs e)
        {
            if(!string.IsNullOrEmpty(messageTextBoxToString()))
            {
                setMessage(messageTextBoxToString());
                Console.WriteLine(textBox3.Text);
            }
        }

        private void Button5_MouseClick(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("Sending message.. " );
            System.Console.WriteLine("Message: " + message);
            System.Console.WriteLine(getMessage() + getToken() + getUserId());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Api VkApi = new Api(textBox1.Text);
            Console.WriteLine("Sending message..");
            for(int i=0; i < 10; i++)
                VkApi.sendMessage(textBox2.Text, textBox3.Text);
        }
    }
    
    class Api
    {
        private const string START_URL = "https://api.vk.com/method/";
        private const string VERSOIN_API = "5.101";
        private string token;

        public Api(string token)
        {
            this.token = token;
        }

        private int getRandInt()
        {
            Random randint = new Random();
            return randint.Next(-20000, 20000);
        }

        public static string code(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }
        public void sendMessage(string user_id, string message)
        {
            string url = START_URL + "/messages.send?user_id=" + user_id + "&random_id=" + getRandInt() +
                "&message=" + message + "&access_token=" + token + "&v=" + VERSOIN_API;
            code(url);
        }
    }
}
