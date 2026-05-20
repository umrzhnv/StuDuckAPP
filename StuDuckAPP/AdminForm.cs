using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Для SQL Server
// или using System.Data.OleDb; // Для Access
// или using MySql.Data.MySqlClient; // Для MySQL
using System.Windows.Forms;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace StuDuckAPP
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\source\\repos\\StuDuckAPP\\StuDuckAPP\\StuduckDB.mdf;Integrated Security=True";
        private ComboBox comboBoxTables;
        private DataTable currentTable;
        private string currentTableName;


        public AdminForm()
        {
            InitializeComponent();
            LoadTableNames();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadTableNames()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT TABLE_NAME 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_TYPE = 'BASE TABLE' 
                ORDER BY TABLE_NAME";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["TABLE_NAME"].ToString());
                        }

                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблиц: {ex.Message}");
            }
        }

        private void LoadSelectedTable()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите таблицу из списка");
                return;
            }

            currentTableName = comboBox1.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM [{currentTableName}]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    currentTable = new DataTable();
                    adapter.Fill(currentTable);

                    dataGridView1.DataSource = currentTable;
                    dataGridView1.ReadOnly = false; // Разрешаем редактирование

                    this.Text = $"Администратор - Таблица: {currentTableName} (Записей: {currentTable.Rows.Count})";

                    MessageBox.Show($"Таблица '{currentTableName}' загружена. " +
                                  "Вы можете редактировать ячейки прямо в таблице.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблицы: {ex.Message}");
            }
        }


        private void ComboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Можно автоматически загружать таблицу при выборе
            // или оставить только по кнопке
            // LoadSelectedTable(); // Раскомментируйте для автоматической загрузки
        }


        private void ShowTableInfo(string tableName, int rowCount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем информацию о столбцах таблицы
                    string query = @"
                SELECT 
                    COLUMN_NAME,
                    DATA_TYPE,
                    IS_NULLABLE,
                    CHARACTER_MAXIMUM_LENGTH
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = @TableName
                ORDER BY ORDINAL_POSITION";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int columnCount = 0;
                            StringBuilder info = new StringBuilder();

                            while (reader.Read())
                            {
                                columnCount++;
                                string columnName = reader["COLUMN_NAME"].ToString();
                                string dataType = reader["DATA_TYPE"].ToString();
                                string nullable = reader["IS_NULLABLE"].ToString();

                                info.AppendLine($"{columnCount}. {columnName} ({dataType}) " +
                                               $"{(nullable == "YES" ? "NULL" : "NOT NULL")}");
                            }

                            // Можно вывести в лог или отдельное окно
                            // MessageBox.Show($"Таблица: {tableName}\nКолонок: {columnCount}\nЗаписей: {rowCount}\n\nСтолбцы:\n{info}", 
                            //     "Информация о таблице", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки при получении дополнительной информации
            }
        }

        private void showDB_Click(object sender, EventArgs e)
        {
            LoadSelectedTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTable == null || string.IsNullOrEmpty(currentTableName))
            {
                MessageBox.Show("Сначала загрузите таблицу, нажав кнопку 'Показать таблицу'");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите строку в таблице для удаления",
                    "Выбор строки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Если выбрана одна строка
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int rowNumber = selectedRow.Index + 1;

                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить строку {rowNumber}?\n" +
                    "Эта операция необратима!",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteRow(selectedRow);
                }
            }
            // Если выбрано несколько строк
            else
            {
                DialogResult result = MessageBox.Show(
                    $"Вы выбрали {dataGridView1.SelectedRows.Count} строк.\n" +
                    "Удалить все выбранные строки?\n" +
                    "Эта операция необратима!",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Удаляем все выбранные строки
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        DeleteRow(row);
                    }
                }
            }

        }

        private void DeleteRow(DataGridViewRow row)
        {
            try
            {
                // Получаем DataRow из DataGridView
                DataRowView rowView = row.DataBoundItem as DataRowView;
                if (rowView == null) return;

                // Находим первичный ключ (ищем столбец с ID)
                string primaryKeyColumn = "";
                object primaryKeyValue = null;

                foreach (DataColumn column in currentTable.Columns)
                {
                    if (column.ColumnName.ToLower().EndsWith("id") ||
                        column.ColumnName.ToLower() == "id")
                    {
                        primaryKeyColumn = column.ColumnName;
                        primaryKeyValue = rowView.Row[primaryKeyColumn];
                        break;
                    }
                }

                // Если не нашли ID, используем первый столбец
                if (string.IsNullOrEmpty(primaryKeyColumn))
                {
                    primaryKeyColumn = currentTable.Columns[0].ColumnName;
                    primaryKeyValue = rowView.Row[primaryKeyColumn];
                }

                // Формируем SQL запрос для удаления
                string deleteQuery = $"DELETE FROM [{currentTableName}] WHERE [{primaryKeyColumn}] = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", primaryKeyValue);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                // Удаляем строку из DataTable
                rowView.Row.Delete();
                currentTable.AcceptChanges();

                // Обновляем отображение
                dataGridView1.Refresh();

                MessageBox.Show("Строка успешно удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTable == null || string.IsNullOrEmpty(currentTableName))
            {
                MessageBox.Show("Сначала загрузите таблицу, нажав кнопку 'Показать таблицу'");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM [{currentTableName}]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Автоматически генерируем команды для обновления
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    adapter.InsertCommand = commandBuilder.GetInsertCommand();
                    adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                    // Проверяем, есть ли изменения
                    DataTable changes = currentTable.GetChanges();

                    if (changes != null && changes.Rows.Count > 0)
                    {
                        // Сохраняем изменения в БД
                        int rowsAffected = adapter.Update(currentTable);
                        currentTable.AcceptChanges();

                        MessageBox.Show($"Успешно сохранено: {rowsAffected} изменений");

                        // Обновляем отображение
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Нет изменений для сохранения");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
