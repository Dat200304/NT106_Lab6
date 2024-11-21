using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lab06_C
{
    public partial class Form1 : Form
    {
        //Danh sách các biến 
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private int minRange;
        private int maxRange;
        private System.Windows.Forms.Timer autoPlayTimer;
        private Random random = new Random();
        private HashSet<int> guessedNumbers = new HashSet<int>();
        private bool isAutoPlaying = false;

        // Thêm các biến để lưu trữ thông tin người chơi
        private int correctGuesses = 0;
        private int incorrectGuesses = 0;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ConnectToServer();
        }


        //Kết nối tới Server 
        private async Task ConnectToServer()
        {
            client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 8888);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            Task.Run(() => ListenToServer());
        }


        //Lắng nghe từ Server để nhận phạm vi đoán số, số vòng chơi ,...
        private async Task ListenToServer()
        {
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                {
                    var message = JsonConvert.DeserializeObject<ServerMessage>(line);
                    ProcessServerMessage(message);
                }
            }
        }

        //Xử lí thông điệp được gửi từ Server
        private void ProcessServerMessage(ServerMessage message)
        {
            switch (message.Type)
            {
                case "range":
                case "new_round":                            //Vòng mới 
                    minRange = message.MinRange;
                    maxRange = message.MaxRange;
                    guessedNumbers.Clear();
                    Invoke((MethodInvoker)delegate
                    {
                        lblRange.Text = $"{minRange} - {maxRange}";
                        lblMessage.Text = "Vòng mới đã bắt đầu! ";
                        txtRoundsLeft.Text = message.RoundsLeft.ToString();
                        txtGuess.Text = "";
                    });
                    break;
                case "winner":                               //Người chiến thắng nếu đoán đúng
                    var winner = message.Winner;
                    if (winner == txtName.Text)
                    {
                        correctGuesses++;
                        score += 10;
                    }
                    Invoke((MethodInvoker)delegate
                    {
                        lblMessage.Text = $"{winner} đã chiến thắng. Điểm của bạn : {score}";
                        txtRoundsLeft.Text = message.RoundsLeft.ToString();
                        autoPlayTimer?.Stop();
                    });
                    break;
                case "incorrect_guess":                       //Đoán sai 
                    incorrectGuesses++;
                    score = message.Score; // Cập nhật điểm từ Server 
                    Invoke((MethodInvoker)delegate
                    {
                        lblMessage.Text = $"Đoán sai : {message.Guess}. Điểm của bạn : {score}";
                        txtGuess.Text = "";
                    });
                    break;
                case "end_game":                              //Kết thúc game 
                    // Hiện tất cả thông báo cuối cùng khi kết thúc game 
                    Invoke((MethodInvoker)delegate
                    {
                        lblMessage.Text = $"Game over! Người thắng : {message.Winner}\nSố câu đúng của bạn : {correctGuesses}\nSố câu sai của bạn : {incorrectGuesses}\nĐiểm của bạn : {score}";
                    });
                    break;
            }
        }

        //Nút gửi Số Đoán bằng tay 
        private async void btnSubmit_Click_1(object sender, EventArgs e)
        {
            var guess = new Guess
            {
                Name = txtName.Text,
                Number = int.Parse(txtGuess.Text)
            };
            var guessJson = JsonConvert.SerializeObject(guess);
            await writer.WriteLineAsync(guessJson);
        }


        //Hàm tự động đoán số 
        private async void MakeAutoGuess()
        {
            int autoGuess;
            do
            {
                autoGuess = random.Next(minRange, maxRange + 1);
            } while (guessedNumbers.Contains(autoGuess));

            guessedNumbers.Add(autoGuess);

            Invoke((MethodInvoker)delegate
            {
                label4.Text = autoGuess.ToString(); // Hiển thị số ngẫu nhiên lên label4
            });

            var guess = new Guess
            {
                Name = txtName.Text,
                Number = autoGuess
            };
            var guessJson = JsonConvert.SerializeObject(guess);
            await writer.WriteLineAsync(guessJson);
        }


        //Nút kích hoạt chế độ Tự động đoán số 
        private void btnAutoPlay_Click_1(object sender, EventArgs e)
        {
            isAutoPlaying = !isAutoPlaying;
            if (isAutoPlaying)
            {
                lblMessage.Text = "Auto play is ON";
                StartAutoPlay();
            }
            else
            {
                lblMessage.Text = "Auto play is OFF";
                autoPlayTimer?.Stop();
            }
        }
        

        //Hàm bắt đầu tự động đoán 
        private void StartAutoPlay()
        {
            autoPlayTimer = new System.Windows.Forms.Timer();
            autoPlayTimer.Interval = 3000; // Mỗi lần dự đoán cách 3 giây 
            autoPlayTimer.Tick += (s, e) => MakeAutoGuess();
            autoPlayTimer.Start();
            MakeAutoGuess(); 
        }

        public class ServerMessage
        {
            public string Type { get; set; }
            public int MinRange { get; set; }
            public int MaxRange { get; set; }
            public string Winner { get; set; }
            public int SecretNumber { get; set; }
            public int RoundsLeft { get; set; }
            public int Guess { get; set; }
            public int Score { get; set; }
            public int CorrectGuesses { get; set; }
            public int IncorrectGuesses { get; set; }
        }

        public class Guess
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }
    }
}
