using CryptoMarketViewer.Services;
using CryptoMarketViewer.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMarketViewer.Forms
{
    public partial class MainForm : Form
    {
        private readonly IExchangeService _binanceService = new BinanceService();
        private readonly IExchangeService _bybitService = new BybitService();
        private readonly IExchangeService _kucoinService = new KucoinService();
        private readonly IExchangeService _bitgetService = new BitgetService();

        private readonly Timer _timer = new Timer(); // Таймер для обновления котировок

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
            SetupTimer();
        }

        private void SetupForm()
        {
            // Настройка формы
            this.Text = "Crypto Market Viewer";
            this.Size = new System.Drawing.Size(400, 300);

            // Выпадающий список для выбора пары
            var comboBoxSymbol = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(150, 21)
            };
            comboBoxSymbol.Items.AddRange(new string[] { "BTCUSDT", "ETHUSDT", "BNBUSDT" });
            comboBoxSymbol.SelectedIndex = 0;

            // Метки для отображения цен
            var labelBinance = new Label { Location = new System.Drawing.Point(20, 60), AutoSize = true, Text = "Binance: N/A" };
            var labelBybit = new Label { Location = new System.Drawing.Point(20, 90), AutoSize = true, Text = "Bybit: N/A" };
            var labelKucoin = new Label { Location = new System.Drawing.Point(20, 120), AutoSize = true, Text = "Kucoin: N/A" };
            var labelBitget = new Label { Location = new System.Drawing.Point(20, 150), AutoSize = true, Text = "Bitget: N/A" };

            // Добавление элементов на форму
            this.Controls.Add(comboBoxSymbol);
            this.Controls.Add(labelBinance);
            this.Controls.Add(labelBybit);
            this.Controls.Add(labelKucoin);
            this.Controls.Add(labelBitget);
        }

        private void SetupTimer()
        {
            _timer.Interval = 5000; // Интервал в миллисекундах (5 секунд)
            _timer.Tick += Timer_Tick; // Подписываемся на событие Tick
            _timer.Start(); // Запускаем таймер
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Получаем выбранную пару из ComboBox
            var comboBoxSymbol = this.Controls[0] as ComboBox;
            string symbol = comboBoxSymbol?.SelectedItem?.ToString() ?? "BTCUSDT";

            // Получаем и обновляем котировки
            await GetPricesAsync(symbol);
        }

        private async Task GetPricesAsync(string symbol)
        {
            var binancePrice = await _binanceService.GetPriceAsync(symbol);
            var bybitPrice = await _bybitService.GetPriceAsync(symbol);
            var kucoinPrice = await _kucoinService.GetPriceAsync(symbol);
            var bitgetPrice = await _bitgetService.GetPriceAsync(symbol);

            // Обновление меток
            this.Controls[1].Text = $"Binance: {binancePrice?.ToString() ?? "N/A"}";
            this.Controls[2].Text = $"Bybit: {bybitPrice?.ToString() ?? "N/A"}";
            this.Controls[3].Text = $"Kucoin: {kucoinPrice?.ToString() ?? "N/A"}";
            this.Controls[4].Text = $"Bitget: {bitgetPrice?.ToString() ?? "N/A"}";
        }
    }
}