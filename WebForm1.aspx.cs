using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClassProperty c = new ClassProperty();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getstate();

                fillgrd();



            }

        }

        public void getcity()
        {
            DropDownList2.DataSource = c.getcity(Convert.ToInt16(DropDownList1.SelectedValue));
            DropDownList2.DataTextField = "cityname";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();

        }

        public void getstate()
        {

            DropDownList1.DataSource = c.getstate();
            DropDownList1.DataTextField = "satename";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }

        public void fillgrd()
        {
            GridView1.DataSource = c.getalldata();
            GridView1.DataBind();


        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            getcity();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            c.stateid = Convert.ToInt16(DropDownList1.SelectedValue);
            c.cityid = Convert.ToInt16(DropDownList1.SelectedValue);

            c.insertdata(c);
            Label lbl = new Label();

            lbl.Text = "data has been saved";

            form1.Controls.Add(lbl);
            // fillgrid();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            Label lblstate = (Label)GridView1.Rows[e.NewEditIndex].FindControl("Label1");
            Label lblcity = (Label)GridView1.Rows[e.NewEditIndex].FindControl("Label2");

            GridView1.EditIndex = e.NewEditIndex;
            fillgrd();

            DropDownList ddlstate = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList3");



            ddlstate.DataSource = c.getstate();
            ddlstate.DataTextField = "satename";
            ddlstate.DataValueField = "id";
            ddlstate.DataBind();

            foreach (ListItem li in ddlstate.Items)
            {
                if (li.Text == lblstate.Text)
                {

                    li.Selected = true;

                }


            }

            DropDownList ddlcity = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList4");

            ddlcity.DataSource = c.getcity(Convert.ToInt16(ddlstate.SelectedValue));
            ddlcity.DataTextField = "cityname";
            ddlcity.DataValueField = "id";
            ddlcity.DataBind();

            foreach (ListItem li in ddlcity.Items)
            {
                if (li.Text == ddlcity.Text)
                {

                    li.Selected = true;
                }

            }
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlstate = (DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DropDownList3");
            DropDownList ddlcity = (DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DropDownList4");
            ddlcity.DataSource = c.getcity(Convert.ToInt16(ddlstate.SelectedValue));
            ddlcity.DataTextField = "cityname";
            ddlcity.DataValueField = "id";
            ddlcity.DataBind();

        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DropDownList ddlstate = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList3");
            DropDownList ddlcity = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList4");
            c.id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            c.stateid = Convert.ToInt16(ddlstate.SelectedValue);
            c.cityid = Convert.ToInt16(ddlcity.SelectedValue);

            c.updatedata(c);

            GridView1.EditIndex = -1;

            Label lbl = new Label();
            lbl.Text = "data has been saved";
            form1.Controls.Add(lbl);
            fillgrd();
        }
    }
}