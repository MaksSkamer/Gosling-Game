using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine.UI;

public class SQLconnection : MonoBehaviour
{
    public string DataBaseName;

    private string PLname;
    private int PLgold;
    private int PLscore;
    public void InsertInto()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();

        PLname = GameManager.instance.plName;
        PLgold = GameManager.instance.gold;
        PLscore = GameManager.instance.Score;

        string SQL_Query = "INSERT INTO Player_Score (Name, Gold, Score)" +
                            "VALUES ('" + PLname + "', " + PLgold + ", " + PLscore + ")";
        dbcmd.CommandText = SQL_Query;
        reader = dbcmd.ExecuteReader();
        while(reader.Read()) 
        {

        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
        Debug.Log("Должно было сработать");
    }
}
