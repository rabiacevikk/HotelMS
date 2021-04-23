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

namespace HotelManagementSystem
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        function fn = new function(); 
        String query; //declarations
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  //exit
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerRegistration.Left;  //when this button is pressed, the corresponding panel opens  
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            clearAll();  //clear items
        }
        public void setComboBox(String query,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);      
            while (sdr.Read())
            {
                for(int i=0; i < sdr.FieldCount; i++)
                {
                    for( i=0; i < sdr.FieldCount; i++)
                    {
                        combo.Items.Add(sdr.GetString(i));  //to bring data to the Combobox
                    }
                }
            }
            sdr.Close();

        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCheckOut.Left;
            clearAll();
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerDetails.Left;
            panel6.Visible = true;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnEmployee.Left;
            panel7.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  //minimize the page
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;  //the corresponding panel open
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            query = "select * from rooms"; //a query that pints rooms
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];  //printing rooms datagridview1 
            query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.checkin,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid where chekout='NO'";
            ds = fn.GetData(query);
            getMaxID();
        }
        public void getMaxID()
        {
            query = "select max(eid) from employee";  //to find biggest id from employees tables
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                string num = ds.Tables[0].Rows[0][0].ToString();
                Int32 a =Convert.ToInt32(num);   
                lblID.Text = (a+ 1).ToString(); //the id of the next employee will be one more than the max id
            }
        }

        private void btnAddRoo_Click(object sender, EventArgs e)
        {
            if (txtBxRoomNumb.Text!="" && txtPrice.Text!="" &&cmbBxBed.Text!=""&&cmbBxRoomType.Text!="")
            {
                String roomno = txtBxRoomNumb.Text;
                String type = cmbBxRoomType.Text;
                String bed = cmbBxBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                query="insert into rooms(roomNo,roomType,bed,price) values('"+roomno+"','"+type+"','"+bed+"',"+price+")";  //insertion query
                fn.setData(query, "Room Added");
                FrmDashboard_Load(this, null); //refresh
                clearAll();  //clear items
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); //messaging
            }
        }
        public void clearAll()
        {
            txtBxRoomNumb.Clear();
            cmbBxRoomType.SelectedIndex = -1;
            cmbBxBed.SelectedIndex = -1;
            txtPrice.Clear();
            txtCName.Clear();
            txtMobileNo.Clear();
            txtNationality.Clear();
            cmbGender.SelectedIndex = -1;
            dataOFBirth.ResetText();
            txtIDProof.Clear();
            txtAddress.Clear();
            checkIn.ResetText();               //Cleaning for all items
            cmbBed.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbRoomNo.SelectedIndex = -1;
            txtCPrice.Clear();
            txtRoomNo.Clear();
            txtSearchName.Clear();
            txtName.Clear();
            dteTimeCheckO.ResetText();
            txteName.Clear();
            txteMobileNo.Clear();
            cmbEgender.SelectedIndex = -1;
            txteEmailId.Clear();
            txteUserName.Clear();
            txtePassword.Clear();
           
        }


        private void cmbBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRoom.SelectedIndex = -1;  //Cleaning process of items connected to cmbBed
            cmbRoomNo.Items.Clear();
            txtCPrice.Clear();
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRoomNo.Items.Clear();
            txtCPrice.Clear();
            query = "select roomNo from rooms where bed='" + cmbBed.Text + "' and roomType='" + cmbRoom.Text + "' and booked='NO'";  //query 
            setComboBox(query, cmbRoomNo);
        }
        int rid;
        private void cmbRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price,roomid from rooms where roomNo='" + cmbRoomNo.Text + "'"; //query
            DataSet ds = fn.GetData(query);
            txtCPrice.Text = ds.Tables[0].Rows[0][0].ToString(); //get data from tables
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if(txtCName.Text!="" &&txtMobileNo.Text!="" &&txtNationality.Text!=""&& cmbGender.Text!=""&&dataOFBirth.Text!=""&&txtIDProof.Text!=""&& txtAddress.Text!=""&&checkIn.Text!=""&& txtCPrice.Text != "")
            {
                String name = txtCName.Text;
                String mobile = txtMobileNo.Text;
                String national = txtNationality.Text;
                String gender = cmbGender.Text;
                String dob = dataOFBirth.Text;
                String idproof = txtIDProof.Text;
                String adress = txtAddress.Text;
                String checkin = checkIn.Text;   //reservation process
                query = "insert into customer(cname,mobile,nationality,gender,dob,idproof,addres,checkin,roomid)values('" + name + "','" + mobile + "','" + national + "','" + gender + "','" + dob + "','" + idproof + "','" + adress + "','" + checkin+ "',"+ rid + ") update rooms set booked= 'YES' where roomNo = '"+cmbRoomNo.Text+"'";
           fn.setData(query, "Room No" + cmbRoomNo.Text+" Allocation Successful.");
                FrmDashboard_Load(this, null);  //refresh
                clearAll();
                    }
            else
            {
                MessageBox.Show("All fields are madetory.", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information); //messaging error
            }
        }


        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid where cname like'" + txtSearchName.Text + "%' and chekout='NO'";//searching name also hasn't paid bill yet
            DataSet ds = fn.GetData(query);
            dataGridView2.DataSource = ds.Tables[0];  //print the typed query in DataGridView2
        }
        int id;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id= int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()); //printing data 
                txtRoomNo.Text = (dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void btnCO_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text!="")
            {
                if (MessageBox.Show("Are you sure?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String cdate = dteTimeCheckO.Text; //transaction time 
                    query = "update customer set chekout='YES', checkout='"+cdate+"' where cid="+id+" update rooms set booked='NO' where roomNo='"+ txtRoomNo.Text+"'"; //updation query
                    fn.setData(query, "Check Out Successfully.");
                    FrmDashboard_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); //error message
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedIndex == 0) //printing DataGridView3 data according to the selected ID in the Combobox
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid";
                getRecord(query);
            }
            else if (cmbSearchBy.SelectedIndex == 1)
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid =rooms.roomid where checkout is null";
                getRecord(query);
            }
            else if (cmbSearchBy.SelectedIndex == 2)
            {
                query="select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid where checkout is not null";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.GetData(query);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txteName.Text!="" &&txteMobileNo.Text!="" && cmbEgender.Text!="" && txteEmailId.Text!="" &&txteUserName.Text!="" && txtePassword.Text != "")
            {
                String name = txteName.Text;
                string mobile = txteMobileNo.Text; //employee registration
                String gender = cmbEgender.Text;
                string email = txteEmailId.Text;
                string username = txteUserName.Text;
                string pass = txtePassword.Text;
                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values ('"+name+"','"+mobile+"','"+gender+"','"+email+"','"+username+"','"+pass+"')";  //insertion query
                fn.setData(query, "Employee Registered.");
                FrmDashboard_Load(this, null);  //refresh
                clearAll(); //cleaning items
                getMaxID();  //for next employee id
            }
            else
            {
                MessageBox.Show("Fill all Fields.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);   //warning
            }
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex==1)
            {
                setEmployee(dataGridView4);  //print the employees table in the Datagrids
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(dataGridView5);
            }
        }
        public void setEmployee(DataGridView dgv)
        {
            query= "select * from employee";    //selection query
            DataSet ds = fn.GetData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void btneDelete_Click(object sender, EventArgs e)
        {
            if (txteID.Text != "")     //delete the selected employee
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid =" + txteID.Text + "";
                    fn.setData(query, "Record Deleated.!");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
                else
                {
                    MessageBox.Show("Cancelled.");
                }
            }
            else
            {
                MessageBox.Show("You must fill.");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
