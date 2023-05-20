
using UnityEngine;
using System.IO;


public static class DBmanager
{
    private static string JSONPath=Application.dataPath+"/offlineSaves.json";
    private static string json;
    private static Saves save = new Saves();

    private static readonly string crate = "lessobvious";
    //setting data
    public static void setRemember(bool logRemember)
    {
        save.remember = logRemember;
        json = JsonUtility.ToJson(save, true);
        json = EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);
        
    }
    public static void setLoggedIn(bool loggedIn)
    {
        save.loggedin = loggedIn;
        json = JsonUtility.ToJson(save, true);
        json = EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);
        

        //save.loggedin = loggedIn;
        //json = JsonUtility.ToJson(save, true);
        //File.WriteAllText(JSONPath, json);
    }
    public static void setUname(string user)
    {
        save.uname = user;
        json = JsonUtility.ToJson(save, true);
        json = EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);
        
    }
    public static void setLevel(int lev,int section)
    {
        if (section ==0)
        {
            save.level = lev;
            json = JsonUtility.ToJson(save, true);
            json = EncryptDecrypt(json);
            File.WriteAllText(JSONPath, json);
        }
        if (section ==1)
        {
            save.level1 = lev;
            json = JsonUtility.ToJson(save, true);
            json = EncryptDecrypt(json);
            File.WriteAllText(JSONPath, json);
        }
        if (section ==2)
        {
            save.level2 = lev;
            json = JsonUtility.ToJson(save, true);
            json = EncryptDecrypt(json);
            File.WriteAllText(JSONPath, json);
        }
        
    }
    /*public static void setLevel1(int lev1)
    {
        save.level1 = lev1;
        json = JsonUtility.ToJson(save, true);
        json = EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);

    }
    public static void setLevel2(int lev2)
    {
        save.level2 = lev2;
        json = JsonUtility.ToJson(save, true);
        json = EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);

    }*/


    //retriving data
    public static bool getRemember()
    {
        json=File.ReadAllText(JSONPath);
        json = EncryptDecrypt(json);
        save = JsonUtility.FromJson<Saves>(json);
        return save.remember;
    }
    public static bool getLoggedIn()
    {
        json=File.ReadAllText(JSONPath);
        json = EncryptDecrypt(json);
        save = JsonUtility.FromJson<Saves>(json);
        return save.loggedin;
        
    }
    public static string getUname()
    {
        json=File.ReadAllText(JSONPath);
        json = EncryptDecrypt(json);
        save = JsonUtility.FromJson<Saves>(json);
        return save.uname;
    }
    public static int getLevel(int section)
    {
        if (section == 0)
        {
            json=File.ReadAllText(JSONPath);
            json = EncryptDecrypt(json);
            save = JsonUtility.FromJson<Saves>(json);
            return save.level;
        }
        if (section == 1)
        {
            json=File.ReadAllText(JSONPath);
            json = EncryptDecrypt(json);
            save = JsonUtility.FromJson<Saves>(json);
            return save.level1;
        }
        if (section == 2)
        {
            json=File.ReadAllText(JSONPath);
            json = EncryptDecrypt(json);
            save = JsonUtility.FromJson<Saves>(json);
            return save.level2;
        }
        return 1;
    }


    public static void createJson()
    {
        save.loggedin = false;
        save.level = 1;
        save.level1 = 1;
        save.level2 = 1;
        save.remember = false;
        save.uname = null;
        json = JsonUtility.ToJson(save, true);
        json=EncryptDecrypt(json);
        File.WriteAllText(JSONPath, json);
    }

    
    private static string EncryptDecrypt(string data)
    {
        string result = "";

        for(int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ crate[i % crate.Length]);
            
        }
        return result;
    }





    /*
    public static string username;
    public static int level;

    public static bool LoggedIn { get { return username != null; } }
    public static void LogOut()
    {
        username = null;
        level = 0;
    }
    */

}

