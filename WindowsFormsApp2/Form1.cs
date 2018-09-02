using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Broker;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Broker.Broker b;
        public Form1()
        {
            InitializeComponent();
            b =  new Broker.Broker();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Person p = new Person
            {

                FirstName = txtFirstName.Text,
                LastName = txtLastname.Text
            };

            b.Insert(p);
        }
    }
}
