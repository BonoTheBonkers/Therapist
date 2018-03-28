using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : SingletonManager<AccountManager>
{
    public void Start()
    {
    }

    public static EAccountLogInFeedback TryLogIn(string inLogin, string inPassword)
    {
        if(DatabaseManager.CheckInternetConnection())
        {
            if(DatabaseManager.CheckConnectionToDatabase())
            {
                if(IsLoginCorrectlySpelled(inLogin))
                {
                    if(DatabaseManager.IsLoginExistInDatabase(inLogin))
                    {
                        if(DatabaseManager.IsLoginAndPasswordCorrect(inLogin, inPassword))
                        {
                            MainManager.Instance.applicationData.LogIn(inLogin, inPassword);
                            return EAccountLogInFeedback.Success;
                        }
                        else
                        {
                            return EAccountLogInFeedback.IncorrectLoginOrPassword;
                        }
                    }
                    else
                    {
                        return EAccountLogInFeedback.LoginDoesntExistInDatabase;
                    }
                }
                else
                {
                    return EAccountLogInFeedback.IncorrectLoginSpelling;
                }
            }
            else
            {
                return EAccountLogInFeedback.NoConnectionToDatabase;
            }
        }
        return EAccountLogInFeedback.NoConnectionToInternet;
    }

    public static bool IsLoginCorrectlySpelled(string inLogin)
    {
        return inLogin.Contains("@") && inLogin.Contains(".") && inLogin.Length >= 3 && inLogin.IndexOf("@") > 0 && inLogin.IndexOf("@") < inLogin.Length - 1;
    }

    public static bool IsPasswordCorrectlySpelled(string inPassword)
    {
        return inPassword.Length >= 8;
    }
}
