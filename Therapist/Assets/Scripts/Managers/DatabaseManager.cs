using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : SingletonManager<DatabaseManager>
{
    public string[] users;
	void Start ()
    {
        DatabaseLoader();
    }

    IEnumerator DatabaseLoader()
    {
        WWW adress = new WWW("http://localhost/users_database/User,php");
        yield return adress;
        string usersDataString = adress.text;
        print(usersDataString);
        users = usersDataString.Split(',');
        print(GetUserValue(users[1], "Name: "));
    }
	
    string GetUserValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }

    public static bool CheckInternetConnection()
    {
        //@TODO
        return true;
    }

    public static bool CheckConnectionToDatabase()
    {
        //@TODO
        return true;
    }

    public static bool IsLoginExistInDatabase(string inLogin)
    {
        //@TODO
        return true;
    }

    public static bool IsLoginAndPasswordCorrect(string inLogin, string inPassword)
    {
        //@TODO
        return true;
    }
}
