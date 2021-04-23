using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace HotelManagementSystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        String query;  //declaration
        function fn = new function();
 

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  //closing 
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username,pass from employee where username='" + txtUsername.Text + "' and pass='" + txtPassword.Text + "'";  //selection query
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count!=0)
            {
                lblError.Visible = false;
                FrmDashboard fr = new FrmDashboard();  //if the entry is correct, the form will be opened the login form will be closed.
                fr.ShowDialog();
            }
            else
            {
                lblError.Visible = true;  //if user enter incorrect or empty, the error label will appear
                txtPassword.Clear();
            }
        }
    }
}