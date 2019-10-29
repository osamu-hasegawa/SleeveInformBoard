using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SleeveInformBoard
{
    public partial class Form1 : Form
    {
		static public SYSSET SETDATA = new SYSSET();

        public Form1()
        {
			InitializeComponent();
			ReadDataFromXml();
        }

        public void ReadDataFromXml()
		{
            SETDATA.load(ref Form1.SETDATA);

			//スリーブ番号をXMLに格納
			ComboBox [] sleeveList = new ComboBox [] {comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16};
			for(int i = 0; i < SETDATA.sleeveNo.Length; i++)
			{
				string left = SETDATA.sleeveNo[i].Substring(0, 1);
				if(left == "-")
				{
					left = "";
				}
				sleeveList[(i * 2)].Text = left;
				
				string right = SETDATA.sleeveNo[i].Substring(1, 1);
				if(right == "-")
				{
					right = "";
				}
                sleeveList[(i * 2 + 1)].Text = right; 
			}

			//T係数、Z補正をコントロールに設定
			NumericUpDown [] t_keisuList = new NumericUpDown [] {numericUpDown1, numericUpDown3, numericUpDown5, numericUpDown7, numericUpDown9, numericUpDown11, numericUpDown13, numericUpDown15};
			NumericUpDown [] z_hoseiList = new NumericUpDown [] {numericUpDown2, numericUpDown4, numericUpDown6, numericUpDown8, numericUpDown10, numericUpDown12, numericUpDown14, numericUpDown16};
			for(int i = 0; i < SETDATA.sleeveNo.Length; i++)
			{
				t_keisuList[i].Text = SETDATA.t_keisu[i];
				z_hoseiList[i].Text = SETDATA.z_hosei[i];
			}

		}

		public void WriteDataToXml()
		{
			//スリーブ番号をXMLに格納
			ComboBox [] sleeveList = new ComboBox [] {comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16};
			int j = 0;
			for(int i = 0; i < sleeveList.Length; i+=2)
			{
				string left = sleeveList[i].Text;
				if(left == "")
				{
					left = "-";
				}
				string right = sleeveList[i + 1].Text;
				if(right == "")
				{
					right =  "-";
				}
				
				SETDATA.sleeveNo[j] = left + right;
				j++;
			}

			//T係数、Z補正をXMLに格納
			NumericUpDown [] t_keisuList = new NumericUpDown [] {numericUpDown1, numericUpDown3, numericUpDown5, numericUpDown7, numericUpDown9, numericUpDown11, numericUpDown13, numericUpDown15};
			NumericUpDown [] z_hoseiList = new NumericUpDown [] {numericUpDown2, numericUpDown4, numericUpDown6, numericUpDown8, numericUpDown10, numericUpDown12, numericUpDown14, numericUpDown16};
			for(int i = 0; i < SETDATA.sleeveNo.Length; i++)
			{
				SETDATA.t_keisu[i] = t_keisuList[i].Text;
				SETDATA.z_hosei[i] = z_hoseiList[i].Text;
			}

            SETDATA.save(Form1.SETDATA);
		}

		public class SYSSET:System.ICloneable
		{
			public string[] sleeveNo =	{"", "", "", "", "", "", "", ""};
			public string[] t_keisu =	{"", "", "", "", "", "", "", ""};
			public string[] z_hosei =	{"", "", "", "", "", "", "", ""};

            public bool load(ref SYSSET ss)
			{
                string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
                string path = stCurrentDir + "\\SleeveInformBoard.xml";
				bool ret = false;
				try {
					XmlSerializer sz = new XmlSerializer(typeof(SYSSET));
					System.IO.StreamReader fs = new System.IO.StreamReader(path, System.Text.Encoding.Default);
					SYSSET obj;
					obj = (SYSSET)sz.Deserialize(fs);
					fs.Close();
					obj = (SYSSET)obj.Clone();
					ss = obj;
					ret = true;
				}
				catch (Exception /*ex*/) {
				}
				return(ret);
			}

			public Object Clone()
			{
				SYSSET cln = (SYSSET)this.MemberwiseClone();
				return (cln);
			}

			public bool save(SYSSET ss)
			{
                string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
                string path = stCurrentDir + "\\SleeveInformBoard.xml";
				bool ret = false;
				try {
					XmlSerializer sz = new XmlSerializer(typeof(SYSSET));
					System.IO.StreamWriter fs = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);
					sz.Serialize(fs, ss);
					fs.Close();
					ret = true;
				}
				catch (Exception /*ex*/) {
				}
				return (ret);
			}
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			WriteDataToXml();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
			string mes = "終了しますか？";
			DialogResult result = MessageBox.Show(mes, "スリーブ情報掲示板", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if(result == DialogResult.Yes)
			{
			}
			else
			{
                e.Cancel = true;
			}
        }
    }
}
