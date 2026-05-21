using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Data.Entity;

namespace WpfApp_s00254071
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // database
        ClubData _context = new ClubData();

        public MainWindow()
        {
            InitializeComponent();
        }

        //window is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }
// Load members from database
private void LoadMembers()
{
   
    var query = from m in _context.Members
                orderby m.Surname
                select new
                {
                    Display = m.Surname + ", " + m.FirstName + " - " + m.ContactNumber
                };

    lstMembers.ItemsSource = query.ToList().Select(m => m.Display);
}

private void lstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (lstMembers.SelectedItem == null) return;

    string selected = lstMembers.SelectedItem.ToString();

    var selectedMember = _context.Members
        .FirstOrDefault(m => (m.Surname + ", " + m.FirstName + " - " + m.ContactNumber) == selected);

    if (selectedMember != null)
    {
        //detail section
        txtMemberId.Text = selectedMember.MemberId.ToString();
        txtFirstName.Text = selectedMember.FirstName;
        txtSurname.Text = selectedMember.Surname;
        txtDob.Text = selectedMember.DateOfBirth.ToShortDateString();
        txtPhone.Text = selectedMember.ContactNumber;
        txtMembershipType.Text = selectedMember.MembershipType;

        // load members 
        LoadSessions(selectedMember.MemberId);
    }
}

        private void LoadSessions(int memberId)
        {
            var sessions = _context.TrainingSessions
                .Where(s => s.MemberId == memberId)
                .Select(s => new
                {
                    Display = s.SessionDate.ToShortDateString() + " - " + s.SessionType + " (" + s.DurationMinutes + " mins)"
                })
                .ToList();

            lstSessions.ItemsSource = sessions.Select(s => s.Display);
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            if (lstMembers.SelectedItem == null)
            {
                MessageBox.Show("Please select a member first");
                return;
            }

            string selected = lstMembers.SelectedItem.ToString();
            var selectedMember = _context.Members
                .FirstOrDefault(m => (m.Surname + ", " + m.FirstName + " - " + m.ContactNumber) == selected);

            if (selectedMember != null)
            {
                MessageBox.Show("Open Add Session Window for " + selectedMember.FirstName);
            }
        }
    }
}
