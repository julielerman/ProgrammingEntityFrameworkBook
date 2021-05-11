namespace Chapter8WindowsForm
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label addDateLabel;
      System.Windows.Forms.Label contactIDLabel;
      System.Windows.Forms.Label firstNameLabel;
      System.Windows.Forms.Label lastNameLabel;
      System.Windows.Forms.Label modifiedDateLabel;
      System.Windows.Forms.Label titleLabel;
      System.Windows.Forms.Label initialDateLabel;
      System.Windows.Forms.Label notesLabel;
      System.Windows.Forms.Label nameLabel;
      System.Windows.Forms.Label nameLabel1;
      System.Windows.Forms.Label nameLabel2;
      System.Windows.Forms.Label nameLabel3;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.Label label1;
      this.customerBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
      this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
      this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
      this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.customerBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
      this.addDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.contactIDTextBox = new System.Windows.Forms.TextBox();
      this.firstNameTextBox = new System.Windows.Forms.TextBox();
      this.lastNameTextBox = new System.Windows.Forms.TextBox();
      this.modifiedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.titleTextBox = new System.Windows.Forms.TextBox();
      this.initialDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.notesTextBox = new System.Windows.Forms.TextBox();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.nameTextBox1 = new System.Windows.Forms.TextBox();
      this.nameTextBox2 = new System.Windows.Forms.TextBox();
      this.nameTextBox3 = new System.Windows.Forms.TextBox();
      this.reservationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.reservationsDataGridView = new System.Windows.Forms.DataGridView();
      this.reservationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.resDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tripStartColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tripEndColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.destinationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.activity1Combo = new System.Windows.Forms.ComboBox();
      this.dest1Combo = new System.Windows.Forms.ComboBox();
      this.activityBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.activityComboBox = new System.Windows.Forms.ComboBox();
      this.destinationBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.destinationComboBox = new System.Windows.Forms.ComboBox();
      addDateLabel = new System.Windows.Forms.Label();
      contactIDLabel = new System.Windows.Forms.Label();
      firstNameLabel = new System.Windows.Forms.Label();
      lastNameLabel = new System.Windows.Forms.Label();
      modifiedDateLabel = new System.Windows.Forms.Label();
      titleLabel = new System.Windows.Forms.Label();
      initialDateLabel = new System.Windows.Forms.Label();
      notesLabel = new System.Windows.Forms.Label();
      nameLabel = new System.Windows.Forms.Label();
      nameLabel1 = new System.Windows.Forms.Label();
      nameLabel2 = new System.Windows.Forms.Label();
      nameLabel3 = new System.Windows.Forms.Label();
      label1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.customerBindingNavigator)).BeginInit();
      this.customerBindingNavigator.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.reservationsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.destinationBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // addDateLabel
      // 
      addDateLabel.AutoSize = true;
      addDateLabel.Location = new System.Drawing.Point(51, 42);
      addDateLabel.Name = "addDateLabel";
      addDateLabel.Size = new System.Drawing.Size(55, 13);
      addDateLabel.TabIndex = 1;
      addDateLabel.Text = "Add Date:";
      // 
      // contactIDLabel
      // 
      contactIDLabel.AutoSize = true;
      contactIDLabel.Location = new System.Drawing.Point(51, 67);
      contactIDLabel.Name = "contactIDLabel";
      contactIDLabel.Size = new System.Drawing.Size(61, 13);
      contactIDLabel.TabIndex = 3;
      contactIDLabel.Text = "Contact ID:";
      // 
      // firstNameLabel
      // 
      firstNameLabel.AutoSize = true;
      firstNameLabel.Location = new System.Drawing.Point(51, 93);
      firstNameLabel.Name = "firstNameLabel";
      firstNameLabel.Size = new System.Drawing.Size(60, 13);
      firstNameLabel.TabIndex = 5;
      firstNameLabel.Text = "First Name:";
      // 
      // lastNameLabel
      // 
      lastNameLabel.AutoSize = true;
      lastNameLabel.Location = new System.Drawing.Point(51, 119);
      lastNameLabel.Name = "lastNameLabel";
      lastNameLabel.Size = new System.Drawing.Size(61, 13);
      lastNameLabel.TabIndex = 7;
      lastNameLabel.Text = "Last Name:";
      // 
      // modifiedDateLabel
      // 
      modifiedDateLabel.AutoSize = true;
      modifiedDateLabel.Location = new System.Drawing.Point(51, 146);
      modifiedDateLabel.Name = "modifiedDateLabel";
      modifiedDateLabel.Size = new System.Drawing.Size(76, 13);
      modifiedDateLabel.TabIndex = 9;
      modifiedDateLabel.Text = "Modified Date:";
      // 
      // titleLabel
      // 
      titleLabel.AutoSize = true;
      titleLabel.Location = new System.Drawing.Point(51, 171);
      titleLabel.Name = "titleLabel";
      titleLabel.Size = new System.Drawing.Size(30, 13);
      titleLabel.TabIndex = 11;
      titleLabel.Text = "Title:";
      // 
      // initialDateLabel
      // 
      initialDateLabel.AutoSize = true;
      initialDateLabel.Location = new System.Drawing.Point(51, 266);
      initialDateLabel.Name = "initialDateLabel";
      initialDateLabel.Size = new System.Drawing.Size(60, 13);
      initialDateLabel.TabIndex = 17;
      initialDateLabel.Text = "Initial Date:";
      // 
      // notesLabel
      // 
      notesLabel.AutoSize = true;
      notesLabel.Location = new System.Drawing.Point(51, 295);
      notesLabel.Name = "notesLabel";
      notesLabel.Size = new System.Drawing.Size(38, 13);
      notesLabel.TabIndex = 19;
      notesLabel.Text = "Notes:";
      // 
      // nameLabel
      // 
      nameLabel.AutoSize = true;
      nameLabel.Location = new System.Drawing.Point(64, 203);
      nameLabel.Name = "nameLabel";
      nameLabel.Size = new System.Drawing.Size(81, 13);
      nameLabel.TabIndex = 20;
      nameLabel.Text = "Primary Activity:";
      // 
      // nameLabel1
      // 
      nameLabel1.AutoSize = true;
      nameLabel1.Location = new System.Drawing.Point(64, 234);
      nameLabel1.Name = "nameLabel1";
      nameLabel1.Size = new System.Drawing.Size(100, 13);
      nameLabel1.TabIndex = 21;
      nameLabel1.Text = "Primary Destination:";
      // 
      // nameLabel2
      // 
      nameLabel2.AutoSize = true;
      nameLabel2.Location = new System.Drawing.Point(343, 201);
      nameLabel2.Name = "nameLabel2";
      nameLabel2.Size = new System.Drawing.Size(95, 13);
      nameLabel2.TabIndex = 22;
      nameLabel2.Text = "Secondary Activity";
      // 
      // nameLabel3
      // 
      nameLabel3.AutoSize = true;
      nameLabel3.Location = new System.Drawing.Point(343, 230);
      nameLabel3.Name = "nameLabel3";
      nameLabel3.Size = new System.Drawing.Size(117, 13);
      nameLabel3.TabIndex = 23;
      nameLabel3.Text = "Secondary Destination:";
      // 
      // customerBindingNavigator
      // 
      this.customerBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
      this.customerBindingNavigator.BindingSource = this.customerBindingSource;
      this.customerBindingNavigator.CountItem = this.bindingNavigatorCountItem;
      this.customerBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
      this.customerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.customerBindingNavigatorSaveItem});
      this.customerBindingNavigator.Location = new System.Drawing.Point(0, 0);
      this.customerBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
      this.customerBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
      this.customerBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
      this.customerBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
      this.customerBindingNavigator.Name = "customerBindingNavigator";
      this.customerBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
      this.customerBindingNavigator.Size = new System.Drawing.Size(627, 25);
      this.customerBindingNavigator.TabIndex = 0;
      this.customerBindingNavigator.Text = "bindingNavigator1";
      // 
      // bindingNavigatorAddNewItem
      // 
      this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorAddNewItem.Text = "Add new";
      // 
      // customerBindingSource
      // 
      this.customerBindingSource.DataSource = typeof(BAGA.Customer);
      this.customerBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.customerBindingSource_AddingNew);
      this.customerBindingSource.CurrentChanged += new System.EventHandler(this.customerBindingSource_CurrentChanged);
      // 
      // bindingNavigatorCountItem
      // 
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
      this.bindingNavigatorCountItem.Text = "of {0}";
      this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
      // 
      // bindingNavigatorDeleteItem
      // 
      this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorDeleteItem.Text = "Delete";
      this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
      // 
      // bindingNavigatorMoveFirstItem
      // 
      this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveFirstItem.Text = "Move first";
      // 
      // bindingNavigatorMovePreviousItem
      // 
      this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMovePreviousItem.Text = "Move previous";
      // 
      // bindingNavigatorSeparator
      // 
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorPositionItem
      // 
      this.bindingNavigatorPositionItem.AccessibleName = "Position";
      this.bindingNavigatorPositionItem.AutoSize = false;
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.ToolTipText = "Current position";
      // 
      // bindingNavigatorSeparator1
      // 
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // bindingNavigatorMoveNextItem
      // 
      this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveNextItem.Text = "Move next";
      // 
      // bindingNavigatorMoveLastItem
      // 
      this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
      this.bindingNavigatorMoveLastItem.Text = "Move last";
      // 
      // bindingNavigatorSeparator2
      // 
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // customerBindingNavigatorSaveItem
      // 
      this.customerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.customerBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("customerBindingNavigatorSaveItem.Image")));
      this.customerBindingNavigatorSaveItem.Name = "customerBindingNavigatorSaveItem";
      this.customerBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
      this.customerBindingNavigatorSaveItem.Text = "Save Data";
      this.customerBindingNavigatorSaveItem.Click += new System.EventHandler(this.customerBindingNavigatorSaveItem_Click);
      // 
      // addDateDateTimePicker
      // 
      this.addDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.customerBindingSource, "Contact.AddDate", true));
      this.addDateDateTimePicker.Location = new System.Drawing.Point(133, 38);
      this.addDateDateTimePicker.Name = "addDateDateTimePicker";
      this.addDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.addDateDateTimePicker.TabIndex = 2;
      // 
      // contactIDTextBox
      // 
      this.contactIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Contact.ContactID", true));
      this.contactIDTextBox.Location = new System.Drawing.Point(133, 64);
      this.contactIDTextBox.Name = "contactIDTextBox";
      this.contactIDTextBox.Size = new System.Drawing.Size(200, 20);
      this.contactIDTextBox.TabIndex = 4;
      // 
      // firstNameTextBox
      // 
      this.firstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Contact.FirstName", true));
      this.firstNameTextBox.Location = new System.Drawing.Point(133, 90);
      this.firstNameTextBox.Name = "firstNameTextBox";
      this.firstNameTextBox.Size = new System.Drawing.Size(200, 20);
      this.firstNameTextBox.TabIndex = 6;
      // 
      // lastNameTextBox
      // 
      this.lastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Contact.LastName", true));
      this.lastNameTextBox.Location = new System.Drawing.Point(133, 116);
      this.lastNameTextBox.Name = "lastNameTextBox";
      this.lastNameTextBox.Size = new System.Drawing.Size(200, 20);
      this.lastNameTextBox.TabIndex = 8;
      // 
      // modifiedDateDateTimePicker
      // 
      this.modifiedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.customerBindingSource, "Contact.ModifiedDate", true));
      this.modifiedDateDateTimePicker.Location = new System.Drawing.Point(133, 142);
      this.modifiedDateDateTimePicker.Name = "modifiedDateDateTimePicker";
      this.modifiedDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.modifiedDateDateTimePicker.TabIndex = 10;
      // 
      // titleTextBox
      // 
      this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Contact.Title", true));
      this.titleTextBox.Location = new System.Drawing.Point(133, 168);
      this.titleTextBox.Name = "titleTextBox";
      this.titleTextBox.Size = new System.Drawing.Size(200, 20);
      this.titleTextBox.TabIndex = 12;
      // 
      // initialDateDateTimePicker
      // 
      this.initialDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.customerBindingSource, "Contact.Customer.InitialDate", true));
      this.initialDateDateTimePicker.Location = new System.Drawing.Point(188, 262);
      this.initialDateDateTimePicker.Name = "initialDateDateTimePicker";
      this.initialDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.initialDateDateTimePicker.TabIndex = 18;
      // 
      // notesTextBox
      // 
      this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "Contact.Customer.Notes", true));
      this.notesTextBox.Location = new System.Drawing.Point(188, 292);
      this.notesTextBox.Multiline = true;
      this.notesTextBox.Name = "notesTextBox";
      this.notesTextBox.Size = new System.Drawing.Size(396, 81);
      this.notesTextBox.TabIndex = 20;
      // 
      // nameTextBox
      // 
      this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "PrimaryActivity.Name", true));
      this.nameTextBox.Location = new System.Drawing.Point(188, 200);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(100, 20);
      this.nameTextBox.TabIndex = 21;
      this.nameTextBox.Visible = false;
      // 
      // nameTextBox1
      // 
      this.nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "PrimaryDestination.Name", true));
      this.nameTextBox1.Location = new System.Drawing.Point(188, 227);
      this.nameTextBox1.Name = "nameTextBox1";
      this.nameTextBox1.Size = new System.Drawing.Size(100, 20);
      this.nameTextBox1.TabIndex = 22;
      this.nameTextBox1.Visible = false;
      // 
      // nameTextBox2
      // 
      this.nameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "SecondaryActivity.Name", true));
      this.nameTextBox2.Location = new System.Drawing.Point(468, 197);
      this.nameTextBox2.Name = "nameTextBox2";
      this.nameTextBox2.Size = new System.Drawing.Size(100, 20);
      this.nameTextBox2.TabIndex = 23;
      this.nameTextBox2.Visible = false;
      // 
      // nameTextBox3
      // 
      this.nameTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "SecondaryDestination.Name", true));
      this.nameTextBox3.Location = new System.Drawing.Point(466, 223);
      this.nameTextBox3.Name = "nameTextBox3";
      this.nameTextBox3.Size = new System.Drawing.Size(100, 20);
      this.nameTextBox3.TabIndex = 24;
      this.nameTextBox3.Visible = false;
      // 
      // reservationsBindingSource
      // 
      this.reservationsBindingSource.DataMember = "Reservations";
      this.reservationsBindingSource.DataSource = this.customerBindingSource;
      // 
      // reservationsDataGridView
      // 
      this.reservationsDataGridView.AllowUserToAddRows = false;
      this.reservationsDataGridView.AllowUserToDeleteRows = false;
      this.reservationsDataGridView.AutoGenerateColumns = false;
      this.reservationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.reservationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reservationIDDataGridViewTextBoxColumn,
            this.resDateColumn,
            this.tripStartColumn,
            this.tripEndColumn,
            this.destinationColumn});
      this.reservationsDataGridView.DataSource = this.reservationsBindingSource;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.reservationsDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
      this.reservationsDataGridView.Location = new System.Drawing.Point(24, 389);
      this.reservationsDataGridView.Name = "reservationsDataGridView";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.reservationsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.reservationsDataGridView.Size = new System.Drawing.Size(521, 220);
      this.reservationsDataGridView.TabIndex = 25;
      this.reservationsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.reservationsDataGridView_DataBindingComplete);
      // 
      // reservationIDDataGridViewTextBoxColumn
      // 
      this.reservationIDDataGridViewTextBoxColumn.DataPropertyName = "ReservationID";
      this.reservationIDDataGridViewTextBoxColumn.HeaderText = "ReservationID";
      this.reservationIDDataGridViewTextBoxColumn.Name = "reservationIDDataGridViewTextBoxColumn";
      this.reservationIDDataGridViewTextBoxColumn.Visible = false;
      // 
      // resDateColumn
      // 
      this.resDateColumn.DataPropertyName = "ReservationDate";
      dataGridViewCellStyle4.Format = "d";
      dataGridViewCellStyle4.NullValue = null;
      this.resDateColumn.DefaultCellStyle = dataGridViewCellStyle4;
      this.resDateColumn.HeaderText = "ReservationDate";
      this.resDateColumn.Name = "resDateColumn";
      // 
      // tripStartColumn
      // 
      this.tripStartColumn.HeaderText = "Start";
      this.tripStartColumn.Name = "tripStartColumn";
      this.tripStartColumn.ReadOnly = true;
      // 
      // tripEndColumn
      // 
      this.tripEndColumn.HeaderText = "End";
      this.tripEndColumn.Name = "tripEndColumn";
      this.tripEndColumn.ReadOnly = true;
      // 
      // destinationColumn
      // 
      this.destinationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.destinationColumn.HeaderText = "Destination";
      this.destinationColumn.Name = "destinationColumn";
      this.destinationColumn.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.DataPropertyName = "ReservationID";
      this.dataGridViewTextBoxColumn1.HeaderText = "ReservationID";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "ReservationDate";
      this.dataGridViewTextBoxColumn2.HeaderText = "ReservationDate";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "ContactID";
      this.dataGridViewTextBoxColumn3.HeaderText = "ContactID";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "TripID";
      this.dataGridViewTextBoxColumn4.HeaderText = "TripID";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // dataGridViewImageColumn1
      // 
      this.dataGridViewImageColumn1.DataPropertyName = "TimeStamp";
      this.dataGridViewImageColumn1.HeaderText = "TimeStamp";
      this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "Customer";
      this.dataGridViewTextBoxColumn5.HeaderText = "Customer";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "Trip";
      this.dataGridViewTextBoxColumn6.HeaderText = "Trip";
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Payments";
      this.dataGridViewTextBoxColumn7.HeaderText = "Payments";
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      // 
      // activity1Combo
      // 
      this.activity1Combo.FormattingEnabled = true;
      this.activity1Combo.Location = new System.Drawing.Point(190, 199);
      this.activity1Combo.Name = "activity1Combo";
      this.activity1Combo.Size = new System.Drawing.Size(146, 21);
      this.activity1Combo.TabIndex = 26;
      // 
      // dest1Combo
      // 
      this.dest1Combo.FormattingEnabled = true;
      this.dest1Combo.Location = new System.Drawing.Point(190, 226);
      this.dest1Combo.Name = "dest1Combo";
      this.dest1Combo.Size = new System.Drawing.Size(146, 21);
      this.dest1Combo.TabIndex = 28;
      // 
      // activityBindingSource
      // 
      this.activityBindingSource.DataSource = typeof(BAGA.Activity);
      // 
      // activityComboBox
      // 
      this.activityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.customerBindingSource, "SecondaryActivity", true));
      this.activityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.customerBindingSource, "SecondaryActivityID", true));
      this.activityComboBox.DataSource = this.activityBindingSource;
      this.activityComboBox.DisplayMember = "Name";
      this.activityComboBox.DropDownHeight = 100;
      this.activityComboBox.FormattingEnabled = true;
      this.activityComboBox.IntegralHeight = false;
      this.activityComboBox.Location = new System.Drawing.Point(469, 195);
      this.activityComboBox.Name = "activityComboBox";
      this.activityComboBox.Size = new System.Drawing.Size(147, 21);
      this.activityComboBox.TabIndex = 28;
      this.activityComboBox.ValueMember = "ActivityID";
      // 
      // destinationBindingSource
      // 
      this.destinationBindingSource.DataSource = typeof(BAGA.Destination);
      // 
      // destinationComboBox
      // 
      this.destinationComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.customerBindingSource, "SecondaryDestinationID", true));
      this.destinationComboBox.DataSource = this.destinationBindingSource;
      this.destinationComboBox.DisplayMember = "Name";
      this.destinationComboBox.DropDownHeight = 100;
      this.destinationComboBox.FormattingEnabled = true;
      this.destinationComboBox.IntegralHeight = false;
      this.destinationComboBox.Location = new System.Drawing.Point(468, 224);
      this.destinationComboBox.Name = "destinationComboBox";
      this.destinationComboBox.Size = new System.Drawing.Size(147, 21);
      this.destinationComboBox.TabIndex = 29;
      this.destinationComboBox.ValueMember = "DestinationID";
      // 
      // label1
      // 
      label1.Location = new System.Drawing.Point(378, 45);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(167, 77);
      label1.TabIndex = 30;
      label1.Text = "New to winforms? Note you need to leave a field for its change to \"register\"";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(627, 883);
      this.Controls.Add(label1);
      this.Controls.Add(this.destinationComboBox);
      this.Controls.Add(this.activityComboBox);
      this.Controls.Add(this.dest1Combo);
      this.Controls.Add(this.activity1Combo);
      this.Controls.Add(this.reservationsDataGridView);
      this.Controls.Add(nameLabel3);
      this.Controls.Add(this.nameTextBox3);
      this.Controls.Add(nameLabel2);
      this.Controls.Add(this.nameTextBox2);
      this.Controls.Add(nameLabel1);
      this.Controls.Add(this.nameTextBox1);
      this.Controls.Add(nameLabel);
      this.Controls.Add(this.nameTextBox);
      this.Controls.Add(initialDateLabel);
      this.Controls.Add(this.initialDateDateTimePicker);
      this.Controls.Add(notesLabel);
      this.Controls.Add(this.notesTextBox);
      this.Controls.Add(addDateLabel);
      this.Controls.Add(this.addDateDateTimePicker);
      this.Controls.Add(contactIDLabel);
      this.Controls.Add(this.contactIDTextBox);
      this.Controls.Add(firstNameLabel);
      this.Controls.Add(this.firstNameTextBox);
      this.Controls.Add(lastNameLabel);
      this.Controls.Add(this.lastNameTextBox);
      this.Controls.Add(modifiedDateLabel);
      this.Controls.Add(this.modifiedDateDateTimePicker);
      this.Controls.Add(titleLabel);
      this.Controls.Add(this.titleTextBox);
      this.Controls.Add(this.customerBindingNavigator);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.customerBindingNavigator)).EndInit();
      this.customerBindingNavigator.ResumeLayout(false);
      this.customerBindingNavigator.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.reservationsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.activityBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.destinationBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource customerBindingSource;
    private System.Windows.Forms.BindingNavigator customerBindingNavigator;
    private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
    private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
    private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    private System.Windows.Forms.ToolStripButton customerBindingNavigatorSaveItem;
    private System.Windows.Forms.DateTimePicker addDateDateTimePicker;
    private System.Windows.Forms.TextBox contactIDTextBox;
    private System.Windows.Forms.TextBox firstNameTextBox;
    private System.Windows.Forms.TextBox lastNameTextBox;
    private System.Windows.Forms.DateTimePicker modifiedDateDateTimePicker;
    private System.Windows.Forms.TextBox titleTextBox;
    private System.Windows.Forms.DateTimePicker initialDateDateTimePicker;
    private System.Windows.Forms.TextBox notesTextBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.TextBox nameTextBox1;
    private System.Windows.Forms.TextBox nameTextBox2;
    private System.Windows.Forms.TextBox nameTextBox3;
    private System.Windows.Forms.BindingSource reservationsBindingSource;
    private System.Windows.Forms.DataGridView reservationsDataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.ComboBox activity1Combo;
    private System.Windows.Forms.ComboBox dest1Combo;
    private System.Windows.Forms.BindingSource activityBindingSource;
    private System.Windows.Forms.ComboBox activityComboBox;
    private System.Windows.Forms.BindingSource destinationBindingSource;
    private System.Windows.Forms.ComboBox destinationComboBox;
    private System.Windows.Forms.DataGridViewTextBoxColumn reservationIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn resDateColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tripStartColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tripEndColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn destinationColumn;

  }
}

