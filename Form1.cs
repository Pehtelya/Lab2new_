using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            DataGridViewTextBoxColumn columnFIO = new DataGridViewTextBoxColumn();
            columnFIO.HeaderText = "ФИО";
            dataGridView1.Columns.Add(columnFIO);

            DataGridViewTextBoxColumn columnGroup = new DataGridViewTextBoxColumn();
            columnGroup.HeaderText = "Группа";
            dataGridView1.Columns.Add(columnGroup);

            DataGridViewTextBoxColumn columnSubject = new DataGridViewTextBoxColumn();
            columnSubject.HeaderText = "Предмет";
            dataGridView1.Columns.Add(columnSubject);

            DataGridViewTextBoxColumn columnGrade = new DataGridViewTextBoxColumn();
            columnGrade.HeaderText = "Оценка";
            dataGridView1.Columns.Add(columnGrade);


            AddStudent("Иванов Иван Иванович", "Группа 1", "Прораммирование C#", "5");
            AddStudent("Петров Петр Петрович", "Группа 2", "Прораммирование C#", "4");
            AddStudent("Сидоров Сидор Сидорович", "Группа 3", "Прораммирование C#", "3");
        }


        private void AddStudent(string fio, string group, string subject, string grade)
        {
            dataGridView1.Rows.Add(fio, group, subject, grade);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.BackColor = SystemColors.Control;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.PapayaWhip;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialogIn = new OpenFileDialog();
            fileDialogIn.Filter = "Text files (*.txt)|*.txt|Binary files (*.dat;*.bin)|*.dat;*.bin|All files (*.*)|*.*"; 
            if (fileDialogIn.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialogIn.FileName;

                using (StreamReader reader = new StreamReader(fileDialogIn.FileName))
                {
                    
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    
                    dataGridView1.Columns.Add("ФИО", "ФИО");
                    dataGridView1.Columns.Add("Группа", "Группа");
                    dataGridView1.Columns.Add("Предмет", "Предмет");
                    dataGridView1.Columns.Add("Оценка", "Оценка");

                   
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(','); 
                        if (data.Length == 4) 
                        {
                            dataGridView1.Rows.Add(data);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка в формате данных: " + line);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialogOut = new SaveFileDialog();
            fileDialogOut.FileName = ".txt";
            fileDialogOut.DefaultExt = ".txt";
            fileDialogOut.Filter = "txt files |*.txt;*.dat;*.bin";

            if (fileDialogOut.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fileDialogOut.FileName;


                StreamWriter sw = new StreamWriter(fileDialogOut.FileName);

                sw.Write(textBox2.Text);

                sw.Close();


            }
        }

        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 FormAuthor = new Form2();
            FormAuthor.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialogOut = new SaveFileDialog();
            fileDialogOut.FileName = ".txt";
            fileDialogOut.DefaultExt = ".txt";
            fileDialogOut.Filter = "txt files |*.txt;*.dat;*.bin";

            if (fileDialogOut.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fileDialogOut.FileName;


                StreamWriter sw = new StreamWriter(fileDialogOut.FileName);

                sw.Write(textBox2.Text);

                sw.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 ExpelledStudentsForm = new Form3();
            ExpelledStudentsForm.Show();
        }
    }
}