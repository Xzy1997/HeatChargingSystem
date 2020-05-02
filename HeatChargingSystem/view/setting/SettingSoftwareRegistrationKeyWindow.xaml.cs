using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeatChargingSystem.view
{
    /// <summary>
    /// AddSecretKeyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingSoftwareRegistrationKeyWindow : WindowX
    {
        public SettingSoftwareRegistrationKeyWindow()
        {
            InitializeComponent();
        }

        private void VerifySignature(object sender, RoutedEventArgs e)
        {
            //获取GUID
            string guid= getGUID();
            //System.Windows.MessageBox.Show(guid);
            //发送GUID

            //返回公钥
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                //获取公钥
                rsa.FromXmlString(getPubkey());
                //获取并处理唯一特征值
                byte[] source = ASCIIEncoding.ASCII.GetBytes(guid);

                RSAPKCS1SignatureDeformatter decry = new RSAPKCS1SignatureDeformatter(rsa);
                decry.SetHashAlgorithm("SHA1");

                //格式化唯一特征值
                SHA1Managed sha = new SHA1Managed();
                byte[] arr = sha.ComputeHash(source);
                TextRange tr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                byte[] signed = Convert.FromBase64String(tr.Text);

                if (decry.VerifySignature(arr, signed))
                {
                    MessageBox.Show("注册成功！");
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }


            }
        }
        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns></returns>
        private string getPubkey()
        {
            string pubkey = string.Empty;
            try
            {
                string path = string.Empty;
                path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                path += "pubkey.xml";

                using (StreamReader sr = new StreamReader(path))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        pubkey += line;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return pubkey.Replace(" ", "");
        }

        /// <summary>
        /// 获取GUID码
        /// </summary>
        /// <returns></returns>
        private string getGUID()
        {
            string guid = string.Empty;
            try
            {
                string fileName = "guid.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        guid += line;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return guid.Replace(" ", "");
        }
    }
}
