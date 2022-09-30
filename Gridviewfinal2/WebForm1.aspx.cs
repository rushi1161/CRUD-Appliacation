using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Gridviewfinal2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public void add()
        {
            //create connecction
            SqlConnection con = new SqlConnection("user id=sa; password=abc; database=focussoft; data source=.");

            //pass query
            string q = "select * from emp1";
            SqlDataAdapter da = new SqlDataAdapter(q, con);

            //fill dataset

            DataSet ds = new DataSet();

            //filll dataset

            da.Fill(ds,"emp1");

            //linl

            GridView1.DataSource = ds;

            //bind

            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                add();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //create sql connection

            SqlConnection con = new SqlConnection("user id=sa; password=abc; database=focussoft; data source=.");

            //open connection

            con.Open();

            //pass query
            string r = "insert into emp1 values('"+TextBox1.Text+"',  '"+TextBox2.Text+"',   '"+TextBox3.Text+"')";

            SqlCommand cmd = new SqlCommand(r,con);

            //execute query

            cmd.ExecuteNonQuery();

            //close connection

            con.Close();
            add();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            add();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            add();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            Control c1 = row.FindControl("TextBox1");
            TextBox t1 = (TextBox)c1;

            Control c2 = row.FindControl("TextBox2");
            TextBox t2 = (TextBox)c2;

            Control c3 = row.FindControl("TextBox3");
            TextBox t3 = (TextBox)c3;

            //Create Connection

            SqlConnection con = new SqlConnection("user id=sa; password=abc; database=focussoft; data source=.");

            //open connection

            con.Open();

            //pass query

            string s = "update emp1 set ename='"+t2.Text+"', esalary='"+t3.Text+"'  where eid='"+t1.Text+"' ";

            //execute 

            SqlCommand cmd = new SqlCommand(s, con);

            //Execute

            cmd.ExecuteNonQuery();

            //close connection

            con.Close();
            GridView1.EditIndex = -1;
            add();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.RowIndex];

            Control c4 = row.FindControl("Label1");
            Label a = (Label)c4;





            //Create Connection

            SqlConnection con = new SqlConnection("user id=sa; password=abc; database=focussoft; data source=.");

            //open connection

            con.Open();

            //pass query

            string s = "delete from emp1 where eid='" + a.Text + "' ";

            //execute 

            SqlCommand cmd = new SqlCommand(s, con);

            //Execute

            cmd.ExecuteNonQuery();

            //close connection

            con.Close();
            add();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            Control c5 = row.FindControl("label1");
            Label x = (Label)c5;

            Control c6 = row.FindControl("label2");
            Label y = (Label)c6;


            Control c7 = row.FindControl("label3");
            Label z = (Label)c7;

            TextBox1.Text = x.Text;
            TextBox2.Text = y.Text;
            TextBox3.Text = z.Text;


        }
    }
}