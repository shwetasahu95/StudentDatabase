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

namespace StudentDB
{ 
    public partial class StudentInfo : Form
    {
       
        public StudentInfo()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtID.Text, fname = txtFname.Text, lname = txtLname.Text,
            Gender = cboGender.Text, Intake = cboIntake.Text, Subject = cboSubject.Text, DOB = date.Text,
            Course = cboCourse.Text, Description = txtDescription.Text, Email = txtEmail.Text, Contact = txtContact.Text;

           
            //address of SQL server DB
            String connection = "Data Source=LAPTOP-399PBCC1\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True";
            //Establishing connection
            SqlConnection con = new SqlConnection(connection);
            //Opening the connection
            con.Open();
            //Query
          
            string Query = "insert top(1) into Students(id,fName,lName,DOB,Gender,Intake,Course,Email,Contact,Subject,Description) values ('" + id + "','" + fname + "','" + lname + "','" + DOB + "','" + Gender + "','" + Intake + "','" + Course + "','" + Email + "','" + Contact + "','"+Subject+"','"+Description+"')";
           
            SqlCommand cmd = new SqlCommand(Query,con);
            
            cmd.ExecuteNonQuery();
            
            con.Close();

            MessageBox.Show("Information has been saved");
            txtID.Clear();
            txtFname.Clear();
            txtEmail.Clear();
            txtDescription.Clear();
            txtLname.Clear();
            txtDescription.Clear();
            cboCourse.ResetText();
            cboGender.ResetText();
            cboIntake.ResetText();
            cboSubject.ResetText();
            
            

        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            String connection = "Data Source=LAPTOP-399PBCC1\\SQLEXPRESS;Initial Catalog=StudentInfo;Integrated Security=True";
            //Establishing connection
            SqlConnection con = new SqlConnection(connection);
            //Opening the connection
            con.Open();
            //Query

            string Query = "Select id,fName,lName,DOB,Gender,Intake,Course,Email,Contact,Subject,Description from students where id=@id";

            SqlCommand cmd = new SqlCommand(Query, con);

            
            cmd.Parameters.AddWithValue("id", txtID.Text);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFname.Text = reader["fName"].ToString();
                txtLname.Text = reader["lName"].ToString();
                date.Text = reader["DOB"].ToString();
                cboGender.Text = reader["Gender"].ToString();
                cboCourse.Text = reader["Course"].ToString();
                cboIntake.Text = reader["Intake"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                txtContact.Text = reader["Contact"].ToString();
                txtDescription.Text = reader["Description"].ToString();
                cboSubject.Text = reader["Subject"].ToString();
            }
            else
            {
                MessageBox.Show("Information not found");
            }
            con.Close();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtFname.Clear();
            txtEmail.Clear();
            txtDescription.Clear();
            txtLname.Clear();
            txtDescription.Clear();
            cboCourse.ResetText();
            cboGender.ResetText();
            cboIntake.ResetText();
            cboSubject.ResetText();
            Gender.ResetText();
            
        }
    }
}
