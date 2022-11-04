using Microsoft.Data.SqlClient;

SqlConnectionStringBuilder conStr = new();
conStr.DataSource = "hildur.ucn.dk";
conStr.InitialCatalog = "DMA-CSD-S212_10407522";
conStr.UserID = "DMA-CSD-S212_10407522";
conStr.Password = "Password1!";
conStr.Encrypt = false;

SqlConnection con = new(conStr.ConnectionString);
con.Open();

Console.WriteLine();