using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Keyflash
{
    public partial class MainForm : Form
    {
        SerialPort port;
        bool isConnected = false;

        private string readKey(bool IsACheck)
        {
            if(!IsACheck) MessageBox.Show("Приложите ключ для чтения");
            port.WriteLine("0"); // отдать команду на чтение
            return port.ReadTo("T"); // и считать код до терминатора          
        }
        
        private bool writeKey(string bytesToWrite, int KeyType)
        {
            MessageBox.Show("Приложите ключ для записи");
            port.DiscardInBuffer(); // очистка порта на всякий случай
            port.DiscardOutBuffer();
            byte[] output = new byte[8];
            int i = 0;
            foreach(string s in bytesToWrite.Split(':')) // преобразование введенного кода в байтовый массив
            {
                output[i] = Convert.ToByte(s, 16);
                i++;
            }
            if (KeyType == 1) // выбор режима записи
                port.WriteLine("1");
            else port.WriteLine("2");
            port.Write(output, 0, 8); // отправка кода
            Thread.Sleep(1000);
            if (NewCodeBox.Text == readKey(true)) // проверка записи
                return true;
            else
                return false;
        }
        
        private void disconnect()  // вызывается для перевода устройства в режим ожидания
        {
            port.Write("Z"); // команда на отключение
            port.Close();
            LogBox.Items.Add("Устройство отключено");
            isConnected = false; // установка флага подключения
            rw1990Radio.Enabled = false; // блокировка управления
            rw2004Radio.Enabled = false;
            groupBox2.Enabled = false;
            ConnectButton.Text = "Подключиться к устройству";
            ConnectedLabel.Text = "Устройство: не подключено";
            FirmwareVerLabel.Text = "Версия прошивки: N/A";

        }

        private int CheckMode()
        {
            if (rw1990Radio.Checked)
                return 1;  // тип 1 - rw1990
            else return 2; // тип 2 - rw2004     
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            string k = readKey(false); // считать ключ
            if (k != null) // по идее, null там в принципе быть не может (только FF)
                CurrentCodeBox.Text = k;
            else CurrentCodeBox.Text = "WTF?..";
            LogBox.Items.Add("Чтение выполнено");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!isConnected) // проверка, не подключено ли уже устройство
            {
                if (ComPortBox.SelectedItem == null) // защита от дурака
                {
                    MessageBox.Show("Выберите порт");
                    return;
                }
                port = new SerialPort(ComPortBox.SelectedItem.ToString(), 9600); // открытие выбранного порта на скорости 9600 бод
                port.WriteTimeout = 3000;
                port.ReadTimeout = 3000;
                try { port.Open(); }
                catch (UnauthorizedAccessException ex)
                {
                    LogBox.Items.Add(ex.ToString());
                    LogBox.Items.Add("Невозможно открыть порт");
                    return;
                }               
                catch (Exception ex)
                {
                    LogBox.Items.Add(ex.ToString());
                    LogBox.Items.Add("Неизвестная ошибка");
                    MessageBox.Show("Произошла неизвестная ошибка. Подробности занесены в журнал.");
                    return;
                }
                try
                {
                    if (port.ReadLine() == "Keyflash") // ожидание маячка
                    {
                        ConnectedLabel.Text = "Устройство: ОК";
                        FirmwareVerLabel.Text = "Версия прошивки: " + port.ReadLine(); // чтение номера версии
                        port.Write("K"); // подтверждение подключения
                        isConnected = true; // установка флага подключения
                        LogBox.Items.Add("Подключение выполнено");
                        port.DiscardInBuffer(); // очистка порта
                        port.DiscardOutBuffer();
                        ConnectButton.Text = "Отключиться";
                        rw1990Radio.Enabled = true; // разблокировка управления
                        rw2004Radio.Enabled = true;
                        groupBox2.Enabled = true;
                    }
                    else port.Close();
                }
                catch (TimeoutException)
                {
                    LogBox.Items.Add("Устройство не найдено");
                    MessageBox.Show("Устройство не подключено или не отвечает. Проверьте номер порта. Если устройство подключено и порт выбран верно, переподключите его или нажмите кнопку Reset (рядом с USB-портом).");
                    port.Close();
                    return;
                }
            }
            else
                disconnect(); 
        } 

        private void WriteButton_Click(object sender, EventArgs e)
        {
            if (NewCodeBox.Text == String.Empty)
            {
                MessageBox.Show("Введите код для записи");
                return;
            }
            
            if (writeKey(NewCodeBox.Text, CheckMode()))
                LogBox.Items.Add("Запись прошла успешно");
            else
                LogBox.Items.Add("Ошибка записи");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogBox.Items.Add("Поиск COM-портов...");
            ComPortBox.Items.AddRange(SerialPort.GetPortNames()); // сканирование портов
            LogBox.Items.Add(String.Format("Найдено {0} COM-портов", ComPortBox.Items.Count)); // и занесение их списка в меню выбора
        }

        private void LogCleanButton_Click(object sender, EventArgs e)
        {
            LogBox.Items.Clear(); // очистка лога
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isConnected) disconnect(); // отключение при закрытии
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
             writeKey(readKey(false), CheckMode()); // копирование ключа
        }
    }
}
