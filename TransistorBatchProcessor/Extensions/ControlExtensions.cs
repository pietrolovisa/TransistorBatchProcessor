using TransisterBatch.EntityFramework.Domain;

namespace TransistorBatchProcessor.Extensions
{
    public static class ControlExtensions
    {
        public static void AddTab(this TabControl tabControl, Control control, string name)
        {
            TabPage batches = new TabPage
            {
                Text = name,
            };
            batches.Controls.Add(control);
            tabControl.TabPages.Add(batches);
        }

        public static void InitCombobox(this ComboBox comboBox, EventHandler selectedIndexChanged,
            string displayMember = "Name", string valueMember = "Id")
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndexChanged += selectedIndexChanged;
        }

        public static void InitListView(this ListView listView, System.Collections.IComparer columnSorter, 
            EventHandler selectedIndexChanged, Dictionary<string, int> columns)
        {
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            listView.Scrollable = true;
            listView.MultiSelect = false;
            listView.ListViewItemSorter = columnSorter;
            listView.ColumnClick += (s, e) => { listView.Sort(e); };
            listView.SelectedIndexChanged += selectedIndexChanged;
            foreach(KeyValuePair<string, int> column in columns)
            {
                listView.Columns.Add(column.Key, column.Value, HorizontalAlignment.Left);
            }
        }

        public static void Sort(this ListView listView, ColumnClickEventArgs e)
        {
            ListViewColumnSorter listViewColumnSorter = listView.ListViewItemSorter as ListViewColumnSorter;
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == listViewColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (listViewColumnSorter.Order == SortOrder.Ascending)
                {
                    listViewColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    listViewColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                listViewColumnSorter.SortColumn = e.Column;
                listViewColumnSorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            listView.Sort();
        }

        public static void LoadItems<T>(this ListView listView, List<T> items)
            where T : ITableBase
        {
            listView.Items.Clear();
            foreach (T item in items)
            {
                listView.AddItemToView(item);
            }
        }

        public static void AddItemToView<T>(this ListView listView, T item, bool select = false)
            where T : ITableBase
        {
            listView.AddItem(item.ToStrings, item, select);
        }

        public static void AddItem(this ListView listView, List<string> columns, object item, bool select = false)
        {
            ListViewItem listViewItem = new ListViewItem(columns.ToArray())
            {
                Tag = item
            };
            listView.Items.Add(listViewItem);
            if (select)
            {
                listViewItem.ForceSelected();
            }
        }

        public static void ForceSelected(this ListViewItem listViewItem)
        {
            listViewItem.Focused = true;
            listViewItem.Selected = true;
            listViewItem.EnsureVisible();
        }

        public static bool HasSelectedItem(this ListView listView)
        {
            return listView.SelectedItems.Count > 0;
        }

        public static EntityWrapper<T> GetItemForUpdate<T>(this ListView listView)
            where T : ITableBase
        {
            T transistor = (T)listView.SelectedItems[0]?.Tag;
            return new EntityWrapper<T>
            {
                State = EditState.Update,
                Entity = transistor
            };
        }

        public static void SetItemAfterUpdate<T>(this ListView listView, T item)
            where T : ITableBase
        {
            listView.SelectedItems[0].Tag = item;
            int index = 0;
            foreach(string subItem in item.ToStrings)
            {
                listView.SelectedItems[0].SubItems[index].Text = subItem;
                index++;
            }
        }

        public static EntityWrapper<T> GetItemForAdd<T>(this ListView listView)
             where T : ITableBase, new()
        {
            return new EntityWrapper<T>
            {
                State = EditState.New,
                Entity = new T()
            };
        }
    }
}
