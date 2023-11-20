using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Item item { get; set; }
        List<SourceItem> sourceItems { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            StreamReader s = new StreamReader("file.json",Encoding.UTF8);
            string json = s.ReadToEnd();
            item = JsonSerializer.Deserialize<Item>(json);
            s.Close();
            setSourceItems();
            itemsGrid.ItemsSource = sourceItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setEditItemForSave();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(item, options);
            File.WriteAllText(@"fileCopy.json", jsonString, Encoding.UTF8);
        }

        private void setSourceItems()
        {
            sourceItems = new List<SourceItem>();
            item.affectedAreas.ForEach(el =>
            {
                SourceItem sourceItem = new SourceItem();
                sourceItem.outageStart = item.outageStart;
                sourceItem.outageEnd = item.outageEnd;
                sourceItem.areaName = el.areaName;
                sourceItem.affectedCustomers = el.affectedCustomers;
                sourceItem.reason = el.reason;
                sourceItems.Add(sourceItem);
            });
        }

        private void setEditItemForSave()
        {
            if (sourceItems != null && sourceItems.Count != 0)
            {
                for (int i = 0; i < item.affectedAreas.Count; i++)
                {
                    item.outageStart = sourceItems[i].outageStart;
                    item.outageStart = sourceItems[i].outageEnd;
                    item.affectedAreas[i].areaName = sourceItems[i].areaName;
                    item.affectedAreas[i].affectedCustomers = sourceItems[i].affectedCustomers;
                    item.affectedAreas[i].reason = sourceItems[i].reason;
                }
            }
        }
    }
}