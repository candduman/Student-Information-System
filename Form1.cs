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

namespace kayit_programi
{
    public partial class Form1 : Form
    {


        public SqlConnection conn = new SqlConnection(@"Data Source=CAN\SQLEXPRESS;Initial Catalog=University_OBS;Integrated Security=True");
        string yetki;
        string username;
        bool mevcut;

        public Form1()
        {
            InitializeComponent();
            student_panel.Visible = false;
            instructor_panel.Visible = false;   
            coursepanel.Visible = false;
            dep_panel.Visible = false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            back_ground_panel.Visible = true;
            kullanıcı_panel.Visible = false;
            button30.Visible = false;
            datetime_label.Text = DateTime.Now.ToString();
            logo_panel.BackgroundImageLayout = ImageLayout.Stretch;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void student_button_Click(object sender, EventArgs e)
        {
            instructor_panel.Visible=false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            dep_panel.Visible = false;
            coursepanel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;
            if (student_panel.Visible == false)
            {
                student_panel.Visible=true;
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            dep_panel.Visible = false;
            coursepanel.Visible = false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;

            if (instructor_panel.Visible == false)
            {
                instructor_panel.Visible = true;

            }
            
                
        }

        private void logo_panel_MouseClick(object sender, MouseEventArgs e)
        {
            student_panel.Visible = false;
            dep_panel.Visible = false;
            coursepanel.Visible = false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            instructor_panel.Visible = false;
            back_ground_panel.Visible = true;
            kullanıcı_panel.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            instructor_panel.Visible = false;
            dep_panel.Visible = false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;

            if (coursepanel.Visible == false)
            {
                coursepanel.Visible = true;
            }
                

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            instructor_panel.Visible=false;
            coursepanel.Visible=false;
            faculty_panel.Visible = false;
            room_panel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;

            if (dep_panel.Visible == false)
            {
                dep_panel.Visible = true;
            }
            
                
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            instructor_panel.Visible = false;
            coursepanel.Visible = false;
            dep_panel.Visible = false;
            room_panel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;

            if (faculty_panel.Visible == false)
            {
                faculty_panel.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            instructor_panel.Visible = false;
            coursepanel.Visible = false;
            dep_panel.Visible = false;
            faculty_panel.Visible = false;
            back_ground_panel.Visible = false;
            kullanıcı_panel.Visible = false;

            if (room_panel.Visible == false)
            {
                room_panel.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datetime_label.Text = DateTime.Now.ToString();

        }

        private void button30_Click(object sender, EventArgs e)
        {
            student_panel.Visible = false;
            instructor_panel.Visible = false;
            coursepanel.Visible = false;
            dep_panel.Visible = false;
            faculty_panel.Visible = false;
            back_ground_panel.Visible = false;
            room_panel.Visible = false;
            if (kullanıcı_panel.Visible == false)
            {
                kullanıcı_panel.Visible=true;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataReader searchdr;
            SqlCommand search = new SqlCommand("select *from login where usr='" + textBox17.Text + "'", conn);
            searchdr=search.ExecuteReader();

            if (checkBox1.Checked == true)
            {
                yetki = "admin";
            }
            else
            {
                yetki = "general";
            }

            if (searchdr.Read())
            {
                username = searchdr["usr"].ToString();
                if (textBox17.Text == username)
                {
                    mevcut = true;
                }
                else
                {
                    mevcut=true;
                }
                             
            }
            searchdr.Close();
            if (textBox18.Text != textBox19.Text)
            {

                textBox18.Clear();
                textBox19.Clear();
                MessageBox.Show("Password you entered doesn't match.");

            }else if (mevcut == true)
            {
                MessageBox.Show("User exist!");
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox17.Focus();
            }
            else
            {
                SqlCommand adduser = new SqlCommand("insert into login(usr,password,usertype)values(@user,@pw,@yetki)", conn);
                adduser.Parameters.AddWithValue("@user", textBox17.Text);
                adduser.Parameters.AddWithValue("@pw", textBox18.Text);
                adduser.Parameters.AddWithValue("@yetki", yetki);
                adduser.ExecuteNonQuery();
                this.loginTableAdapter.Fill(this.university_OBS.login);
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                MessageBox.Show("User added succcessfully.");
                textBox17.Focus();

            }
            conn.Close();
            this.loginTableAdapter.Fill(this.university_OBS.login); 

        }

        private void button32_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to log out", "Log Out", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Insert(textBox1.Text,textBox2.Text,maskedTextBox1.Text,checkedListBox1.SelectedItem.ToString(),textBox4.Text,textBox3.Text,maskedTextBox2.Text,Convert.ToInt32(comboBox1.SelectedValue));
            this.studentTableAdapter.Fill(this.university_OBS.Student);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = this.studentTableAdapter.SearchStudentName(Convert.ToInt32(textBox5.Text));
            textBox2.Text=this.studentTableAdapter.SearchStudentLName(Convert.ToInt32(textBox5.Text));
            maskedTextBox1.Text=this.studentTableAdapter.SearchStudentDOB(Convert.ToInt32(textBox5.Text)).ToString();
            checkedListBox1.SelectedItem=this.studentTableAdapter.SearchStudentGender(Convert.ToInt32(textBox5.Text));
            textBox4.Text=this.studentTableAdapter.SearchStudentMail(Convert.ToInt32(textBox5.Text));
            textBox3.Text=this.studentTableAdapter.SearchStudentPhone(Convert.ToInt32(textBox5.Text));
            maskedTextBox2.Text=this.studentTableAdapter.SearchStudentPhone(Convert.ToInt32(textBox5.Text));
            comboBox1.SelectedValue=this.studentTableAdapter.SearchStudentDepartment(Convert.ToInt32(textBox5.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.UpdatebyStudent(textBox1.Text, textBox2.Text, maskedTextBox1.Text, checkedListBox1.SelectedItem.ToString(), textBox4.Text, textBox3.Text, maskedTextBox2.Text, Convert.ToInt32(comboBox1.SelectedValue),Convert.ToInt32(textBox5.Text),Convert.ToInt32(textBox5.Text));
            this.studentTableAdapter.Fill(this.university_OBS.Student);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.DeletebyStudent(Convert.ToInt32(textBox5.Text));
            this.studentTableAdapter.Fill(this.university_OBS.Student);

            this.enrollStudentCourseTableAdapter.UpdateEnrollCourse_DeleteStudent(Convert.ToInt32(textBox5.Text));
            this.enrollStudentCourseTableAdapter.Fill(this.university_OBS.EnrollStudentCourse);

            this.gradeTableAdapter.UpdateEnrollGrade_DeleteStudent(Convert.ToInt32(textBox5.Text));
            this.gradeTableAdapter.Fill(this.university_OBS.Grade);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.Insert(textBox10.Text, textBox9.Text, checkedListBox2.SelectedItem.ToString(), maskedTextBox3.Text, textBox7.Text, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), maskedTextBox4.Text);
            this.instructorTableAdapter.Fill(this.university_OBS.Instructor);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox10.Text=this.instructorTableAdapter.SearchInsName(Convert.ToInt32(textBox6.Text));
            textBox9.Text=this.instructorTableAdapter.SearchInsLName(Convert.ToInt32(textBox6.Text));
            maskedTextBox4.Text = this.instructorTableAdapter.SearchInsDOB(Convert.ToInt32(textBox6.Text));
            checkedListBox2.SelectedItem=this.instructorTableAdapter.SearchInsGender(Convert.ToInt32(textBox6.Text));
            textBox7.Text=this.instructorTableAdapter.SearchInsTitle(Convert.ToInt32(textBox6.Text));
            maskedTextBox3.Text=this.instructorTableAdapter.SearchInsPhone(Convert.ToInt32(textBox6.Text)).ToString();
            comboBox3.SelectedValue=this.instructorTableAdapter.SearchInsRoom(Convert.ToInt32(textBox6.Text));
            comboBox2.SelectedValue=this.instructorTableAdapter.SearchInsDept(Convert.ToInt32(textBox6.Text));


        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.UpdateByIns(textBox10.Text, textBox9.Text, checkedListBox2.SelectedItem.ToString(), maskedTextBox3.Text, textBox7.Text, Convert.ToInt32(comboBox2.SelectedValue).ToString(), Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(maskedTextBox4.Text), Convert.ToInt32(textBox6.Text));
            this.instructorTableAdapter.Fill(this.university_OBS.Instructor);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.instructorTableAdapter.DeletebyIns(Convert.ToInt32(textBox6.Text));
            this.instructorTableAdapter.Fill(this.university_OBS.Instructor);

            this.coursesTableAdapter.UpdateCourse_DeleteIns(Convert.ToInt32(textBox6.Text));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);

            this.facultyTableAdapter.UpdateFaculty_DeleteIns(Convert.ToInt32(textBox6.Text));
            this.facultyTableAdapter.Fill(this.university_OBS.Faculty);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.InsertQuery(Convert.ToInt32(textBox26.Text),Convert.ToInt32(comboBox8.SelectedValue),textBox27.Text);
            this.enrollStudentCourseTableAdapter.Fill(this.university_OBS.EnrollStudentCourse);

        }

        private void button39_Click(object sender, EventArgs e)
        {
            textBox26.Text=this.enrollStudentCourseTableAdapter.SearchEnrollStudent(Convert.ToInt32(textBox28.Text)).ToString();
            comboBox8.SelectedValue = this.enrollStudentCourseTableAdapter.SearchEnrollCourse(Convert.ToInt32(textBox28.Text));
            textBox27.Text = this.enrollStudentCourseTableAdapter.SearchEnrollCourse(Convert.ToInt32(textBox28.Text)).ToString();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.UpdatebyEnroll(Convert.ToInt32(textBox26.Text), Convert.ToInt32(comboBox8.SelectedValue),textBox27.Text,Convert.ToInt32(textBox28.Text));
        }

        private void button41_Click(object sender, EventArgs e)
        {
            this.enrollStudentCourseTableAdapter.DeleteByEnroll(Convert.ToInt32(textBox28.Text));
            this.enrollStudentCourseTableAdapter.Fill(this.university_OBS.EnrollStudentCourse);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.Insert(Convert.ToInt32(textBox29.Text),Convert.ToInt32(comboBox18.SelectedValue),Convert.ToInt32(textBox30.Text),Convert.ToInt32(textBox31.Text),Convert.ToInt32(textBox32.Text));
            this.gradeTableAdapter.Fill(this.university_OBS.Grade);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox29.Text = this.gradeTableAdapter.SearchGradeStudent(Convert.ToInt32(textBox33.Text)).ToString();
            comboBox18.SelectedValue = this.gradeTableAdapter.SearchGradeCourse(Convert.ToInt32(textBox33.Text));
            textBox30.Text = this.gradeTableAdapter.SearchGradeMidterm(Convert.ToInt32(textBox33.Text)).ToString();
            textBox31.Text = this.gradeTableAdapter.SearchGradeFinal(Convert.ToInt32(textBox33.Text)).ToString();
            textBox32.Text=this.gradeTableAdapter.SearchGradeMakeup(Convert.ToInt32(textBox33.Text)).ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.UpdatebyGrade(Convert.ToInt32(textBox26.Text), Convert.ToInt32(comboBox18.SelectedValue),Convert.ToInt32(textBox30.Text),Convert.ToInt32(textBox31.Text),Convert.ToInt32(textBox32.Text),Convert.ToInt32(textBox33.Text));
            this.gradeTableAdapter.Fill(this.university_OBS.Grade);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            this.gradeTableAdapter.DeleteByGrade(Convert.ToInt32(textBox33.Text));
            this.gradeTableAdapter.Fill(this.university_OBS.Grade);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.InsertDepartment(textBox34.Text, Convert.ToInt32(comboBox4.SelectedValue));
            this.departmentTableAdapter.Fill(this.university_OBS.Department);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox34.Text = this.departmentTableAdapter.SearchDeptName(Convert.ToInt32(comboBox5.SelectedValue));
            comboBox4.SelectedValue = this.departmentTableAdapter.SearchDeptFaculty(Convert.ToInt32(comboBox5.SelectedValue));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.UpdatebyDepartment(textBox34.Text, Convert.ToInt32(comboBox4.SelectedValue),Convert.ToInt32(comboBox5.SelectedValue));
            this.departmentTableAdapter.Fill(this.university_OBS.Department);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.departmentTableAdapter.Deletebydepartment(Convert.ToInt32(comboBox4.SelectedValue));
            this.departmentTableAdapter.Fill(this.university_OBS.Department);

            this.studentTableAdapter.Updatebystudent_deletedepartment(Convert.ToInt32(comboBox4.SelectedValue));
            this.studentTableAdapter.Fill(this.university_OBS.Student);

            this.coursesTableAdapter.UpdateCourse_DeleteDepartment(Convert.ToInt32(comboBox4.SelectedValue));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);

            this.instructorTableAdapter.UpdateIns_DeleteDepartment(Convert.ToInt32(comboBox4.SelectedValue));
            this.instructorTableAdapter.Fill(this.university_OBS.Instructor);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.Insert(textBox13.Text, textBox14.Text,Convert.ToInt32(textBox15.Text),Convert.ToInt32(comboBox5.SelectedValue),Convert.ToInt32(comboBox9.SelectedValue),Convert.ToInt32(comboBox10.SelectedValue));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox13.Text = this.coursesTableAdapter.SearchCourseCode(Convert.ToInt32(comboBox11.Text));
            textBox14.Text = this.coursesTableAdapter.SearchCourseName(Convert.ToInt32(comboBox11.Text));
            textBox15.Text = this.coursesTableAdapter.SearchCourseCredit(Convert.ToInt32(comboBox1.Text)).ToString();
            comboBox5.SelectedValue = this.coursesTableAdapter.SearchCourseRoom(Convert.ToInt32(comboBox11.Text));
            comboBox9.SelectedValue=this.coursesTableAdapter.SearchCourseIns(Convert.ToInt32(comboBox11.Text));
            comboBox10.SelectedValue = this.coursesTableAdapter.SearchCourseDept(Convert.ToInt32(comboBox11.Text));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.UpdateByCourse(textBox13.Text, textBox14.Text, Convert.ToInt32(textBox15.Text), Convert.ToInt32(comboBox5.SelectedValue), Convert.ToInt32(comboBox9.SelectedValue), Convert.ToInt32(comboBox10.SelectedValue),Convert.ToInt32(comboBox11.SelectedValue));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.coursesTableAdapter.DeleteByCourse(Convert.ToInt32(comboBox11.SelectedValue));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);

            this.enrollStudentCourseTableAdapter.UpdateEnrollCourse_DeleteCourse(Convert.ToInt32(comboBox11.SelectedValue));
            this.enrollStudentCourseTableAdapter.Fill(this.university_OBS.EnrollStudentCourse);

            this.gradeTableAdapter.UpdateEnrollGrade_DeleteCourse(Convert.ToInt32(comboBox11.SelectedValue));
            this.gradeTableAdapter.Fill(this.university_OBS.Grade);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.Insert(textBox20.Text, Convert.ToInt32(comboBox6.SelectedValue),Convert.ToInt32(comboBox7.SelectedValue).ToString(),Convert.ToInt32(comboBox12.SelectedValue).ToString());
            this.facultyTableAdapter.Fill(this.university_OBS.Faculty);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox20.Text = this.facultyTableAdapter.SearchFacultyName(Convert.ToInt32(textBox8.Text));
            comboBox6.SelectedValue = this.facultyTableAdapter.SearchFacIns(Convert.ToInt32(textBox8.Text));
            comboBox7.SelectedValue = this.facultyTableAdapter.SearchDeanName(Convert.ToInt32(textBox8.Text));
            comboBox12.SelectedValue = this.facultyTableAdapter.SearchDeanLName(Convert.ToInt32(textBox8.Text));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.UpdateByFaculty(textBox20.Text, Convert.ToInt32(comboBox6.SelectedValue), Convert.ToInt32(comboBox7.SelectedValue).ToString(), Convert.ToInt32(comboBox12.SelectedValue).ToString(),Convert.ToInt32(textBox8.Text));
            this.facultyTableAdapter.Fill(this.university_OBS.Faculty);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.DeletebyFaculty(Convert.ToInt32(textBox8.Text));
            this.facultyTableAdapter.Fill(this.university_OBS.Faculty);

            this.departmentTableAdapter.Deletebydepartment(Convert.ToInt32(textBox8.Text));
            this.departmentTableAdapter.Fill(this.university_OBS.Department);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.Insert(Convert.ToInt32(textBox11.Text).ToString(), textBox12.Text);
            this.roomsTableAdapter.Fill(this.university_OBS.Rooms);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox11.Text = this.roomsTableAdapter.SearchRoomNo(Convert.ToInt32(textBox16.Text)).ToString();
            textBox12.Text = this.roomsTableAdapter.SearchRoomPlace(Convert.ToInt32(textBox16.Text)).ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.UpdateByRoom(Convert.ToInt32(textBox11.Text).ToString(), textBox12.Text, Convert.ToInt32(textBox16.Text)) ;
            this.roomsTableAdapter.Fill(this.university_OBS.Rooms);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.roomsTableAdapter.DeleteByRoom(Convert.ToInt32(textBox16.Text));
            this.roomsTableAdapter.Fill(this.university_OBS.Rooms);

            this.coursesTableAdapter.UpdateCourse_DeleteRoom(Convert.ToInt32(textBox16.Text));
            this.coursesTableAdapter.Fill(this.university_OBS.Courses);

            this.instructorTableAdapter.UpdateIns_DeleteRoom(Convert.ToInt32(textBox16.Text));
            this.instructorTableAdapter.Fill(this.university_OBS.Instructor);
        }
    }
}
