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
            this.tabSogl = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button_CreateLetter = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button_UpdateBTI = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.button_CreatePassports = this.Factory.CreateRibbonButton();
            this.button_PassportPrint = this.Factory.CreateRibbonButton();
            this.groupHyperlinks = this.Factory.CreateRibbonGroup();
            this.button_CreateFolders = this.Factory.CreateRibbonButton();
            this.button_CreateHyperlinks = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnCopyPhotos = this.Factory.CreateRibbonButton();
            this.tabProdaction = this.Factory.CreateRibbonTab();
            this.groupPrint = this.Factory.CreateRibbonGroup();
            this.bPrintDislocations = this.Factory.CreateRibbonButton();
            this.button8 = this.Factory.CreateRibbonButton();
            this.button_InstallationPassport = this.Factory.CreateRibbonButton();
            this.button_PrintProdactionComplects = this.Factory.CreateRibbonButton();
            this.printDialogDUAddon = new System.Windows.Forms.PrintDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button_UpdateStatus = this.Factory.CreateRibbonButton();
            this.button_UpdateUNOM = this.Factory.CreateRibbonButton();
            this.tabSogl.SuspendLayout();
            this.group1.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.groupHyperlinks.SuspendLayout();
            this.group2.SuspendLayout();
            this.tabProdaction.SuspendLayout();
            this.groupPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSogl
            // 
            this.tabSogl.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabSogl.Groups.Add(this.group1);
            this.tabSogl.Groups.Add(this.group3);
            this.tabSogl.Groups.Add(this.group4);
            this.tabSogl.Groups.Add(this.group5);
            this.tabSogl.Groups.Add(this.groupHyperlinks);
            this.tabSogl.Groups.Add(this.group2);
            this.tabSogl.Label = "ДУ согласование";
            this.tabSogl.Name = "tabSogl";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "Адрес";
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
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_KLADR_Click);
            // 
            // button1
            // 
            this.button1.Label = "Улица в конец";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_ToFias_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.button_CreateLetter);
            this.group3.Items.Add(this.button3);
            this.group3.Label = "Письма";
            this.group3.Name = "group3";
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
            this.group4.Items.Add(this.button6);
            this.group4.Items.Add(this.button_UpdateBTI);
            this.group4.Items.Add(this.button_UpdateStatus);
            this.group4.Items.Add(this.button_UpdateUNOM);
            this.group4.Label = "БД";
            this.group4.Name = "group4";
            // 
            // button4
            // 
            this.button4.Label = "Обновить из БД";
            this.button4.Name = "button4";
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_UpdateByDB_Click);
            // 
            // button6
            // 
            this.button6.Label = "Перенести Владельца";
            this.button6.Name = "button6";
            this.button6.SuperTip = "Перенести сведения из графы Принадлежность в графу Примечания для неотправленных " +
    "писем";
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_ReplaceOwnerToPrim_Click);
            // 
            // button_UpdateBTI
            // 
            this.button_UpdateBTI.Label = "Проставить БТИ";
            this.button_UpdateBTI.Name = "button_UpdateBTI";
            this.button_UpdateBTI.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_UpdateBTI_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.button_CreatePassports);
            this.group5.Items.Add(this.button_PassportPrint);
            this.group5.Label = "Тех. паспорт";
            this.group5.Name = "group5";
            // 
            // button_CreatePassports
            // 
            this.button_CreatePassports.Label = "Создать";
            this.button_CreatePassports.Name = "button_CreatePassports";
            this.button_CreatePassports.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PassportCreate_Click);
            // 
            // button_PassportPrint
            // 
            this.button_PassportPrint.Label = "Печатать";
            this.button_PassportPrint.Name = "button_PassportPrint";
            this.button_PassportPrint.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PassportPrint_Click);
            // 
            // groupHyperlinks
            // 
            this.groupHyperlinks.Items.Add(this.button_CreateFolders);
            this.groupHyperlinks.Items.Add(this.button_CreateHyperlinks);
            this.groupHyperlinks.Label = "Папки и гиперссылки";
            this.groupHyperlinks.Name = "groupHyperlinks";
            // 
            // button_CreateFolders
            // 
            this.button_CreateFolders.Label = "Сделать папки";
            this.button_CreateFolders.Name = "button_CreateFolders";
            this.button_CreateFolders.SuperTip = "Создать папки с названиями в тексте выделенных ячеек, содержащиеся в выбранной в " +
    "диалог основной папке, и присвоить гиперссылки на них.";
            this.button_CreateFolders.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_CreateFolders_Click);
            // 
            // button_CreateHyperlinks
            // 
            this.button_CreateHyperlinks.Label = "Гиперссылки прибить";
            this.button_CreateHyperlinks.Name = "button_CreateHyperlinks";
            this.button_CreateHyperlinks.SuperTip = "Присвоить гиперссылки на папки с названиями в тексте выделенных ячеек, содержащие" +
    "ся в выбранной в диалоге основной папке.";
            this.button_CreateHyperlinks.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_CreateHyperlinks_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnCopyPhotos);
            this.group2.Label = "Фото ДУ";
            this.group2.Name = "group2";
            // 
            // btnCopyPhotos
            // 
            this.btnCopyPhotos.Label = "Копировать";
            this.btnCopyPhotos.Name = "btnCopyPhotos";
            this.btnCopyPhotos.SuperTip = "Копировать фото выбранных ДУ в указанную папку.";
            this.btnCopyPhotos.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCopyPhotos_Click);
            // 
            // tabProdaction
            // 
            this.tabProdaction.Groups.Add(this.groupPrint);
            this.tabProdaction.Label = "ДУ размещение";
            this.tabProdaction.Name = "tabProdaction";
            // 
            // groupPrint
            // 
            this.groupPrint.Items.Add(this.bPrintDislocations);
            this.groupPrint.Items.Add(this.button8);
            this.groupPrint.Items.Add(this.button_InstallationPassport);
            this.groupPrint.Items.Add(this.button_PrintProdactionComplects);
            this.groupPrint.Label = "Печать";
            this.groupPrint.Name = "groupPrint";
            // 
            // bPrintDislocations
            // 
            this.bPrintDislocations.Label = "Дислокации";
            this.bPrintDislocations.Name = "bPrintDislocations";
            this.bPrintDislocations.SuperTip = "Для печати дислокация выделите ячейки с уникальными номерами ДУ и нажмите эту кно" +
    "пку.";
            this.bPrintDislocations.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PrintDislocations_Click);
            // 
            // button8
            // 
            this.button8.Label = "Акты монтажа";
            this.button8.Name = "button8";
            this.button8.SuperTip = "Для печати актов монтажа выделите ячейки с уникальными номерами ДУ и нажмите эту " +
    "кнопку.";
            this.button8.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PrintAkts_Click);
            // 
            // button_InstallationPassport
            // 
            this.button_InstallationPassport.Label = "Задание монтажнику";
            this.button_InstallationPassport.Name = "button_InstallationPassport";
            this.button_InstallationPassport.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_InstallationPassport_Click);
            // 
            // button_PrintProdactionComplects
            // 
            this.button_PrintProdactionComplects.Label = "Комплект";
            this.button_PrintProdactionComplects.Name = "button_PrintProdactionComplects";
            this.button_PrintProdactionComplects.SuperTip = "Для печати комплекта документов для монтажной бригады выделите ячейки с уникальны" +
    "ми номерами ДУ и нажмите эту кнопку.";
            this.button_PrintProdactionComplects.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button_PrintProdactionComplects_Click);
            // 
            // printDialogDUAddon
            // 
            this.printDialogDUAddon.UseEXDialog = true;
            // 
            // button_UpdateStatus
            // 
            this.button_UpdateStatus.Label = "Перенести статус";
            this.button_UpdateStatus.Name = "button_UpdateStatus";
            this.button_UpdateStatus.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_UpdateStatus_Click);
            // 
            // button_UpdateUNOM
            // 
            this.button_UpdateUNOM.Label = "Перенести UNOM";
            this.button_UpdateUNOM.Name = "button_UpdateUNOM";
            this.button_UpdateUNOM.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_UpdateUNOM_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tabSogl);
            this.Tabs.Add(this.tabProdaction);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tabSogl.ResumeLayout(false);
            this.tabSogl.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.groupHyperlinks.ResumeLayout(false);
            this.groupHyperlinks.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.tabProdaction.ResumeLayout(false);
            this.tabProdaction.PerformLayout();
            this.groupPrint.ResumeLayout(false);
            this.groupPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreateFolders;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreateLetter;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_UpdateBTI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreatePassports;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupPrint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bPrintDislocations;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_PrintProdactionComplects;
        public Microsoft.Office.Tools.Ribbon.RibbonTab tabSogl;
        public Microsoft.Office.Tools.Ribbon.RibbonTab tabProdaction;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        private System.Windows.Forms.PrintDialog printDialogDUAddon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_PassportPrint;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupHyperlinks;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_CreateHyperlinks;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_InstallationPassport;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCopyPhotos;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_UpdateStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_UpdateUNOM;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
