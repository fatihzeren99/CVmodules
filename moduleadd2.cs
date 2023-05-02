using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

public static class DatabaseHelper
{
    private const string DbFileName = "cv.db";
    private static readonly string DbPath = Path.Combine(Application.StartupPath, DbFileName);
    private static readonly string ConnectionString = $"Data Source={DbPath};Version=3;";

    public static void CreateDatabase()
    {
        if (!File.Exists(DbPath))
        {
            SQLiteConnection.CreateFile(DbPath);
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var command = new SQLiteCommand(
                "CREATE TABLE Profiles(Id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, Email TEXT, Phone TEXT, Address TEXT)",
                connection);
            command.ExecuteNonQuery();
        }
    }

    public static DataTable GetDataTable(string query)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        using var command = new SQLiteCommand(query, connection);
        using var adapter = new SQLiteDataAdapter(command);
        var dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }

    public static void ExecuteNonQuery(string query)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        using var command = new SQLiteCommand(query, connection);
        command.ExecuteNonQuery();
    }
}
