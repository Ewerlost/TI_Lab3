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
                MessageBox.Show("Длина вашего P должна быть отлична от нуля!", "Внимание");
                return;
            }

            if (tbQ.Text.Length == 0)
            {
                MessageBox.Show("Длина вашего Q должна быть отлична от нуля!", "Внимание");
                return;
            }

            int IntegerP = 0;
            int IntegerQ = 0;
            try
            {

                IntegerP = int.Parse(tbP.Text);
                if (!RSA.IsPrime(IntegerP))
                {
                    MessageBox.Show("Ваше число P не является простым!", "Внимание");
                    return;
                }

                IntegerQ = int.Parse(tbQ.Text);
                if (!RSA.IsPrime(IntegerQ))
                {
                    MessageBox.Show("Ваше число Q не является простым!", "Внимание");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Проверьте диапазон чисел");
                return;
            }

            IntegerR = IntegerQ * IntegerP;
            if (IntegerR is < 256 or > ushort.MaxValue)
            {
                MessageBox.Show($"Ваше произведение P и Q должно быть не меньше 256 и не больше {ushort.MaxValue}!", "Внимание");
                return;
            }

            tbR.Text = IntegerR.ToString();
            IntegerFunctionR = RSA.EulerPhi(IntegerR);
            tbFunction.Text = IntegerFunctionR.ToString();

            if (tbD.Text.Length == 0)
            {
                MessageBox.Show("Длина вашей закрытой константы D должна быть отлична от нуля!", "Внимание");
                return;
            }

            IntegerD = int.Parse(tbD.Text);
            if (IntegerD <= 1 || IntegerD >= IntegerFunctionR)
            {
                MessageBox.Show("Ваша закрытая константа D меньше 1 или больше функции эйлера!", "Внимание");
                return;
            }

            int gcd = RSA.FindGcd(IntegerD, IntegerFunctionR);
            if (gcd != 1)
            {
                MessageBox.Show("Ваша открытая константа E не взаимно простая с функцией Эйлера!", "Внимание");
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
            btnEncrypt.Text = "Зашифровать";
            tbSource.Clear();
        }

        void rbDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            mEncrypt.Enabled = false;
            mDecrypt.Enabled = true;
            mSaveSource.Enabled = true;
            mSaveEncrypt.Enabled = false;
            btnEncrypt.Text = "Дешифровать";
            tbOutput.Clear();
        }

        void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (rbEncrypt.Checked)
            {
                if (tbSource.Text.Length == 0)
                {
                    MessageBox.Show("Длина вашего исходного текста должна быть отлична от нуля. Попробуйте открыть файл!", "Внимание");
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
                    MessageBox.Show("Длина вашего зашифрованного текста должна быть отлична от нуля. Попробуйте открыть файл!",
                        "Внимание");
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

                //Если в каком-то рандомном файле не кратное двум число байт
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
                MessageBox.Show("Нечего сохранять!", "Внимание");
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
                MessageBox.Show("Нечего сохранять!", "Внимание");
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
