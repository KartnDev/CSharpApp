using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private string tokenTextBoxToString() => this.textBox1.ToString(); //returns string access_token

        private string idTextBoxToString() => this.textBox2.ToString(); // returns string user_id

        private string messageTextBoxToString() => this.textBox3.ToString(); // returns string message

       

        private void button1_Click(object sender, EventArgs e)
        {
            if(e.GetType().ToString() == "System.Windows.Forms.MouseEventArgs")
            {
                if (!string.IsNullOrEmpty(tokenTextBoxToString()))
                {
                    setToken(tokenTextBoxToString());
                    Console.WriteLine(this.textBox1.Copy());
                }
            }
        }
    }

    class Api
    {
        private const string START_URL = "https:// api.vk.com/";
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


        public void sendMessage(string user_id, string message)
        {
            string url = START_URL + "/messages.send?user_id=" + user_id + "&random_id=" + getRandInt() +
                "&message=" + message + "&access_token=" + token + "&v=" + VERSOIN_API;
            System.Diagnostics.Process.Start(url);
        }
    }
}
