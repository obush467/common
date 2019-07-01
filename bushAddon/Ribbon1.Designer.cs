namespace bushAddon
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        /// 

        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button_toPrinting = this.Factory.CreateRibbonButton();
            this.button_SetUNOM = this.Factory.CreateRibbonButton();
            this.button_CreateLetter = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button_CreateFolders = this.Factory.CreateRibbonButton();
            this.button6 = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.buttonGroup2 = this.Factory.CreateRibbonButtonGroup();
            this.button_PrintDislocations = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.button_UpdateBTI = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.buttonGroup2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Label = "ДУ";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Label = "Дом";
            this.group1.Name = "group1";
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.button2);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // button2
            // 
            this.button2.Label = "КЛАДР развернуть";
            this.button2.Name = "button2";
            // 
            // group2
            // 
            this.group2.Items.Add(this.button1);
            this.group2.Label = "Улица";
            this.group2.Name = "group2";
            // 
            // button1
            // 
            this.button1.Label = "Улица в конец";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button1_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.button_toPrinting);
            this.group3.Items.Add(this.button_SetUNOM);
            this.group3.Items.Add(this.button_CreateLetter);
            this.group3.Items.Add(this.button3);
            this.group3.Label = "group3";
            this.group3.Name = "group3";
            // 
            // button_toPrinting
            // 
            this.button_toPrinting.Label = "В печать";
            this.button_toPrinting.Name = "button_toPrinting";
            this.button_toPrinting.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_toPrinting_Click);
            // 
            // button_SetUNOM
            // 
            this.button_SetUNOM.Label = "Установить UNOM";
            this.button_SetUNOM.Name = "button_SetUNOM";
            this.button_SetUNOM.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_SetUNOM_Click);
            // 
            // button_CreateLetter
            // 
            this.button_CreateLetter.Label = "Сделать письмо";
            this.button_CreateLetter.Name = "button_CreateLetter";
            this.button_CreateLetter.SuperTip = "По имени фирмы в выделенной ячейке формирует список ДУ  для письма и сохраняет ег" +
    "о в общей папке. Файл имеет имя фирмы.";
            this.button_CreateLetter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_CreateLetter_Click);
            // 
            // button3
            // 
            this.button3.Label = "";
            this.button3.Name = "button3";
            // 
            // group4
            // 
            this.group4.Items.Add(this.button4);
            this.group4.Items.Add(this.button_CreateFolders);
            this.group4.Items.Add(this.button6);
            this.group4.Label = "БД";
            this.group4.Name = "group4";
            // 
            // button4
            // 
            this.button4.Label = "Обновить из БД";
            this.button4.Name = "button4";
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_UpdateByDB_Click);
            // 
            // button_CreateFolders
            // 
            this.button_CreateFolders.Label = "Сделать папки";
            this.button_CreateFolders.Name = "button_CreateFolders";
            this.button_CreateFolders.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_CreateFolders_Click);
            // 
            // button6
            // 
            this.button6.Label = "Перенести Владельца";
            this.button6.Name = "button6";
            this.button6.SuperTip = "Перенести сведения из графы Принадлежность в графу Примечания для неотправленных " +
    "писем";
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_ReplaceOwnerToPrim_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.buttonGroup2);
            this.group5.Items.Add(this.button_UpdateBTI);
            this.group5.Items.Add(this.button7);
            this.group5.Label = "group5";
            this.group5.Name = "group5";
            // 
            // buttonGroup2
            // 
            this.buttonGroup2.Items.Add(this.button_PrintDislocations);
            this.buttonGroup2.Items.Add(this.button5);
            this.buttonGroup2.Name = "buttonGroup2";
            // 
            // button_PrintDislocations
            // 
            this.button_PrintDislocations.Label = "Печать дислокаций";
            this.button_PrintDislocations.Name = "button_PrintDislocations";
            this.button_PrintDislocations.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PrintDislocations_Click);
            // 
            // button5
            // 
            this.button5.Label = "Копировать";
            this.button5.Name = "button5";
            // 
            // button_UpdateBTI
            // 
            this.button_UpdateBTI.Label = "Проставить БТИ";
            this.button_UpdateBTI.Name = "button_UpdateBTI";
            this.button_UpdateBTI.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_UpdateBTI_Click);
            // 
            // button7
            // 
            this.button7.Label = "button7";
            this.button7.Name = "button7";
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button7_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.buttonGroup2.ResumeLayout(false);
            this.buttonGroup2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreateFolders;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreateLetter;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_SetUNOM;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_toPrinting;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_PrintDislocations;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_UpdateBTI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
