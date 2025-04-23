using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab3
{
    public partial class fMain : Form
    {

        int IntegerR { get; set; }
        int IntegerFunctionR { get; set; }
        int IntegerE { get; set; }
        int IntegerD { get; set; }

        byte[] OpenedPlainFileBytes { get; set; }

        byte[] OpenedCipherFileBytes { get; set; }



        ushort[] CipherResult { get; set; }

        byte[] DecipherResult { get; set; }

        public fMain()
        {
            InitializeComponent();
        }

        void btnCalculate_Click(object sender, EventArgs e)
        {
            tbP.Text = string.Join("", tbP.Text.Where(char.IsDigit));
            tbQ.Text = string.Join("", tbQ.Text.Where(char.IsDigit));
            tbD.Text = string.Join("", tbD.Text.Where(char.IsDigit));

            if (tbP.Text.Length == 0)
            {
                MessageBox.Show("����� ������ P ������ ���� ������� �� ����!", "��������");
                return;
            }

            if (tbQ.Text.Length == 0)
            {
                MessageBox.Show("����� ������ Q ������ ���� ������� �� ����!", "��������");
                return;
            }

            int IntegerP = 0;
            int IntegerQ = 0;
            try
            {

                IntegerP = int.Parse(tbP.Text);
                if (!RSA.IsPrime(IntegerP))
                {
                    MessageBox.Show("���� ����� P �� �������� �������!", "��������");
                    return;
                }

                IntegerQ = int.Parse(tbQ.Text);
                if (!RSA.IsPrime(IntegerQ))
                {
                    MessageBox.Show("���� ����� Q �� �������� �������!", "��������");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("��������� �������� �����");
                return;
            }

            IntegerR = IntegerQ * IntegerP;
            if (IntegerR is < 256 or > ushort.MaxValue)
            {
                MessageBox.Show($"���� ������������ P � Q ������ ���� �� ������ 256 � �� ������ {ushort.MaxValue}!", "��������");
                return;
            }

            tbR.Text = IntegerR.ToString();
            IntegerFunctionR = RSA.EulerPhi(IntegerR);
            tbFunction.Text = IntegerFunctionR.ToString();

            if (tbD.Text.Length == 0)
            {
                MessageBox.Show("����� ����� �������� ��������� D ������ ���� ������� �� ����!", "��������");
                return;
            }

            IntegerD = int.Parse(tbD.Text);
            if (IntegerD <= 1 || IntegerD >= IntegerFunctionR)
            {
                MessageBox.Show("���� �������� ��������� D ������ 1 ��� ������ ������� ������!", "��������");
                return;
            }

            int gcd = RSA.FindGcd(IntegerD, IntegerFunctionR);
            if (gcd != 1)
            {
                MessageBox.Show("���� �������� ��������� E �� ������� ������� � �������� ������!", "��������");
                return;
            }

            var extendedEuclidResult = RSA.ExtendedEuclidean(IntegerFunctionR, IntegerD);

            IntegerE = extendedEuclidResult.y;

            tbE.Text = IntegerE.ToString();

            btnEncrypt.Enabled = true;
        }

        void rbEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            mEncrypt.Enabled = true;
            mDecrypt.Enabled = false;
            mSaveSource.Enabled = false;
            mSaveEncrypt.Enabled = true;
            btnEncrypt.Text = "�����������";
            tbSource.Clear();
        }

        void rbDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            mEncrypt.Enabled = false;
            mDecrypt.Enabled = true;
            mSaveSource.Enabled = true;
            mSaveEncrypt.Enabled = false;
            btnEncrypt.Text = "�����������";
            tbOutput.Clear();
        }

        void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (rbEncrypt.Checked)
            {
                if (tbSource.Text.Length == 0)
                {
                    MessageBox.Show("����� ������ ��������� ������ ������ ���� ������� �� ����. ���������� ������� ����!", "��������");
                    return;
                }

                CipherResult = new ushort[OpenedPlainFileBytes.Length];
                for (int i = 0; i < CipherResult.Length; i++)
                {
                    CipherResult[i] = OpenedPlainFileBytes[i];
                }

                for (int i = 0; i < CipherResult.Length; i++)
                {
                    CipherResult[i] = (ushort)RSA.QuickPowerMod(CipherResult[i], IntegerE, IntegerR);
                }

                tbOutput.Text = string.Join(" ", CipherResult);
            }

            if (rbDecrypt.Checked)
            {
                if (tbOutput.Text.Length == 0)
                {
                    MessageBox.Show("����� ������ �������������� ������ ������ ���� ������� �� ����. ���������� ������� ����!",
                        "��������");
                    return;
                }

                ushort[] tempShort = new ushort[CipherResult.Length];

                for (int i = 0; i < tempShort.Length; i++)
                {
                    tempShort[i] = (ushort)RSA.QuickPowerMod(CipherResult[i], IntegerD, IntegerR);
                }

                DecipherResult = new byte[tempShort.Length];
                for (var index = 0; index < tempShort.Length; index++)
                {
                    var item = tempShort[index];
                    var bytes = BitConverter.GetBytes(item);
                    if (!BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                    DecipherResult[index] = bytes[0];

                }

                tbSource.Text = string.Join(" ", tempShort);
            }
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            tbR.Clear();
            tbFunction.Clear();
            tbE.Clear();
            tbSource.Clear();
            tbOutput.Clear();
            btnEncrypt.Enabled = false;
        }

        void mEncrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                OpenedPlainFileBytes = File.ReadAllBytes(openFileDialog.FileName);
                tbSource.Text = string.Join(" ", OpenedPlainFileBytes);
            }
        }

        void mDecrypt_Click(object senser, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                OpenedCipherFileBytes = File.ReadAllBytes(openFileDialog.FileName);

                //���� � �����-�� ��������� ����� �� ������� ���� ����� ����
                if (OpenedCipherFileBytes.Length % 2 != 0)
                {
                    OpenedCipherFileBytes = OpenedCipherFileBytes.Append((byte)0).ToArray();
                }

                CipherResult = new ushort[OpenedCipherFileBytes.Length / 2];

                for (int i = 0; i < OpenedCipherFileBytes.Length; i += 2)
                {
                    byte[] bytes = [OpenedCipherFileBytes[i], OpenedCipherFileBytes[i + 1]];
                    ushort combinedShort = BitConverter.ToUInt16(bytes, 0);
                    CipherResult[i / 2] = combinedShort;
                }

                tbOutput.Text = string.Join(" ", CipherResult);
            }
        }

        void mSaveSource_Click(object senser, EventArgs e) 
        {
            if (tbSource.Text.Length == 0)
            {
                MessageBox.Show("������ ���������!", "��������");
                return;
            }

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                File.WriteAllBytes(saveFileDialog.FileName, DecipherResult);
            }
        }
        void mSaveEncrypt_Click(object senser, EventArgs e)
        {
            if (tbOutput.Text.Length == 0)
            {
                MessageBox.Show("������ ���������!", "��������");
                return;
            }
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                foreach (var item in CipherResult)
                {
                    byte[] bytes = BitConverter.GetBytes(item);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
