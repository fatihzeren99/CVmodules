public partial class ProfileForm : Form
{
    private readonly int _profileId;

    public ProfileForm(int profileId = 0)
    {
        InitializeComponent();
        _profileId = profileId;
        if (_profileId != 0)
        {
            var dataTable = DatabaseHelper.GetDataTable($"SELECT * FROM Profiles WHERE Id = {_profileId}");
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                firstNameTextBox.Text = row["FirstName"].ToString();
                lastNameTextBox.Text = row["LastName"].ToString();
                emailTextBox.Text = row["Email"].ToString();
                phoneTextBox.Text = row["Phone"].ToString();
                addressTextBox.Text = row["Address"].ToString();
            }
        }
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (_profileId == 0)
        {
            var query =
                $"INSERT INTO Profiles(FirstName, LastName, Email, Phone, Address) VALUES('{firstNameTextBox.Text}', '{lastNameTextBox.Text}', '{emailTextBox.Text}', '{phoneTextBox.Text}', '{addressTextBox.Text}')";
            DatabaseHelper.ExecuteNonQuery(query);
        }
