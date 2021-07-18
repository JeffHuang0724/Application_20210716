using System;
using System.Drawing;
using System.Windows.Forms;

namespace Application_20210716
{
    public partial class VehicleLicenseTaxForm : Form
    {
        private string[] _carType = new string[] { "機車", "貨車", "大客車", "自用小客車", "營業用小客車" };
        private string[] _motorcycleCC = new string[] { "150以下 / 12HP以下(12.2PS以下)", "151-250 / 12.1-20HP(12.3-20.3PS)", "251-500 / 20.1HP以上(20.4PS以上)", "501-600", "601-1200", "1201-1800", "1801或以上" };
        private string[] _truckCC = new string[] { "500以下", "501-600", "601-1200", "1201-1800", "1801-2400", "2401-3000 / 138HP以下(140.1PS以下)", "3001-3600", "3601-4200 / 138.1-200HP(140.2-203.0PS)", "4201-4800", "4801-5400 / 200.1-247HP(203.1-250.7PS)", "5401-6000", "6001-6600 / 247.1-286HP(250.8-290.3PS)", "6601-7200", "7201-7800 / 286.1-336HP(290.4-341.0PS)", "7801-8400", "8401-9000 / 336.1-361HP(341.1-366.4PS)", "9001-9600", "9601-10200 / 361.1HP以上(366.5PS以上)", "10201以上" };
        private string[] _coachCC = new string[] { "600以下", "601-1200", "1201-1800", "1801-2400", "2401-3000 / 138HP以下(140.1PS以下)", "3001-3600", "3601-4200 / 138.1-200HP(140.2-203.0PS)", "4201-4800", "4801-5400 / 200.1-247HP(203.1-250.7PS)", "5401-6000", "6001-6600 / 247.1-286HP(250.8-290.3PS)", "6601-7200", "7201-7800 / 286.1-336HP(290.4-341.0PS)", "7801-8400", "8401-9000 / 336.1-361HP(341.1-366.4PS)", "9001-9600", "9601-10200 / 361.1HP以上(366.5PS以上)", "10201以上" };
        private string[] _privatePassengerCarCC = new string[] { "500以下 / 38HP以下(38.6PS以下)", "501~600 / 38.1-56HP(38.7-56.8PS)", "601~1200 / 56.1-83HP(56.9-84.2PS)", "1201~1800 / 83.1-182HP(84.3-184.7PS)", "1801~2400 / 182.1-262HP(184.8-265.9PS)", "2401~3000 / 262.1-322HP(266-326.8PS)", "3001-4200 / 322.1-414HP(326.9-420.2PS", "4201-5400 / 414.1-469HP(420.3-476.0PS)", "5401-6600 / 469.1-509HP(476.1-516.6PS)", "6601-7800 / 509.1HP以上(516.7PS以上)", "7801以上" };
        private string[] _commercialPassengerCarrCC = new string[] { "500以下 / 38HP以下(38.6PS以下)", "501~600 / 38.1-56HP(38.7-56.8PS)", "601~1200 / 56.1-83HP(56.9-84.2PS)", "1201~1800 / 83.1-182HP(84.3-184.7PS)", "1801~2400 / 182.1-262HP(184.8-265.9PS)", "2401~3000 / 262.1-322HP(266-326.8PS)", "3001-4200 / 322.1-414HP(326.9-420.2PS)", "4201-5400 / 414.1-469HP(420.3-476.0PS)", "5401-6600 / 469.1-509HP(476.1-516.6PS)", "6601-7800 / 509.1HP以上(516.7PS以上)", "7801以上" };
        private string carType = string.Empty;
        private string displacement = string.Empty;
        private int countingPerior, daysInYear;
        private decimal baseTax, totalResult;
        public VehicleLicenseTaxForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        //  RadioButton - 全年度(隱藏依期間之選項)
        private void radPerior1_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Visible = false;
            this.dateTimePickerStart.Visible = false;
            this.label8.Visible = false;
            this.dateTimePickerEnd.Visible = false;
        }

        // RadioButton - 依期間(顯示依期間之選項)
        private void radPerior2_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Visible = true;
            this.dateTimePickerStart.Visible = true;
            this.label8.Visible = true;
            this.dateTimePickerEnd.Visible = true;
        }

        // ComboBox - 選擇用途時連動汽缸CC數資料
        private void comboBoxCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 清除CC數 選項
            this.comboBoxDisplacement.Items.Clear();
            // 動態生成
            switch (comboBoxCarType.SelectedItem.ToString())
            {
                case "機車":
                    this.comboBoxDisplacement.Items.AddRange(_motorcycleCC);
                    this.comboBoxDisplacement.SelectedIndex = 0;
                    break;
                case "貨車":
                    this.comboBoxDisplacement.Items.AddRange(_truckCC);
                    this.comboBoxDisplacement.SelectedIndex = 0;
                    break;
                case "大客車":
                    this.comboBoxDisplacement.Items.AddRange(_coachCC);
                    this.comboBoxDisplacement.SelectedIndex = 0;
                    break;
                case "自用小客車":
                    this.comboBoxDisplacement.Items.AddRange(_privatePassengerCarCC);
                    this.comboBoxDisplacement.SelectedIndex = 0;
                    break;
                case "營業用小客車":
                    this.comboBoxDisplacement.Items.AddRange(_commercialPassengerCarrCC);
                    this.comboBoxDisplacement.SelectedIndex = 0;
                    break;
            }
        }

        // Button - 開始計算
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 確定終止日不得早於起始日
            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                MessageBox.Show("終止日不得早於起始日", "日期錯誤", MessageBoxButtons.OK);
                return;
            }
            // 清空之前的試算內容
            this.txtResult.Text = string.Empty;
            this.totalResult = 0;
            // 調整button位置
            this.btnCalculate.Location = (new Point(250, 530));
            this.btnReset.Location = (new Point(500, 530));
            this.txtResult.Visible = true;

            GetTaxInfo();
            CalculateTax();
        }

        // Button - 取消重填
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Init();
        }

        /// <summary> 初始化 </summary>
        private void Init()
        {
            // 數值初始化
            carType = string.Empty;
            displacement = string.Empty;
            countingPerior = 0;
            daysInYear = 0;
            baseTax = 0;
            totalResult = 0;
            // 介面初始化 - 使用期間初始化
            this.radPerior1.Checked = true;
            this.label7.Visible = false;
            this.dateTimePickerStart.Visible = false;
            this.label8.Visible = false;
            this.dateTimePickerEnd.Visible = false;
            this.dateTimePickerStart.Value = new DateTime(DateTime.Now.Year, 01, 01);
            this.dateTimePickerEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            // 介面初始化 - 用途初始化
            if (this.comboBoxCarType.Items.Count == 0)
            {
                this.comboBoxCarType.Items.AddRange(_carType);
            }
            this.comboBoxCarType.SelectedIndex = 0;
            // 介面初始化 - 汽缸CC數／馬達馬力
            if (this.comboBoxDisplacement.Items.Count == 0)
            {
                this.comboBoxDisplacement.Items.AddRange(_motorcycleCC);
            }
            this.comboBoxDisplacement.SelectedIndex = 0;
            // 介面初始化 - 試算結果初始化
            this.txtResult.Text = "";
            this.txtResult.Visible = false;
            this.btnCalculate.Location = (new Point(250, 350));
            this.btnReset.Location = (new Point(500, 350));
        }

        /// <summary> 計算稅額 </summary>
        private void CalculateTax()
        {
            DateTime userStartDate, userEndDate;
            int startYear, endYear;

            // 如果勾選全期間，起訖日則以當年度來計算
            if (radPerior1.Checked == true)
            {
                startYear = DateTime.Now.Year;
                endYear = DateTime.Now.Year;
                userStartDate = new DateTime(DateTime.Now.Year, 1, 1);
                userEndDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
            // 如果勾選特定期間，起訖日則以使用者勾選日期來計算
            else
            {
                startYear = dateTimePickerStart.Value.Year;
                endYear = dateTimePickerEnd.Value.Year;
                userStartDate = dateTimePickerStart.Value;
                userEndDate = dateTimePickerEnd.Value;
            }

            for (int i = startYear; i <= endYear; i++)
            {
                DateTime startDate;
                DateTime endDate;
                if (new DateTime(i, 1, 1) <= userStartDate)
                {
                    startDate = userStartDate;
                    if (new DateTime(i, 12, 31) > userEndDate)
                    {
                        endDate = userEndDate;
                        countingPerior = (endDate - startDate).Days + 1;
                        daysInYear = new DateTime(i, 12, 31).DayOfYear;
                        this.txtResult.Text += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        this.txtResult.Text += $"計算天數: {countingPerior} {Environment.NewLine}";
                        this.txtResult.Text += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        this.txtResult.Text += $"用途: {carType} {Environment.NewLine}";
                        this.txtResult.Text += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        this.txtResult.Text += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                    else
                    {
                        endDate = new DateTime(i, 12, 31);
                        countingPerior = (endDate - startDate).Days + 1;
                        daysInYear = new DateTime(i, 12, 31).DayOfYear;
                        this.txtResult.Text += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        this.txtResult.Text += $"計算天數: {countingPerior} {Environment.NewLine}";
                        this.txtResult.Text += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        this.txtResult.Text += $"用途: {carType} {Environment.NewLine}";
                        this.txtResult.Text += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        this.txtResult.Text += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                }
                else
                {
                    startDate = new DateTime(i, 1, 1);
                    if (new DateTime(i, 12, 31) > userEndDate)
                    {
                        endDate = userEndDate;
                        countingPerior = (endDate - startDate).Days + 1;
                        daysInYear = new DateTime(i, 12, 31).DayOfYear;
                        this.txtResult.Text += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        this.txtResult.Text += $"計算天數: {countingPerior} {Environment.NewLine}";
                        this.txtResult.Text += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        this.txtResult.Text += $"用途: {carType} {Environment.NewLine}";
                        this.txtResult.Text += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        this.txtResult.Text += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                    else
                    {
                        endDate = new DateTime(i, 12, 31);
                        countingPerior = (endDate - startDate).Days + 1;
                        daysInYear = new DateTime(i, 12, 31).DayOfYear;
                        this.txtResult.Text += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        this.txtResult.Text += $"計算天數: {countingPerior} {Environment.NewLine}";
                        this.txtResult.Text += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        this.txtResult.Text += $"用途: {carType} {Environment.NewLine}";
                        this.txtResult.Text += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        this.txtResult.Text += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                }
            }
            // 如起訖日為不同年度則顯示全部應繳稅額
            if (startYear != endYear)
            {
                this.txtResult.Text += $"全部應納稅額: 共 {totalResult.ToString("N0")} 元";
            }
        }

        /// <summary> 取得稅率 </summary>
        private void GetTaxInfo()
        {
            displacement = comboBoxDisplacement.SelectedItem as string;
            carType = comboBoxCarType.SelectedItem as string;
            switch (carType)
            {
                case "機車":
                    switch (displacement)
                    {
                        case "150以下 / 12HP以下(12.2PS以下)":
                            baseTax = 0;
                            break;
                        case "151-250 / 12.1-20HP(12.3-20.3PS)":
                            baseTax = 800;
                            break;
                        case "251-500 / 20.1HP以上(20.4PS以上)":
                            baseTax = 1620;
                            break;
                        case "501-600":
                            baseTax = 2160;
                            break;
                        case "601-1200":
                            baseTax = 4320;
                            break;
                        case "1201-1800":
                            baseTax = 7120;
                            break;
                        case "1801或以上":
                            baseTax = 11230;
                            break;
                    }
                    break;
                case "貨車":
                    switch (displacement)
                    {
                        case "500以下":
                            baseTax = 900;
                            break;
                        case "501-600":
                            baseTax = 1080;
                            break;
                        case "601-1200":
                            baseTax = 1800;
                            break;
                        case "1201-1800":
                            baseTax = 2700;
                            break;
                        case "1801-2400":
                            baseTax = 3600;
                            break;
                        case "2401-3000 / 138HP以下(140.1PS以下)":
                            baseTax = 4500;
                            break;
                        case "3001-3600":
                            baseTax = 5400;
                            break;
                        case "3601-4200 / 138.1-200HP(140.2-203.0PS)":
                            baseTax = 6300;
                            break;
                        case "4201-4800":
                            baseTax = 7200;
                            break;
                        case "4801-5400 / 200.1-247HP(203.1-250.7PS)":
                            baseTax = 8100;
                            break;
                        case "5401-6000":
                            baseTax = 9000;
                            break;
                        case "6001-6600 / 247.1-286HP(250.8-290.3PS)":
                            baseTax = 9900;
                            break;
                        case "6601-7200":
                            baseTax = 10800;
                            break;
                        case "7201-7800 / 286.1-336HP(290.4-341.0PS)":
                            baseTax = 11700;
                            break;
                        case "7801-8400":
                            baseTax = 12600;
                            break;
                        case "8401-9000 / 336.1-361HP(341.1-366.4PS)":
                            baseTax = 13500;
                            break;
                        case "9001-9600":
                            baseTax = 14400;
                            break;
                        case "9601-10200 / 361.1HP以上(366.5PS以上)":
                            baseTax = 15300;
                            break;
                        case "10201以上":
                            baseTax = 16200;
                            break;
                    }
                    break;
                case "大客車":
                    switch (displacement)
                    {
                        case "600以下":
                            baseTax = 1080;
                            break;
                        case "601-1200":
                            baseTax = 1800;
                            break;
                        case "1201-1800":
                            baseTax = 2700;
                            break;
                        case "1801-2400":
                            baseTax = 3600;
                            break;
                        case "2401-3000 / 138HP以下(140.1PS以下)":
                            baseTax = 4500;
                            break;
                        case "3001-3600":
                            baseTax = 5400;
                            break;
                        case "3601-4200 / 138.1-200HP(140.2-203.0PS)":
                            baseTax = 6300;
                            break;
                        case "4201-4800":
                            baseTax = 7200;
                            break;
                        case "4801-5400 / 200.1-247HP(203.1-250.7PS)":
                            baseTax = 8100;
                            break;
                        case "5401-6000":
                            baseTax = 9000;
                            break;
                        case "6001-6600 / 247.1-286HP(250.8-290.3PS)":
                            baseTax = 9900;
                            break;
                        case "6601-7200":
                            baseTax = 10800;
                            break;
                        case "7201-7800 / 286.1-336HP(290.4-341.0PS)":
                            baseTax = 11700;
                            break;
                        case "7801-8400":
                            baseTax = 12600;
                            break;
                        case "8401-9000 / 336.1-361HP(341.1-366.4PS)":
                            baseTax = 13500;
                            break;
                        case "9001-9600":
                            baseTax = 14400;
                            break;
                        case "9601-10200 / 361.1HP以上(366.5PS以上)":
                            baseTax = 15300;
                            break;
                        case "10201以上":
                            baseTax = 16200;
                            break;
                    }
                    break;
                case "自用小客車":
                    switch (displacement)
                    {
                        case "500以下 / 38HP以下(38.6PS以下)":
                            baseTax = 1620;
                            break;
                        case "501~600 / 38.1-56HP(38.7-56.8PS)":
                            baseTax = 2160;
                            break;
                        case "601~1200 / 56.1-83HP(56.9-84.2PS)":
                            baseTax = 4320;
                            break;
                        case "1201~1800 / 83.1-182HP(84.3-184.7PS)":
                            baseTax = 7120;
                            break;
                        case "1801~2400 / 182.1-262HP(184.8-265.9PS)":
                            baseTax = 11230;
                            break;
                        case "2401~3000 / 262.1-322HP(266-326.8PS)":
                            baseTax = 15210;
                            break;
                        case "3001-4200 / 322.1-414HP(326.9-420.2PS":
                            baseTax = 28220;
                            break;
                        case "4201-5400 / 414.1-469HP(420.3-476.0PS)":
                            baseTax = 46170;
                            break;
                        case "5401-6600 / 469.1-509HP(476.1-516.6PS)":
                            baseTax = 69690;
                            break;
                        case "6601-7800 / 509.1HP以上(516.7PS以上)":
                            baseTax = 117000;
                            break;
                        case "7801以上":
                            baseTax = 151200;
                            break;
                    }
                    break;
                case "營業用小客車":
                    switch (displacement)
                    {
                        case "500以下 / 38HP以下(38.6PS以下)":
                            baseTax = 900;
                            break;
                        case "501~600 / 38.1-56HP(38.7-56.8PS)":
                            baseTax = 1260;
                            break;
                        case "601~1200 / 56.1-83HP(56.9-84.2PS)":
                            baseTax = 2160;
                            break;
                        case "1201~1800 / 83.1-182HP(84.3-184.7PS)":
                            baseTax = 3060;
                            break;
                        case "1801~2400 / 182.1-262HP(184.8-265.9PS)":
                            baseTax = 6480;
                            break;
                        case "2401~3000 / 262.1-322HP(266-326.8PS)":
                            baseTax = 9900;
                            break;
                        case "3001-4200 / 322.1-414HP(326.9-420.2PS":
                            baseTax = 16380;
                            break;
                        case "4201-5400 / 414.1-469HP(420.3-476.0PS)":
                            baseTax = 24300;
                            break;
                        case "5401-6600 / 469.1-509HP(476.1-516.6PS)":
                            baseTax = 33660;
                            break;
                        case "6601-7800 / 509.1HP以上(516.7PS以上)":
                            baseTax = 44460;
                            break;
                        case "7801以上":
                            baseTax = 56700;
                            break;
                    }
                    break;
            }
        }
    }
}
